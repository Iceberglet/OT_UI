﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GaussianRegression.Core;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

/// <summary>
/// This uses a simple prior combination as a means for combining multiple posteriors from different low fidelities
/// The combination is based on variance
/// </summary>

namespace OT_UI
{
    public class Gaussian2 : AlgorithmMultiF
    {
        GP[] gps;

        public Gaussian2(IReadOnlyCollection<SolutionMultiF> sols) : base(sols)
        {
            this.solutions = sols; //.OrderBy(s=>s.lfs[0].xRank).ToList();
            //initialize();
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
                SolutionMultiF s = solutions.ElementAt(idx);
                sample(s);
                for (int lf = 0; lf < fidelities; lf++)
                {
                    //Regress on bias
                    initialSamples[lf].Add(new XYPair(GPUtility.V(s.lfs[lf].xRank), s.y - s.lfs[lf].x));  //high fidelity against THIS low fidelity
                }
            }

            solutions.ToList().ForEach(s =>
            {
                //Generate the fidelity rankings for each fidelity
                for (int lf = 0; lf < fidelities; lf++)
                {
                    list_x[lf].Add(new LabeledVector(s.lfs[lf].xRank, GPUtility.V(s.lfs[lf].xRank)));
                }
            });

            for (int lf = 0; lf < fidelities; lf++)
            {
                GP anotherGP = new GP(initialSamples[lf], list_x[lf], 
                    CovFunction.SquaredExponential(new LengthScale(240), new SigmaF(0.3)) + CovFunction.GaussianNoise(new SigmaJ(0.05)),
                    heteroscedastic: true, estimateHyperPara: true
                    );
                gps[lf] = anotherGP;
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
                    //kv.Key.idx is the LF0 rank
                    predictions[i, kv.Key.idx] = kv.Value;
                }
            }
            for(int i = 0; i < solutions.Count; i++)
            {
                //SOlution is ordered by first LF Ranking
                SolutionMultiF s = solutions.ElementAt(i);//solutions.Where(so=>so.idx == i).First();

                NormalDistribution[] priors = new NormalDistribution[gps.Length];
                for(int k = 0; k < priors.Length; k++)
                {
                    NormalDistribution biasN = predictions[k, i];
                    priors[k] = new NormalDistribution(biasN.mu + s.lfs[k].x, biasN.sd);//restore from bias
                }

                //double EI = NormalDistribution.GetExpectedImprovement(optimum.y, priors[0], priors[1]);
                NormalDistribution combined = (priors[0] * priors[1]);
                posteriorProbas[i] = combined.getExpectedImprovement(optimum.y);

                s.proba = posteriorProbas[i];//posteriorProbas[i];
                s.upper = priors[0].mu + 1.96 * priors[0].sd;
                s.lower = priors[0].mu - 1.96 * priors[0].sd;
                //Proba need to be zero if already sampled
                if (sampled.Contains(s))
                {
                    posteriorProbas[i] = 0;
                }
            }

            int nextSample = Utility.SampleAmong(posteriorProbas);
            var sol = solutions.ElementAt(nextSample);

            for (int i = 0; i < gps.Length; i++)
                gps[i].addPoint(new XYPair(GPUtility.V(sol.lfs[i].xRank), sol.y));

            sample(sol);
            //Utility.printToFile("test.csv", posteriorProbas);
            return true;
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