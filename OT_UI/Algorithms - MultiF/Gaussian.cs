using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        public Gaussian(List<SolutionMultiF> sols) : base(sols)
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
                SolutionMultiF s = solutions.Find(ss => ss.lfs[0].xRank == idx);
                sample(solutions.ElementAt(idx));
                for (int lf = 0; lf < fidelities; lf++)
                {
                    initialSamples[lf].Add(new XYPair(GPUtility.V(s.lfs[lf].xRank), s.y));  //high fidelity against THIS low fidelity
                }
            }

            solutions.ForEach(s =>
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
                    CovFunction.SquaredExponential(new LengthScale(120), new SigmaF(0.7)) + CovFunction.GaussianNoise(new SigmaJ(0.1)),
                    heteroscedastic: true,
                    sigma_f: 1
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
            for(int i = 0; i < solutions.Count; i++)
            {
                NormalDistribution[] priors = new NormalDistribution[gps.Length];
                for(int k = 0; k < priors.Length; k++)
                {
                    priors[k] = predictions[k, i];
                }
                double[] means = priors.Select(p => p.mu).ToArray();
                double[] vars = priors.Select(p => p.sd * p.sd).ToArray();
                double varProduct = vars.Aggregate((agg, next) => agg * next);
                double[] weightedVars = vars.Select(var => varProduct / var).ToArray();
                double sumOfWeightedVars = weightedVars.Sum();

                double posteriorMean = 0;
                double posteriorSd = Math.Sqrt(varProduct / sumOfWeightedVars);
                for(int k = 0; k < means.Length; k++)
                {
                    posteriorMean += means[k] * weightedVars[k];
                }
                posteriorMean /= sumOfWeightedVars;
                
                //Proba need to be zero if already sampled
                if (sampled.Contains(solutions.ElementAt(i)))
                {
                    posteriorProbas[i] = 0;
                }
                else posteriorProbas[i] = Normal.CDF(posteriorMean, posteriorSd, optimum.y);
                solutions.ElementAt(i).proba = posteriorProbas[i];
                solutions.ElementAt(i).upper = posteriorMean + 1.96 * posteriorSd;
                solutions.ElementAt(i).lower = posteriorMean - 1.96 * posteriorSd;
            }

            int nextSample = Utility.SampleAmong(posteriorProbas);
            var sol = solutions.Find(s => s.yRank == nextSample);

            for(int i = 0; i < gps.Length; i++)
            gps[i].addPoint(new XYPair(GPUtility.V(sol.lfs[i].xRank), sol.y));

            sample(sol);
            //Utility.printToFile("test.csv", posteriorProbas);
            return true;
        }

        public override void resetIteration()
        {
            initialize();
        }
    }
}
