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
    static class Controller
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
        private static Algorithm algo;
        
        //Called when initialize is clicked

        public static void Initialize(Form1 form, Chart graph_r, Chart graph_a)
        {
            f = form;

            //set up rank graph
            graph_rank = graph_r;
            graph_avg = graph_a;
            //var solutions = Utility.Rastrigin();
            //var solutions = Utility.SixHumpCamel();
            var solutions = Utility.Schwefel();
            //var solutions = Utility.Xu2014(g : 2);
            //var solutions = Utility.GramacyLee();
            //var solutions = Utility.localMin();
            algo = new MinSeeker(10);
            //algo = new MO2TOS(10);
            algo.initialize(solutions);
            updateRankPoints();
            /*
            var sol1 = Utility.Xu2014(1);
            var sol2 = Utility.Xu2014(2);
            var sol3 = Utility.Xu2014(3);
            var res = "";
            res += Utility.hasMinKendallAtOptimum(solutions) + "\n";
            res += Utility.hasMinKendallAtOptimum(sol1) + "\n";
            res += Utility.hasMinKendallAtOptimum(sol2) + "\n";
            res += Utility.hasMinKendallAtOptimum(sol3) + "\n";
            System.Windows.Forms.MessageBox.Show(res);*/
        }

        //Called repeatedly after Initialize
        public static void Iterate()
        {
            algo.iterate();
            updateRankPoints();
        }

        public static void evaluatePerformance()
        {
            
            //evaluateFunction(Utility.Xu2014(g: 1), "Compare_Xu2014G1");
            //evaluateFunction(Utility.Xu2014(g: 2), "Compare_Xu2014G2");
            //evaluateFunction(Utility.Xu2014(g: 3), "Compare_Xu2014G3");
            //evaluateFunction(Utility.localMin(), "Compare_localMin");
            //evaluateFunction(Utility.Schwefel(), "Compare_Schwefel");
            
            //evaluateFunction(Utility.SixHumpCamel(), "Compare_SixHumpCamel");
            //evaluateFunction(Utility.Rastrigin(), "Compare_Rastrigin");
        }

        //Compare MO2TOS and US
        public static void evaluateFunction(List<Solution> sols, String fileName, int groupNumbers = 10)
        {
            int totalIteration = 300;
            int samplePerIter = 60;

            Algorithm mo2tos = new MO2TOS(groupNumbers);
            Algorithm minSeeker = new MinSeeker(groupNumbers);
            mo2tos.initialize(sols);
            minSeeker.initialize(sols);
            var results1 = new double[samplePerIter];
            var results2 = new double[samplePerIter];

            //Testing Stage
            for (int i = 0; i < totalIteration; i++)
            {
                mo2tos.resetIteration();
                minSeeker.resetIteration();
                for (int j = 0; j < samplePerIter; j++)
                {
                    results1[j] += mo2tos.optimum.HFValue;
                    results2[j] += minSeeker.optimum.HFValue;
                    mo2tos.iterate();
                    minSeeker.iterate();
                }
            }

            String header = "Names: ," + "MO2TOS" + "," + "MinSeeker";// + "," + results3[i];
            using (var sw = new StreamWriter(fileName + ".csv", true)) sw.WriteLine(header);
            for (int i = 0; i < samplePerIter; i++)
            {
                results1[i] /= totalIteration;
                results2[i] /= totalIteration;
                String newLine = (i + groupNumbers*2 + 1) + "," + results1[i] + "," + results2[i];// + "," + results3[i];
                using (var sw = new StreamWriter(fileName + ".csv", true)) sw.WriteLine(newLine);
            }
        }


        private static void updateRankPoints()
        {
            //using (var sw = new StreamWriter("Optimal.csv", true)) sw.WriteLine(otvs.Optimum.HFValue);
            Series otherPoints = graph_rank.Series.Where(x => x.Name == "Ranks").ToList().First();
            otherPoints.Points.Clear();
            Series sampled = graph_rank.Series.Where(x => x.Name == "Sampled").ToList().First();
            sampled.Points.Clear();
            Series newPoints = graph_rank.Series.Where(x => x.Name == "Filter").ToList().First();
            newPoints.Points.Clear();
            Series proba = graph_rank.Series.Where(x => x.Name == "ProbaValue").ToList().First();
            proba.Points.Clear();
            foreach (var i in Enumerable.Range(0, algo.solutions.Count))
            {
                DataPoint dp = new DataPoint(algo.solutions[i].LFRank, algo.solutions[i].HFRank);
                int lf = algo.solutions[i].LFRank;
                //For Proba Lines
                if(algo.solutions[i].proba > 0)
                {
                    DataPoint p = new DataPoint(lf, algo.solutions[i].proba);
                    proba.Points.Add(p);
                }
                //For Data Points
                if (algo.lfNewlySampled.Contains(lf))
                {
                    dp.MarkerSize = 15;
                    dp.MarkerColor = System.Drawing.Color.Violet;
                    dp.MarkerStyle = MarkerStyle.Diamond;
                    newPoints.Points.Add(dp);
                }
                else if(algo.lfSampled.Contains(lf))
                    sampled.Points.Add(dp);
                else
                    otherPoints.Points.Add(dp);
            }
        }
    }
}
