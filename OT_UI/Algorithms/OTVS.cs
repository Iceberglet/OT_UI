using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public class OTVS : Algorithm
    {
        public enum SamplingScheme { Binary, Random };
        public static Random RS = new Random();
        //public List<Solution> Solutions { get; private set; }
        //public HashSet<int> SampledIndices { get; private set; }
        public SamplingScheme Sampling { get; private set; }
        public Dictionary<int, double> LeftTaus { get; private set; }
        public Dictionary<int, double> RightTaus { get; private set; }
        private int smoothFactor;



        private Random randForNewSamples = new Random(0);

        public OTVS(int p)
        {
            smoothFactor = p;
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

            var partial = solutionsSampled.OrderBy(i => i.HFValue).Select(s => s.LFRank).ToList();
            LeftTaus = new Dictionary<int, double>();
            RightTaus = new Dictionary<int, double>();

            Func<int, double> twoSideKendallRank = i =>
            {
                
                LeftTaus.Add(i, KendallRank(new int[] { i }.Concat(partial.Where(j => j < i)).ToList()));
                RightTaus.Add(i, KendallRank(new int[] { i }.Concat(partial.Where(j => j > i)).ToList()));
                var p = - LeftTaus[i] + RightTaus[i];
                return p;
            };

            //var candidates = new List<int>();
            foreach (var i in Enumerable.Range(0, solutions.Count))
            {
                if (!solutionsSampled.Contains(solutions.ElementAt(i)))
                {
                    
                    var proba = twoSideKendallRank(i) / 2 + 0.5;
                    proba = Math.Pow(proba, smoothFactor);  //Make it explore or exploit?
                    if (proba < 0) proba = 0;
                    solutions.ElementAt(i).proba = proba;
                    
                    /*
                    var error = twoSideKendallRank(i);
                    solutions.ElementAt(i).proba = error;
                    if (error > maxTau)
                    {
                        maxTau = error;
                        candidates = new List<int> { i };
                    }
                    else if (error == maxTau) candidates.Add(i);
                    */
                }
                else
                {
                    solutions.ElementAt(i).proba = 0;
                }
            }

            //Sample among the max
            //Solution sampled = solutions.ElementAt(candidates[candidates.Count / 2]);
            //Solution sampled = solutions.ElementAt(candidates[RS.Next(candidates.Count)]);
            
            
            var candidates = solutions.Where(s => s.proba > 0).OrderBy(s => s.LFRank).ToList();
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
            return true;
        }

        /******** End Override Functions **********/
        

        // A simplified version from 
        // https://en.wikipedia.org/wiki/Kendall_rank_correlation_coefficient
        //This measure Kendall between lfOrder's ascending Kendall coefficient
        static double KendallRank(List<int> lfOrder)
        {
            if (lfOrder.Count < 2) return 0;
            int numer = 0;
            for (int i = 1; i < lfOrder.Count; i++)
                for (int j = 0; j < i; j++)
                    numer = numer + Math.Sign(lfOrder[i] - lfOrder[j]);
            return 1.0 * numer / lfOrder.Count / (lfOrder.Count - 1) * 2;
        }

        public override int getStartingPoint()
        {
            return 3;
        }

        //Must be used alone
        public void printCorrelationCoefficient()
        {
            String header = "LF, OTVS";

            using (var sw = new StreamWriter("OTVS_Coefficient_MultipleMinimum.csv", true)) sw.WriteLine(header);

            LeftTaus = new Dictionary<int, double>();
            RightTaus = new Dictionary<int, double>();
            var partial = solutions.OrderBy(i => i.HFValue).Select(s => s.LFRank).ToList();
            Func<int, double> twoSideKendallRank = i =>
            {
                LeftTaus.Add(i, KendallRank(new int[] { i }.Concat(partial.Where(j => j < i)).ToList()));
                RightTaus.Add(i, KendallRank(new int[] { i }.Concat(partial.Where(j => j > i)).ToList()));
                var p = (-LeftTaus[i] + RightTaus[i])/2;  //between -1 and 1
                return p;
            };

            for(int i = 1; i < solutions.Count-1; i++)
            {
                var proba = twoSideKendallRank(i);
                //proba = Math.Pow(proba, smoothFactor);
                String line = solutions.ElementAt(i).LFRank + "," + solutions.ElementAt(i).HFRank + "," + proba;

                using (var sw = new StreamWriter("OTVS_Coefficient_MultipleMinimum.csv", true)) sw.WriteLine(line);
            }
        }
    }
}
