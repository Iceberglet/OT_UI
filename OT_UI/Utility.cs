using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace OT_UI
{
    public static class Utility
    {
        private static readonly Random rand = new Random();

        public static List<Solution> HighDimensional()
        {
            List<Solution> res = new List<Solution>();

            Func<int, int, double> f = (idx, xi) =>
            {
                idx += 1;
                if (xi == 0)
                    return 1.0 / 2 - 1.0 / idx;
                if (xi == 1)
                    return 1.0 / 3 + 1.5 / idx;
                throw new Exception("Invalid xi: " + xi);
            };

            Func<int[], double> HF = (x) =>
            {
                double result = 0;
                for(int i = 0; i < x.Length; i++)
                {
                    double incre = 1;
                    for(int j = 0; j < x.Length; j++)
                    {
                        incre *= ( j == i ? f(j, x[j]) : 1 - f(j, x[j]) );
                    }
                    result += incre;
                }
                return result;
            };

            Func<int[], double> LF = (x) =>
            {
                double result = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    result += f(i, x[i]);
                }
                return result;
            };


            for (int i = 0; i < 1024; i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(10, '0');
                char[] chars = binary.ToArray();
                int[] x = new int[10];
                for(int j = chars.Length - 1; j > chars.Length - 11; j--)
                {
                    int idx = chars.Length - j - 1;
                    x[idx] = chars[j] - '0';
                }
                double hf = HF(x);
                double lf = LF(x);
                res.Add(new Solution()
                {
                    HFValue = hf,
                    LFValue = lf
                });
            }
            return RankAndSort(res);
        }

        public static IReadOnlyCollection<SolutionMultiF> Xu2014MultiF()   //Uses G2 and G3
        {
            List<SolutionMultiF> res = new List<SolutionMultiF>();
            List<Solution> sols = Xu2014(2);
            sols.ForEach(s =>
            {
                SolutionMultiF ss = new SolutionMultiF(s.HFValue, s.HFRank, 2, s.LFRank);
                ss.lfs[0] = new SolutionSingleF(s.HFValue, s.HFRank, s.LFValue + 2, s.LFRank);
                res.Add(ss);
            });

            
            var solsAnother = Xu2014(3);
            solsAnother.ForEach(s =>
            {
                res.Find(ss => ss.yRank == s.HFRank).lfs[1] = new SolutionSingleF(s.HFValue, s.HFRank, s.LFValue - 2, s.LFRank);
            });

            var r = res.OrderBy(s => s.lfs[0].xRank).ToList().AsReadOnly();
            return r;
            //return res.OrderBy(s => s.lfs[0].xRank).ToList();
        }

        public static int SampleAmong(double[] probas)
        {
            double target = rand.NextDouble() * probas.Sum();
            int counter = -1;
            while(target > 0)
            {
                counter++;
                target -= probas[counter];
            }
            return counter;
        }

        public static void printToFile(string path, double[] probas)
        {
            File.AppendAllText(path, string.Join(",", probas) + '\n');
        }

        public static List<Solution> example(bool usingOT)
        {
            var solutions = new List<Solution>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            String input_grid = File.ReadAllText(path);
            var rows = input_grid.Split('\n');
            foreach (var row in rows)
            {
                var line = row.Trim('\r');
                var arr = line.Split('\t');
                var x = arr[0];
                var lf = arr[1];
                var hf = arr[2];
                solutions.Add(new Solution
                {
                    HFValue = Double.Parse(hf),
                    LFValue = Double.Parse(usingOT ? lf : x)
                });
            }

            return RankAndSort(solutions);
        }


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
                    HFValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * x), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2)) + 
                            0.1 * Math.Cos(0.5 * Math.PI * x) + 0.5 * Math.Pow((x - 40) / 60, 2) + 0.4 * Math.Sin((x + 10) / 100 * Math.PI)),
                    LFValue = lfValue,
                });
            }
            return RankAndSort(solutions);
        }

        public static List<Solution> Test()
        {
            var solutions = new List<Solution>();
            for (var x = 0.0; x <= 10; x += 0.1)
            {
                double lfValue = 0;
                lfValue = -(Math.Pow(Math.Sin(0.09 * Math.PI * x), 6) / Math.Pow(2, 2 * Math.Pow((x - 10) / 80, 2)));
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

        //Global Minimum at x = 420.9687 when size = 500
        public static List<Solution> Schwefel(int size = 500)
        {
            Random rand = new Random();
            var solutions = new List<Solution>();
            for (var x = 0; x < size; x+=1)
            {
                double LfValue = x;
                double HfValue = 418.9829 * 2 - x * Math.Sin(Math.Sqrt(x)) - x * Math.Sin(Math.Sqrt(x));
                solutions.Add(new Solution
                {
                    HFValue = HfValue,
                    LFValue = LfValue,
                });
                /*
                for(var y = 0; y < size; y+=10)
                {
                    var newX = (0.9 * x + 0.1 * x * rand.NextDouble());
                    var newY = (0.9 * y + 0.1 * y * rand.NextDouble());
                    double HfValue = 418.9829 * 2 - x * Math.Sin(Math.Sqrt(x)) - y * Math.Sin(Math.Sqrt(y));
                    double LfValue = 418.9829 * 2 - newX * Math.Sin(Math.Sqrt(newX)) - 
                        newY * Math.Sin(Math.Sqrt(newY));
                    solutions.Add(new Solution
                    {
                        HFValue = HfValue,
                        LFValue = LfValue,
                    });
                }*/
            }
            return RankAndSort(solutions);
        }

        //Global Minimum at x = 0.898 and y = -7.126
        public static List<Solution> SixHumpCamel()
        {
            var solutions = new List<Solution>();
            for (double x = -30; x < 30; x += 0.8)
            {
                for (double y = -20; y < 20; y += 0.8)
                {
                    double HfValue = (4 - 2.1 * x * x + Math.Pow(x, 4)) * x * x + x * y + (4 * y * y - 4) * y * y;
                    double LfValue = (4 - (int)(2.1 * x * x) + Math.Pow(x, 2)) * x * x + (int)(x * y) + (int)(4 * y * y - 4) * y * y;
                    solutions.Add(new Solution
                    {
                        HFValue = HfValue,
                        LFValue = LfValue,
                    });
                }
            }
            return RankAndSort(solutions);
        }

        //Minimum at x = y = 0
        public static List<Solution> Rastrigin()
        {
            var solutions = new List<Solution>();
            for (double x = -5.2; x < 5.2; x += 0.2)
            {
                for (double y = -5.2; y < 5.2; y += 0.2)
                {
                    double HfValue = 20 + (x * x - 10 * Math.Cos(2 * Math.PI * x)) + (y * y - 10 * Math.Cos(2 * Math.PI * y));
                    double LfValue = 20 + (x * y - 8 * Math.Cos(Math.PI * x)) + (y * x - 7 * Math.Cos(2 * Math.PI * y));
                    //var z = 0.5 + x;
                    //double LfValue = 20 + ((int)(z * x) - 10 * Math.Cos(1.9 * 3 * z)) + ((int)(z * y) - 10 * Math.Cos(2.2 * 3 * y));
                    //double LfValue = 20 + (x * x - 10 * Math.Cos(2 * 3 * x)) + (y * y - 10 * Math.Cos(2 * 3 * y));
                    solutions.Add(new Solution
                    {
                        HFValue = HfValue,
                        LFValue = LfValue,
                    });
                }
            }
            return RankAndSort(solutions);
        }

        //
        public static List<Solution> GramacyLee()
        {
            var solutions = new List<Solution>();
            for (double x = 0.5; x < 2.5; x += 0.005)
            {
                double HfValue = Math.Sin(10 * Math.PI * x) / 2 / x + Math.Pow((x - 1), 4);
                double LfValue = Math.Sin(5 * Math.PI * x) / 2 / x + Math.Pow((x - 1), 4);
                solutions.Add(new Solution
                {
                    HFValue = HfValue,
                    LFValue = LfValue,
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
            if (lfOrder.Count < 2) return 0;
            int numer = 0;
            for (int i = 1; i < lfOrder.Count; i++)
                for (int j = 0; j < i; j++)
                    numer = numer + Math.Sign(lfOrder[i] - lfOrder[j]);
            if(!normalize)
                return (double)numer;
            else return 1.0 * numer / lfOrder.Count / (lfOrder.Count - 1) * 2;
        }

        public static void exportSolutionsToExcel(List<Solution> sols, string name)
        {
            sols = sols.OrderBy(s => s.LFRank).ToList();
            foreach(Solution s in sols)
            {
                string line = s.LFRank + "," + s.LFValue + "," + s.HFRank + "," + s.HFValue;

                using (var sw = new StreamWriter(name + ".csv", true)) sw.WriteLine(line);
            }
        }

        public static void exportExcel(List<Solution> sols, string name)
        {
            Random r = new Random();
            sols = sols.OrderBy(s => s.LFRank).ToList();
            foreach(Solution sol in sols)
            {
                List<int> left = sols.Where(s => s.LFRank <= sol.LFRank).Select(s => s.HFRank).ToList();
                List<int> right = sols.Where(s => s.LFRank >= sol.LFRank).Select(s => s.HFRank).ToList();
                Double leftK = - KendallRank(left, true);
                Double rightK = KendallRank(right, true);
                Double K = (leftK + rightK) / 2;

                string line;
                /*
                if (r.NextDouble() < 0.03) //sampled
                    line = sol.LFRank + ",," + sol.HFRank + "," + leftK + "," + rightK + "," + K;
                else line = sol.LFRank + "," + sol.HFRank + ",," + leftK + "," + rightK + "," + K;*/
                if (r.NextDouble() < 0.02)
                    line = sol.LFRank + "," + sol.HFRank + ",," + K;
                else
                    line = sol.LFRank + ",," + sol.HFRank + "," + K;
                sol.proba = K;

                /*
                if(sol2 == null)
                {
                    sol2 = sol;
                } else if (sol1 == null)
                {
                    sol1 = sol;
                    previousLine = line;
                } else
                {
                    if(sol2.proba < sol1.proba && sol.proba < sol1.proba)
                    {
                        //we have a local max!
                        if (sol2.HFRank > sol1.HFRank && sol.HFRank > sol1.HFRank)
                        {
                            previousLine += ",1";
                            good++;
                        }
                        else
                        {
                            bad++;
                            previousLine += ",0";
                        }
                    }
                    using (var sw = new StreamWriter(name + ".csv", true)) sw.WriteLine(previousLine);
                    previousLine = line;
                    sol2 = sol1;
                    sol1 = sol;
                }*/



                using (var sw = new StreamWriter(name + ".csv", true)) sw.WriteLine(line);
            }
            //using (var sw = new StreamWriter(name + ".csv", true)) sw.WriteLine(good +","+ bad);

        }

        public static void exportExcel<T>(string fileName, params List<T>[] lists)
        {
            int length = lists[0].Count;
            if (!lists.All(l => l.Count == length))
                throw new Exception("All lists must have same length! ");

            var arr = new List<String>();
            for(int i = 0; i < length; i++)
            {
                string s = "";
                for (int j = 0; j < lists.Length; j++)
                    s += "," + lists[j].ElementAt(i).ToString();
                arr.Add(s);
            }

            File.WriteAllLines(fileName, arr);
        }

        public static double InvNormal(Double x, Double mean = 0, Double stddev = 1)
        {
            return Normal.InvCDF(mean, stddev, x);
        }

        public static double InvChiSquare(Double dof, Double x)
        {
            return ChiSquared.InvCDF(dof, x);
        }
    }
}
