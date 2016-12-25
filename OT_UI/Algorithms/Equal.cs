using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace OT_UI
{
    public class Equal : Algorithm
    {
        private Random randForNewSamples = new Random(0);
        
        protected int groupNumber;  //Number of groups

        protected List<List<Solution>> solutionGroups;

        public Equal(int groups)
        {
            this.groupNumber = groups;
        }

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);
            this.solutionGroups = Enumerable.Range(0, groupNumber).Select(i => new List<Solution>()).ToList();
            for (int i = 0; i < solutions.Count; i++)
                solutionGroups[i * groupNumber / solutions.Count].Add(solutions[i]);
            //Sample two solutions from each of 10 groups
            int groupSize = solutions.Count / groupNumber;
            for (int i = 0; i < groupNumber; i++)
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
            var candidates = solutions.Where(s => !solutionsSampled.Contains(s)).OrderBy(s => s.LFValue).ToList();
            Solution sampled = candidates.ElementAt(rand.Next(0, candidates.Count));
            sample(sampled);
            return true;
        }

        public override int getStartingPoint()
        {
            return 2 * groupNumber + 1;
        }


        public override string getName()
        {
            return "EQUAL";
        }
    }
}
