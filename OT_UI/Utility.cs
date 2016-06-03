using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public static class Utility
    {

        public static List<Solution> Xu2014(int g)
        {
            var solutions = new List<Solution>();
            for (var x = 0.0; x <= 100; x += 0.1)
            {
                double lfValue = 0;
                switch (g)
                {
                    case 1: lfValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * x), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2))); break; // g1
                    case 2: lfValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * (x - 1.2)), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2))); break; // g2
                    case 3: lfValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * (x - 5)), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2))); break; // g3
                }
                solutions.Add(new Solution
                {
                    HFValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * x), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2)) + 0.1 * Math.Cos(0.5 * Math.PI * x) + 0.5 * Math.Pow((x - 40) / 60, 2) + 0.4 * Math.Sin((x + 10) / 100 * Math.PI)),
                    LFValue = lfValue,
                });
            }
            return RankAndSort(solutions);
        }

        public static List<Solution> localMin()
        {
            var solutions = new List<Solution>();
            for (var x = 0; x < 1000; x++)
            {
                double y;
                if (x < 300)
                    y = 600 - 2 * x;  //600, 598, ... , 2, 
                else if (x < 600)
                    y = (x - 300) * 2 + 1; //1, 3, 5, ... , 599
                else if (x < 700)
                    y = (x - 600) * 3 + 601;  //601, 604, ... , 898
                else if (x < 800)
                    y = (800 - x) * 3 + 599;          //899, 896, ..., 605, 602
                else y = (x - 800) * 3 + 603;                  //603, ... , 900, ... , 
                solutions.Add(new Solution
                {
                    HFValue = y,
                    LFValue = x,
                });
            }

            return RankAndSort(solutions);
        }

        public static List<Solution> RankAndSort(List<Solution> solutions)
        {
            int rank;
            rank = 0; foreach (var s in solutions.OrderBy(s => s.HFValue)) s.HFRank = rank++;
            rank = 0; foreach (var s in solutions.OrderBy(s => s.LFValue)) s.LFRank = rank++;
            return solutions.OrderBy(s => s.LFRank).ToList();
        }

        public static bool hasMinKendallAtOptimum(List<Solution> sol)
        {
            var LeftTaus = new Dictionary<int, double>();
            var RightTaus = new Dictionary<int, double>();
            var Result = new Dictionary<int, double>();

            Func<int, double> twoSideKendallProba = i =>
            {
                var left = sol.Where(s => s.LFRank <= i).Select(s => s.LFRank).ToList();
                var right = sol.Where(s => s.LFRank >= i).Select(s => s.LFRank).ToList();
                left.Sort();
                right.Sort();
                left = left.Select(x => sol[x].HFRank).ToList();
                right = right.Select(x => sol[x].HFRank).ToList();

                LeftTaus.Add(i, Utility.KendallRank(left, false));   //un-normalized tau
                RightTaus.Add(i, Utility.KendallRank(right, false));
                double lSize = left.Count * (left.Count - 1) / 2;
                if (lSize == 0) lSize = 1;
                double rSize = right.Count * (right.Count - 1) / 2;
                if (rSize == 0) rSize = 1;
                //strategy a, plain average
                //var realTau = (-LeftTaus[i] / lSize + RightTaus[i] / rSize) / 2;
                //strategy b, weighted average
                var realTau = (-LeftTaus[i] * left.Count + RightTaus[i] * right.Count) / 1.0 / (left.Count + right.Count);
                //strategy c, renormalization
                //var realTau = (-LeftTaus[i] + RightTaus[i]) * 1.0 / ( lSize + rSize);

                var res = Math.Exp(realTau * 3);
                Result.Add(i, res);
                return res;
                //return (LeftTaus[i] *left.Count - RightTaus[i]* right.Count) / 1.0 / (left.Count + right.Count);
            };
            foreach (var i in Enumerable.Range(0, sol.Count))
                twoSideKendallProba(i);

            var xx = sol.OrderBy(s => s.HFRank).First().LFRank;
            var yy = Result.OrderBy(s => s.Value).Last().Key;
            popup("Best Solution is at " + xx + " and highest kendall is at " + yy + " v= " + Result[yy]);
            return xx == yy;
        }

        public static void popup(string s)
        {
            System.Windows.Forms.MessageBox.Show(s);
        }


        // A simplified version from 
        // https://en.wikipedia.org/wiki/Kendall_rank_correlation_coefficient
        // Returns a value between [-n(n-1)/2, n(n-1)/2]
        public static double KendallRank(List<int> lfOrder, bool normalize)
        {
            if (lfOrder.Count < 2) return 1;
            int numer = 0;
            for (int i = 1; i < lfOrder.Count; i++)
                for (int j = 0; j < i; j++)
                    numer = numer + Math.Sign(lfOrder[i] - lfOrder[j]);
            if(!normalize)
                return (double)numer;
            else return 1.0 * numer / lfOrder.Count / (lfOrder.Count - 1) * 2;
        }
    }
}
