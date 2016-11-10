using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;

namespace OT_UI
{
    public class ResponseSurface : Algorithm
    {

        private Random randForNewSamples = new Random(0);

        public ResponseSurface()
        {
        }

        private static double smoother;

        public override void initialize(List<Solution> solutions)
        {
            base.initialize(solutions);
            //Sample two solutions from each of 10 groups
            int groupSize = solutions.Count / 10;
            for (int i = 0; i < 10; i++)
            {
                int idxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;
                /*
                int secondIdxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;

                while (secondIdxToSample == idxToSample)
                {
                    secondIdxToSample = randForNewSamples.Next(1, groupSize) + i * groupSize;
                }*/
                sample(solutions.ElementAt(idxToSample));
                //sample(solutions.ElementAt(secondIdxToSample));
            }
            sample(solutions.First());
            sample(solutions.Last());
            //Find the smoothing factor
            //This is based on LFRank instead of LFValue.
            //Because Rank has guaranteed length, and has proven reduced group variance
            //double LFGap = Math.Abs(solutions.OrderBy(s => s.LFRank).First().LFValue - solutions.OrderBy(s => s.LFRank).Last().LFValue);
            smoother = solutions.Count * 1.0 / 100000;  //0.01;
            //Utility.popup(smoother.ToString());
        }

        public override void resetIteration()
        {
            this.initialize(solutions);
        }
        
        public override bool iterate()
        {
            populateProba();
            var candidates = solutions.Where(s => s.proba > 0).ToList();

            var sum = candidates.Select(s=>s.proba).Sum();
            var random = rand.NextDouble() * sum;
            var index = 0;
            while (random > 0)
            {
                random -= candidates[index].proba;
                index++;
            }
            //Sample index
            Solution sampled = candidates[index-1];
            sample(sampled);
            return false;
        }
        
        protected void populateProba()
        {
            Double currBest = optimum.HFValue;
            solutions.ForEach(delegate(Solution sol)
            {
                populateSolProba(sol, currBest);
            });
        }

        private void populateSolProba(Solution sol, Double currBest)
        {
            if (solutionsSampled.Contains(sol))
            {
                sol.proba = 0;
                sol.a = 0;
                sol.b = 0;
                sol.c = 0;
                return;
            }
            else
            {
                //We propose that the difference between high and low fidelity is normally distributed
                //i.e. H(x) - L(x) = deltaF ~ N(mean, var)

                //Get the weighted mean
                Double meanTop = 0, meanBtm = 0;
                foreach(Solution s in solutionsSampled)
                {
                    Double topIncrement = decayFactor(s, sol) * (s.HFValue - s.LFValue);  //The difference matters now
                    meanTop += topIncrement;
                    meanBtm += decayFactor(s, sol);
                }
                Double mean = meanTop / meanBtm;   //The mean of the posterior

                //Get the weighted variance
                Double varTop = 0, varBtm = 0;
                foreach (Solution s in solutionsSampled)
                {
                    varTop += Math.Pow((s.HFValue - s.LFValue - mean), 2) * Math.Pow(decayFactor(s, sol), 1);
                    varBtm += Math.Pow(decayFactor(s, sol), 1);// * (solutionsSampled.Count);
                }
                Double stddev = Math.Pow(varTop / varBtm, 0.5);

                //Calculate the prior proba
                //Current best is measured in terms of high fidelity. Hence offset by sol's low fidelity to match
                mean += sol.LFValue;
                Double p = Normal.CDF(mean, stddev, currBest);
                sol.proba = p;
                sol.a = mean + stddev * 2;
                sol.b = mean;
                sol.c = mean - stddev * 2;
            }
        }


        //Decay Factor for two indices on Solution Axis (LF)
        //Always equal to 1 if distance is 1, and asymptotically goes to 0 as distance goes up
        private Double decayFactor(Solution s1, Solution s2)
        {
            //Dist is 0 if they are neighbor, otherwise decays exponentially
            double dist = Math.Abs(s1.LFRank - s2.LFRank);
            Double p = Math.Exp(-dist * smoother);
            //Double p = Math.Pow(Math.Abs(s1.LFValue - s2.LFValue), -1); //** IMPORTANT ** LFRank is used instead of LFValue
            return p;
        }


        public override int getStartingPoint()
        {
            return 11;
        }
    }
}
