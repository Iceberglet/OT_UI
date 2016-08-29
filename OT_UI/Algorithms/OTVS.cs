using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public class OTVS : Algorithm
    {
        public enum SamplingScheme { Binary, Random };
        public Random RS { get; private set; }
        //public List<Solution> Solutions { get; private set; }
        //public HashSet<int> SampledIndices { get; private set; }
        public SamplingScheme Sampling { get; private set; }
        public Dictionary<int, double> LeftTaus { get; private set; }
        public Dictionary<int, double> RightTaus { get; private set; }



        private Random randForNewSamples = new Random(0);

        public OTVS()
        {
        }

        /******** Overriding Functions **********/

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);
            //Sample two extreme points
            sample(solutions.First());
            sample(solutions.Last());
        }

        public override void resetIteration()
        {
            this.initialize(solutions);
        }

        public override bool iterate()
        {
            if (solutionsSampled.Count > solutions.Count - 1) return false;

            var partial = solutions.OrderBy(i => i.HFValue).ToList();
            LeftTaus = new Dictionary<int, double>();
            RightTaus = new Dictionary<int, double>();

            Func<int, double> twoSideKendallRank = i =>
            {
                LeftTaus.Add(i, KendallRank(partial.Where(j => j.LFRank < i).Select(s => s.HFRank).ToList()));
                RightTaus.Add(i, KendallRank(partial.Where(j => j.LFRank > i).Select(s => s.HFRank).ToList()));
                return LeftTaus[i] - RightTaus[i];
            };

            foreach (var i in Enumerable.Range(0, solutions.Count))
            {
                if (!solutionsSampled.Contains(solutions.ElementAt(i)))
                {
                    var proba = twoSideKendallRank(i) / 2 + 0.5;
                    if (proba < 0) proba = 0;
                    solutions.ElementAt(i).proba = proba;
                    /*
                    if (error < minError)
                    {
                        minError = error;
                        candidates = new List<int> { i };
                    }
                    else if (error == minError) candidates.Add(i);
                    */
                }
                else
                {
                    solutions.ElementAt(i).proba = 0;
                }
            }
            var candidates = solutions.Where(s => s.proba > 0).ToList();

            var sum = candidates.Select(s => s.proba).Sum();
            var random = rand.NextDouble() * sum;
            var index = 0;
            while (random > 0)
            {
                random -= candidates[index].proba;
                index++;
            }
            //Sample index
            Solution sampled = candidates[index - 1];
            sample(sampled);
            //SampledIndices.Add(NextToSample());
            return true;
        }

        /******** End Override Functions **********/
        

        // A simplified version from 
        // https://en.wikipedia.org/wiki/Kendall_rank_correlation_coefficient
        static double KendallRank(List<int> lfOrder)
        {
            if (lfOrder.Count < 2) return 0;
            int numer = 0;
            for (int i = 1; i < lfOrder.Count; i++)
                for (int j = 0; j < i; j++)
                    numer = numer + Math.Sign(lfOrder[i] - lfOrder[j]);
            return 1.0 * numer / lfOrder.Count / (lfOrder.Count - 1) * 2;
        }
    }
}
