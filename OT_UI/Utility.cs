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

        public static List<Solution> RankAndSort(List<Solution> solutions)
        {
            int rank;
            rank = 0; foreach (var s in solutions.OrderBy(s => s.HFValue)) s.HFRank = rank++;
            rank = 0; foreach (var s in solutions.OrderBy(s => s.LFValue)) s.LFRank = rank++;
            return solutions.OrderBy(s => s.LFRank).ToList();
        }
    }
}
