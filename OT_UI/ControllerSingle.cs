using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace OT_UI
{
    static class ControllerSingle
    {
        public enum sl_Kendall { Min, Avg, Wtd };
        public static sl_Kendall selected_kendall = sl_Kendall.Min;
        public enum sl_Filter { None, Domi, Pncr };
        public static sl_Filter selected_filter = sl_Filter.None;
        public enum sl_Strategy { Det1, Det2, Tour, Kernel };
        public static sl_Strategy selected_strategy = sl_Strategy.Det1;

        public static int speed; //0-paused, 1-sample, 2-iteration, 3-grand_average

        private static Form1 f;
        //private static Thread iterator;
        private static Chart graph_rank;
        private static Chart graph_avg;
        private static Algorithm algo; // = new Gaussian();

        //Called when initialize is clicked

        public static void Initialize(Form1 form, Chart graph_r, Chart graph_a)
        {
            f = form;

            //set up rank graph
            graph_rank = graph_r;
            graph_avg = graph_a;

            /*
            var solutions = Utility.Xu2014(g : 2);
            algo = new GaussianSingle();
            algo.initialize(solutions);*/


            var solutions = Utility.Xu2014(2);
            algo = new GaussianSingle();
            algo.initialize(solutions);

            updateRankPoints();
        }

        //Called repeatedly after Initialize
        public static void Iterate()
        {
            algo.iterate();
            updateRankPoints();
        }

        public static void evaluatePerformance(IReadOnlyCollection<Solution> sols)
        {
            Algorithm gaussian = new GaussianSingle();
            Algorithm mo2tos20 = new MO2TOS(20);
            Algorithm mo2tos10 = new MO2TOS(10);
            Algorithm mo2tos5 = new MO2TOS(5);
            List<Algorithm> algo = new List<Algorithm>();
            //algo.Add(gaussian);
            algo.Add(mo2tos5);
            algo.Add(mo2tos10);
            algo.Add(mo2tos20);
            evaluateAlgorithm(algo, sols, "TestResult");
        }


        public static void evaluateAlgorithm(List<Algorithm> algos, IReadOnlyCollection<Solution> sols, string fileName)
        {
            //Configurable
            int totalIteration = 1000;
            int samplePerIter = 55;
            String header = "Names: ,";
            //"Names: ,MO2TOS(k=10), MO2TOS(k=20), MO2TOS(k=5), OTVS(p=2), OTVS(p=4), OTVS(p=6)";
            // + "MO2TOS" + "," + "MinSeeker" + "," + "PRIOR";// + "," + results3[i];
            Dictionary<Algorithm, double[]> algoResult = new Dictionary<Algorithm, double[]>();
            foreach (Algorithm algo in algos)
            {
                algo.initialize(sols.ToList());
                algoResult.Add(algo, new double[samplePerIter]);
                header += algo.getName() + ",";
            }

            //Testing Stage
            for (int i = 0; i < totalIteration; i++)
            {
                foreach (KeyValuePair<Algorithm, double[]> entry in algoResult)
                {
                    entry.Key.resetIteration();
                }
                for (int j = 0; j < samplePerIter; j++)
                {
                    foreach (KeyValuePair<Algorithm, double[]> entry in algoResult)
                    {
                        //*********  SnapShot ************

                        /*
                        if(j%10 == 0 && i == 0)
                        {
                            entry.Key.snapShot(fileName + " OTVS", j);
                        }*/

                        // Iteration
                        entry.Value[j] += entry.Key.optimum.HFValue;
                        entry.Key.iterate();
                    }
                }
            }

            using (var sw = new StreamWriter(fileName + ".csv", true)) sw.WriteLine(header);
            for (int i = 0; i < samplePerIter + 20; i++)
            {
                int iter = i + 1;
                String newLine = iter.ToString();
                foreach (KeyValuePair<Algorithm, double[]> entry in algoResult)
                {
                    int start = entry.Key.getStartingPoint();
                    if (iter >= start && iter - start < entry.Value.Length) // && iter <= samplePerIter)
                        newLine += "," + entry.Value[iter - start] / totalIteration;
                    else newLine += ",";
                }
                using (var sw = new StreamWriter(fileName + ".csv", true)) sw.WriteLine(newLine);
            }
        }

        private static void updateRankPoints()
        {
            //using (var sw = new StreamWriter("Optimal.csv", true)) sw.WriteLine(otvs.Optimum.HFValue);
            Series otherPoints_left = graph_rank.Series.Where(x => x.Name == "Ranks").ToList().First();
            otherPoints_left.Points.Clear();
            Series sampled_left = graph_rank.Series.Where(x => x.Name == "Sampled").ToList().First();
            sampled_left.Points.Clear();
            Series newPoints_left = graph_rank.Series.Where(x => x.Name == "Filter").ToList().First();
            newPoints_left.Points.Clear();
            Series proba_left = graph_rank.Series.Where(x => x.Name == "ProbaValue").ToList().First();
            proba_left.Points.Clear();
            Series upper_left = graph_rank.Series.Where(x => x.Name == "upper").ToList().First();
            upper_left.Points.Clear();
            Series lower_left = graph_rank.Series.Where(x => x.Name == "lower").ToList().First();
            lower_left.Points.Clear();

            Series c = graph_rank.Series.Where(x => x.Name == "c").ToList().First();
            c.Points.Clear();
            foreach (var i in Enumerable.Range(0, algo.solutions.Count))
            {
                /***** IMPORTANT: Plot by Rank OR Value *****/
                Solution s = algo.solutions.ElementAt(i);
                Double x = s.LFRank;
                //Double lf = algo.solutions[i].LFValue;


                DataPoint dp = new DataPoint(x, s.HFValue);
                //DataPoint dp = new DataPoint(algo.solutions[i].LFValue, algo.solutions[i].HFValue);

                //For Proba Lines
                if (algo.solutions.ElementAt(i).proba > 0)
                {
                    DataPoint p = new DataPoint(x, s.proba);
                    proba_left.Points.Add(p);
                }

                DataPoint upper = new DataPoint(x, s.a);
                upper_left.Points.Add(upper);
                DataPoint lower = new DataPoint(x, s.b);
                lower_left.Points.Add(lower);
                //For abc Lines
                /*
                if (Math.Abs(algo.solutions[i].b) > 0.0001)
                {
                    DataPoint aa = new DataPoint(x, algo.solutions[i].a);
                    a.Points.Add(aa);
                    DataPoint cc = new DataPoint(x, algo.solutions[i].c);
                    c.Points.Add(cc);
                    DataPoint bb = new DataPoint(x, algo.solutions[i].b);
                    b.Points.Add(bb);
                }*/

                //For Data Points
                if (algo.lastSampled == s)
                {
                    dp.MarkerSize = 15;
                    dp.MarkerColor = System.Drawing.Color.Violet;
                    dp.MarkerStyle = MarkerStyle.Diamond;
                    newPoints_left.Points.Add(dp);
                }
                else if (algo.solutionsSampled.Contains(s))
                    sampled_left.Points.Add(dp);
                else
                    otherPoints_left.Points.Add(dp);
            }
        }
    }
}
