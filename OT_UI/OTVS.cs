using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public class Solution
    {
        public double LFValue { get; set; }
        public double HFValue { get; set; }
        public int LFRank { get; set; }
        public int HFRank { get; set; }
    }

    public class OTVS
    {
        public enum SamplingScheme { Binary, Random };
        public Random RS { get; private set; }
        public List<Solution> Solutions { get; private set; }
        public SamplingScheme Sampling { get; private set; }
        private static int maxTries = 80;
        private int tries = 0;


        public HashSet<int> SampledIndices { get; private set; }
        public List<double> SampledResults { get; private set; }
        public List<int> partial = new List<int>();
        double bestSofar = double.PositiveInfinity;

        public Dictionary<int, double> LeftTaus { get; private set; }
        public Dictionary<int, double> RightTaus { get; private set; }

        //Decided once constructor initializes them
        private readonly Controller.sl_Filter filter;
        private readonly Controller.sl_Kendall kendall;
        private readonly Controller.sl_Strategy strategy;

        public OTVS(List<Solution> solutions, SamplingScheme samplingScheme = SamplingScheme.Binary, int seed = 0)
        {
            LeftTaus = new Dictionary<int, double>();
            RightTaus = new Dictionary<int, double>();
            RS = new Random(seed);
            Sampling = samplingScheme;
            Solutions = solutions.OrderBy(s => s.LFValue).ToList();
            SampledIndices = new HashSet<int>(new int[] { 0, solutions.Count - 1 }.Distinct());
            SampledResults = new List<double>();
            
            tries = 0;

            filter = Controller.selected_filter;
            kendall = Controller.selected_kendall;
            strategy = Controller.selected_strategy;

        }

        //Order sampled indices by their LF value
        public List<Solution> OrderedSamples {
            get {
                return SampledIndices.Take(SampledIndices.Count - 1).Select(i => Solutions[i]).OrderBy(s => s.LFValue).ToList();
            }
        }
        public Solution LastSample { get { return Solutions[SampledIndices.Last()]; } }
        public Solution Optimum { get { return SampledIndices.Select(i => Solutions[i]).OrderBy(s => s.HFValue).First(); } }
        public bool Iterate()
        {
            //If all are sampled
            if (SampledIndices.Count > Solutions.Count - 1 || tries >= maxTries) return false;
            //Or if max is attained
            //if (bestSofar == Optimum.HFValue) return false;

            int next = NextToSample();
            SampledIndices.Add(next);
            double v = Solutions.ElementAt(next).HFValue < bestSofar ? Solutions.ElementAt(next).HFValue : bestSofar;
            SampledResults.Add(v);
            return true;
        }

        private int NextToSample()
        {
            partial = filterSolutions();
            Console.WriteLine("SAMPLED: " + SampledIndices.Count + " AFTER FILTER:" + partial.Count);
            //filter for btm ranked solutions

            return sampleFrom();
        }

        //0 - no filtering
        //1 - btm filter
        //2 - proximity filter
        private List<int> filterSolutions()
        {
            List<int> res = new List<int>();
            double proximityThreshold = 2;
            switch (filter)
            {
                case Controller.sl_Filter.None: return SampledIndices.OrderBy(i => Solutions[i].HFValue).ToList();
                case Controller.sl_Filter.Domi:
                    foreach(int i in SampledIndices)
                    {
                        bool leftbtm = true; //dominating left btm?
                        bool rightbtm = true;//dominating right btm?
                        foreach(int j in SampledIndices)
                        {
                            //If it has both leftbtm dominance AND rightbtm dominance
                            if (!leftbtm && !rightbtm)
                                break;
                            //We look for any solution that DOES NOT have left-btm dominance OR right-btm dominance
                            if (i == j)
                                continue;
                            if (Solutions[j].HFRank < Solutions[i].HFRank && Solutions[j].LFRank < Solutions[i].LFRank)
                            {
                                leftbtm = false;
                            }
                            if (Solutions[j].HFRank < Solutions[i].HFRank && Solutions[j].LFRank > Solutions[i].LFRank)
                            {
                                rightbtm = false;
                            }
                        }
                        if (leftbtm || rightbtm)
                            res.Add(i);
                    }
                    return res;
                case Controller.sl_Filter.Pncr:
                    List<int> sq = SampledIndices.OrderBy(i => Solutions[i].LFRank).ToList();
                    for (int i = 1; i < sq.Count - 1; i++)
                    {
                        //The left and right that maximizes the HRank / LRank
                        int l = 0;
                        double ll = double.NegativeInfinity;
                        int r = 2;
                        double rr = double.NegativeInfinity;
                        for (int left = 0; left < i; left++)
                        {
                            double new_ll = (Solutions[sq[i]].HFRank - Solutions[sq[left]].HFRank) * 1.0 / (Solutions[sq[i]].LFRank - Solutions[sq[left]].LFRank);
                            if (new_ll > ll)
                            {
                                ll = new_ll;
                                l = left;
                            }
                        }
                        for (int right = i + 1; right < sq.Count; right++)
                        {
                            double new_rr = (Solutions[sq[i]].HFRank - Solutions[sq[right]].HFRank) * 1.0 / (Solutions[sq[right]].LFRank - Solutions[sq[i]].LFRank);
                            if (new_rr > rr)
                            {
                                rr = new_rr;
                                r = right;
                            }
                        }

                        if (ll > 0 && rr > 0) //Otherwise we don't have a triangle for the angle
                        {
                            double angle = Solutions[sq[i]].HFRank * 2.0 - Solutions[sq[l]].HFRank - Solutions[sq[r]].HFRank;
                            angle /= (Solutions[sq[r]].LFRank - Solutions[sq[l]].LFRank);
                            if (angle < proximityThreshold)
                                res.Add(sq[i]);
                        }
                        else res.Add(sq[i]);
                    }
                    return res;
                default:
                    return null;
            }
        }

        //0 - take best
        //1 - probability based on kendall
        private int sampleFrom()
        {
            LeftTaus = new Dictionary<int, double>();
            RightTaus = new Dictionary<int, double>();

            //For each candidate solution we calculate its L and R tau values
            Func<int, double> twoSideKendallProba = i =>
            {
                List<int> left = new int[] { i }.Concat(partial.Where(j => j < i)).ToList();
                List<int> right = new int[] { i }.Concat(partial.Where(j => j > i)).ToList();
                LeftTaus.Add(i, KendallRank(left));
                RightTaus.Add(i, KendallRank(right));
                return Math.Exp((- LeftTaus[i] + RightTaus[i])*5);
                //return (LeftTaus[i] *left.Count - RightTaus[i]* right.Count) / 1.0 / (left.Count + right.Count);
            };

            var candidates = new List<int>();

            switch (strategy)
            {
                case Controller.sl_Strategy.Det1:
                    var maxProba = double.NegativeInfinity;
                    foreach (var i in Enumerable.Range(0, Solutions.Count))
                        if (!SampledIndices.Contains(i))
                        {
                            var error = twoSideKendallProba(i);
                            if (error > maxProba)
                            {
                                maxProba = error;
                                candidates = new List<int> { i };
                            }
                            else if (error == maxProba) candidates.Add(i);
                        }
                    if (Sampling == SamplingScheme.Binary) return candidates[candidates.Count / 2];
                    return candidates[RS.Next(candidates.Count)];

                case Controller.sl_Strategy.Kernel:
                    var candidateProba = new List<double>();
                    double probaSum = 0;
                    foreach (var i in Enumerable.Range(0, Solutions.Count))
                        if (!SampledIndices.Contains(i))
                        {
                            candidates.Add(i);

                            var temp = twoSideKendallProba(i);
                            candidateProba.Add(temp);
                            probaSum += temp;
                        }
                    //Sample
                    double target = RS.NextDouble() * probaSum;
                    while(target > 0)
                    {
                        if (candidates.Count == 1)
                            return candidates.Last();
                        candidates.RemoveAt(candidates.Count - 1);
                        target -= candidateProba.Last();
                        candidateProba.RemoveAt(candidateProba.Count - 1);
                    }
                    return candidates.Last();
                default: return -1;
            }
        }

        public Tuple<double,double> KendallDistances
        {
            get { return new Tuple<double, double>(-LeftTaus[SampledIndices.Last()], RightTaus[SampledIndices.Last()]); }
        }

        // A simplified version from 
        // https://en.wikipedia.org/wiki/Kendall_rank_correlation_coefficient
        // Returns a value between [-n(n-1)/2, n(n-1)/2]
        static double KendallRank(List<int> lfOrder)
        {
            if (lfOrder.Count < 2) return 1;
            int numer = 0;
            for (int i = 1; i < lfOrder.Count; i++)
                for (int j = 0; j < i; j++)
                    numer = numer + Math.Sign(lfOrder[i] - lfOrder[j]);
            return 1.0 * numer / lfOrder.Count / (lfOrder.Count - 1) * 2;
        }
    }
}
