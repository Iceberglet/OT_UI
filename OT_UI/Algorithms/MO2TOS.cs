using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace OT_UI
{
    public class MO2TOS : Algorithm
    {
        private Random randForNewSamples = new Random(0);

        public enum SamplingScheme { Greedy, Random, Hybrid };
        protected SamplingScheme sampleScheme;
        protected int groupNumber;  //Number of groups

        protected List<List<Solution>> solutionGroups;

        public MO2TOS(int groups, SamplingScheme scheme = SamplingScheme.Hybrid)
        {
            this.groupNumber = groups;
            this.sampleScheme = scheme;
        }

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);
            this.solutionGroups = Enumerable.Range(0, groupNumber).Select(i => new List<Solution>()).ToList();
            for (int i = 0; i < solutions.Count; i++)
                solutionGroups[i * groupNumber / solutions.Count].Add(solutions[i]);
            //Sample two solutions from each of 10 groups
            int groupSize = solutions.Count / 10;
            for (int i = 0; i < 10; i++)
            {
                int idxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;
                int secondIdxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;

                while (secondIdxToSample == idxToSample)
                {
                    secondIdxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;
                }
                sample(solutions.ElementAt(idxToSample));
                sample(solutions.ElementAt(secondIdxToSample));
            }
            /*
            foreach (var group in solutionGroups)
            {
                Sample(group);
                Sample(group);
            }*/
        }

        public override void resetIteration()
        {
            this.initialize(solutions);
        }

        public override bool iterate()
        {
            var positiveRatios = OCBAMarginalRatios.Select(r => Math.Max(0, r)).ToArray();
            while (true)
            {
                var sum = rand.NextDouble() * positiveRatios.Sum();
                for (int i = 0; i < positiveRatios.Length; i++)
                {
                    sum -= positiveRatios[i];
                    if (sum < 0 && Sample(solutionGroups[i])) return true;
                }
            }
        }


        public double[] OCBAMarginalRatios
        {
            get
            {
                var targetRatios = OCBARatios;
                var currentRatios = solutionGroups.Select(g => (double)g.Count(s => solutionsSampled.Contains(s))).ToArray();
                currentRatios = currentRatios.Select(r => r / currentRatios.Sum()).ToArray();
                return Enumerable.Range(0, solutionGroups.Count).Select(i => targetRatios[i] - currentRatios[i]).ToArray();
            }
        }

        private double[] OCBARatios
        {
            get
            {
                var hfValues = solutionGroups.Select(g => g.Where(s => solutionsSampled.Contains(s)).Select(s => s.HFValue).ToList()).ToList();
                var means = hfValues.Select(g => g.Mean()).ToArray();
                var stddevs = hfValues.Select(g => g.StandardDeviation()).ToArray();

                var indices = Enumerable.Range(0, means.Count()).ToList();
                var min = means.Min();
                var minIndices = indices.Where(i => means[i] == min).ToArray();
                if (minIndices.Count() < indices.Count())
                {
                    var ratios = indices.Select(i => Math.Pow(stddevs[i] / (means[i] - min), 2)).ToArray();
                    foreach (var i in minIndices) ratios[i] = stddevs[i] * Math.Sqrt(indices.Except(minIndices).Sum(j => Math.Pow(ratios[j] / stddevs[j], 2)));
                    var sum = ratios.Sum();
                    return ratios.Select(r => r / sum).ToArray();
                }
                return Enumerable.Repeat(1.0 / indices.Count, indices.Count).ToArray();
            }
        }

        protected bool Sample(List<Solution> group)
        {
            var candidates = group.Where(s => !solutionsSampled.Contains(s)).OrderBy(s => s.LFValue).ToList();
            if (candidates.Count < 1) return false;
            Solution sampled;
            switch (sampleScheme)
            {
                case SamplingScheme.Greedy: sampled = candidates.First(); break;
                case SamplingScheme.Random: sampled = candidates[rand.Next(candidates.Count)]; break;
                default:
                    if (rand.NextDouble() < 0.5) sampled = candidates.First();
                    else sampled = candidates[rand.Next(candidates.Count)];
                    break;
            }
            sample(sampled);
            //solutionsSampled.Add(sampled);
            //lfNewlySampled.Clear();
            //lfNewlySampled.Add(sampled.LFRank);
            return true;
        }
    }
}
