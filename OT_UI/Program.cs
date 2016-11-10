using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace OT_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            

            //Controller.evaluateFunction(Utility.Xu2014MultiF(), "Test");

            //Utility.exportExcel(Utility.Xu2014(3), "XuEtAlG3");

            /*
            OTVS otvs = new OTVS(4);
            otvs.initialize(Utility.localMin());
            otvs.printCorrelationCoefficient();
            */

            //Controller.evaluatePerformance();

            //testChi();
        }

        static void testChi()
        {
            int totalSamples = 10000;
            int n = 5;

            Random rand = new Random();
            List<Double> values = new List<Double>();

            for(int i = 0; i < totalSamples; i++)
            {
                //Generate a sample of 20 items from normal
                double[] samples = new double[n];
                for(int j = 0; j < n; j++)
                {
                    samples[j] = Normal.Sample(0, 1);
                }
                double mean = Statistics.Mean(samples);
                double stddev = Statistics.StandardDeviation(samples);
                double meanMinusS = mean - 2 * stddev;
                using (var sw = new StreamWriter("testChi.csv", true)) sw.WriteLine(mean + "," + stddev + "," + meanMinusS);
            }

        }
    }
}
