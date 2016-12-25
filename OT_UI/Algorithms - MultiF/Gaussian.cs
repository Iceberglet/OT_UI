﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GaussianRegression.Core;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace OT_UI
{
    public class Gaussian : AlgorithmMultiF
    {
        GP[] gps;

        public Gaussian(IReadOnlyCollection<SolutionMultiF> sols) : base(sols)
        {
            this.solutions = sols;
            initialize();
        }

        public override void initialize()
        {
            base.initialize();
            int fidelities = solutions.First().lfs.Length;

            gps = new GP[fidelities];
            List<LabeledVector>[] list_x = new List<LabeledVector>[fidelities];

            //Generate Initial Samples
            List<XYPair>[] initialSamples = new List<XYPair>[fidelities];
            for (int lf = 0; lf < fidelities; lf++)
            {
                initialSamples[lf] = new List<XYPair>();
                list_x[lf] = new List<LabeledVector>();
            }

            var num = 20;
            for (int i = 0; i < num; i++)
            {
                var idx = solutions.Count / num * i + rand.Next(0, solutions.Count / num);
                SolutionMultiF s = solutions.ToList().Find(ss => ss.yRank == idx);
                sample(s);
                for (int lf = 0; lf < fidelities; lf++)
                {
                    initialSamples[lf].Add(new XYPair(GPUtility.V(s.lfs[lf].xRank), s.y));  //high fidelity against THIS low fidelity
                }
            }

            solutions.ToList().ForEach(s =>
            {
                //Generate the fidelity rankings for each fidelity
                for (int lf = 0; lf < fidelities; lf++)
                {
                    list_x[lf].Add(new LabeledVector(s.yRank, GPUtility.V(s.lfs[lf].xRank)));
                }
            });
            
            foreach (var i in Enumerable.Range(0, fidelities))
            {
                GP anotherGP = new GP(initialSamples[i], list_x[i], 
                    CovFunction.SquaredExponential(new LengthScale(240), new SigmaF(0.5)) + CovFunction.GaussianNoise(new SigmaJ(0.1)),
                    heteroscedastic: true, estimateHyperPara: true
                    );
                gps[i] = anotherGP;
            }
        }

        public override int getStartingPoint()
        {
            return 21;
        }

        public override bool iterate()
        {
            //get prediction from all GP
            NormalDistribution[,] predictions = new NormalDistribution[gps.Length, solutions.Count];
            double[] posteriorProbas = new double[solutions.Count];
            for (int i = 0; i < gps.Length; i++)
            {
                var res = gps[i].predict();
                foreach(var kv in res)
                {
                    //kv.Key.idx is the true rank
                    predictions[i, kv.Key.idx] = kv.Value;
                }
            }
            for (int i = 0; i < solutions.Count; i++)
            {
                NormalDistribution[] priors = new NormalDistribution[gps.Length];
                for (int k = 0; k < priors.Length; k++)
                {
                    priors[k] = predictions[k, i];
                }
                double[] means = priors.Select(p => p.mu).ToArray();
                double[] vars = priors.Select(p => p.sd * p.sd).ToArray();

                //Compute w1 and w2
                SolutionMultiF s = solutions.ElementAt(i);
                double b1 = means[0] - s.lfs[0].x;
                double b2 = means[1] - s.lfs[1].x;
                double w1 = b2 / (b2 - b1);
                double w2 = b1 / (b1 - b2);

                double posteriorMean = w1 * s.lfs[0].x + w2 * s.lfs[1].x;

                double posteriorSd = vars[0];
                
                posteriorProbas[i] = Normal.CDF(posteriorMean, posteriorSd, optimum.y);
                s.upper = posteriorMean + 1.95 * posteriorSd;
                s.lower = posteriorMean - 1.95 * posteriorSd;
                /*
                SolutionMultiF s = solutions.ElementAt(i);
                s.proba = posteriorProbas[i];
                //s.upper = posteriorMean + 1.96 * posteriorSd;
                //s.lower = posteriorMean - 1.96 * posteriorSd;

                /***** Solve for w1 and w2 ******
                double w1 = priors[0].mu;
                double w2 = priors[1].mu;
                s.upper = w1 * s.lfs[0].x + w2 * s.lfs[1].x;
                //*/

                //Proba need to be zero if already sampled
                if (sampled.Contains(s))
                {
                    s.upper = 0;
                    s.lower = 0;
                    posteriorProbas[i] = 0;
                }
            }

            int nextSample = Utility.SampleAmong(posteriorProbas);
            var sol = solutions.ElementAt(nextSample);
            
            for (int i = 0; i < gps.Length; i++)
            {
                gps[i].addPoint(new XYPair(GPUtility.V(sol.lfs[i].xRank), sol.y));
            }

            sample(sol);
            //Utility.printToFile("test.csv", posteriorProbas);
            return true;
        }

        private double[] getWeight(SolutionMultiF sol)
        {
            double[] w = new double[sol.lfs.Length];
            double b1 = sol.y - sol.lfs[0].x;
            double b2 = sol.y - sol.lfs[1].x;
            w[0] = b2 / (b2 - b1);
            w[1] = b1 / (b1 - b2);
            return w;
        }

        public override void resetIteration()
        {
            initialize();
        }

        public override string getName()
        {
            return "Gaussian Multiple";
        }
    }
}
