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
    class GaussianSingle : Algorithm
    {
        private GP myGP;
        private static int startSamples = 20;

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);

            var num = startSamples;

            for (int i = 0; i < num; i++)
            {
                var idx = solutions.Count / num * i + rand.Next(0, solutions.Count / num);
                sample(solutions.ElementAt(idx));
            }
            //GP on bias: f-g
            var initial = solutionsSampled.Select(s => new XYPair(GPUtility.V(s.LFRank), s.HFValue - s.LFValue)).ToList();
            var list_x = solutions.Select(s => new LabeledVector(s.LFRank, GPUtility.V(s.LFRank))).ToList();
            myGP = new GP(initial, list_x, CovFunction.SquaredExponential(new LengthScale(250), new SigmaF(100)) + CovFunction.GaussianNoise(new SigmaJ(10)),
                    heteroscedastic: true, estimateHyperPara: true
                    );
        }


        private int iter = 0;
        public override bool iterate()
        {
            iter++;
            //For logging purposes
            //var X = new double[solutions.Count];
            //var Y = new double[solutions.Count];
            //var upper = new double[solutions.Count];
            //var lower = new double[solutions.Count];
            var probas = new double[solutions.Count];
            
            var res = myGP.predict();
            foreach(var kv in res)
            {
                Solution s = solutions.Find(x => x.LFRank == kv.Key.idx);   //lf compare
                double mean = kv.Value.mu + s.LFValue;
                double sd = kv.Value.sd;
                var posterior = new NormalDistribution(mean, sd);
                s.proba = posterior.getExpectedImprovement(optimum.HFValue);
                //if (sd > 0.01)
                //    Utility.popup(sd.ToString());
                s.a = mean + 1.96 * sd;
                s.b = mean - 1.96 * sd;

                //X[kv.Key.idx] = kv.Key.idx;
                //Y[kv.Key.idx] = s.HFValue;
                //upper[kv.Key.idx] = s.a;
                //lower[kv.Key.idx] = s.b;
                probas[kv.Key.idx] = solutionsSampled.Contains(s) ? 0 : s.proba;
            }

            var next = solutions[Utility.SampleAmong(probas)];
            sample(next);
            myGP.addPoint(new XYPair(GPUtility.V(next.LFRank), next.HFValue - next.LFValue));

            //Logging
            //Utility.exportExcel<double>("Gaussian" + iter + ".csv", X.ToList(), Y.ToList(), lower.ToList(), upper.ToList(), probas.ToList());

            return true;
        }

        public override void resetIteration()
        {
            initialize(solutions);
        }

        public override int getStartingPoint()
        {
            return startSamples + 1;
        }

        public override string getName()
        {
            return "Gaussian";
        }
    }
}
