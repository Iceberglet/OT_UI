using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;

namespace OT_UI
{
    public class Prior : Algorithm
    {


        public Prior()
        {
        }

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);
            //Sample two solutions from each of 10 groups
            int groupSize = solutions.Count / 10;
            for (int i = 0; i < 10; i++)
            {
                int idxToSample = rand.Next(groupSize) + i * groupSize;
                int secondIdxToSample = rand.Next(groupSize) + i * groupSize;

                while (secondIdxToSample == idxToSample)
                {
                    secondIdxToSample = rand.Next(groupSize) + i * groupSize;
                }
                solutionsSampled.Add(solutions.ElementAt(idxToSample));
                solutionsSampled.Add(solutions.ElementAt(secondIdxToSample));
            }
        }

        public override void resetIteration()
        {
            this.initialize(solutions);
        }
        
        public override bool iterate()
        {
            //populateProba();
            var candidates = solutions.Where(s => s.proba > 0).ToList();

            var sum = candidates.Select(s=>s.proba).Sum();
            var random = rand.NextDouble() * sum;
            var index = 0;
            //Try to select the group to sample
            while (random > 0)
            {
                random -= candidates[index].proba;
                index++;
            }
            //Sample index
            Solution sampled = candidates[index - 1];
            solutionsSampled.Add(sampled);
            lfNewlySampled.Clear();
            lfNewlySampled.Add(sampled.LFRank);
            return false;
        }
        /*
        protected void populateProba()
        {
            solutionGroups.ForEach(delegate(List<Solution> sols)
            {
                //Find mean and stddev of the sampled points in EACH group
                var hfValues = sols.Where(s => solutionsSampled.Contains(s)).Select(s => s.HFValue).ToList();
                var mean = hfValues.Mean();
                var stddev = hfValues.StandardDeviation();
                double proba = Normal.CDF(mean, stddev, optimum.HFValue);

                //Already sampled gets 0
                sols.ForEach(sol => sol.proba = solutionsSampled.Contains(sol) ? 0 : proba);
            });
        }

        //Only used in initialization
        protected bool Sample(List<Solution> group)
        {
            var candidates = group.Where(s => !solutionsSampled.Contains(s)).OrderBy(s => s.LFValue).ToList();
            if (candidates.Count < 1) return false;
            //Solution sampled = candidates[rand.Next(candidates.Count)];
            Solution sampled = null;
            if (rand.NextDouble() < 0.5) sampled = candidates.First();
            else sampled = candidates[rand.Next(candidates.Count)];
            solutionsSampled.Add(sampled);
            return true;
        }*/
    }
}
