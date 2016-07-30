using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public class Evaluator
    {
        public static List<Algorithm> algorithms;
        public static List<List<Solution>> tests;

        public void populateCandidates()
        {
            algorithms = new List<Algorithm>();
            tests = new List<List<Solution>>();
            algorithms.Add(new MO2TOS(10, MO2TOS.SamplingScheme.Hybrid));
            algorithms.Add(new MO2TOS_2(10, MO2TOS.SamplingScheme.Hybrid));

            tests.Add(Utility.GramacyLee());
            tests.Add(Utility.Griewank());
            tests.Add(Utility.Rastrigin());
            tests.Add(Utility.Schwefel());
            tests.Add(Utility.SixHumpCamel());
            tests.Add(Utility.Xu2014(1));
            tests.Add(Utility.Xu2014(2));
            tests.Add(Utility.Xu2014(3));
        }

        public void evaluate()
        {
            int totalIteration = 30;
            int samplePerIter = 60;

            double[,] resOfAlgoByIter = new double[algorithms.Count * tests.Count, samplePerIter];

            for(int x = 0; x < algorithms.Count; x++)
            {
                Algorithm algo = algorithms.ElementAt(x);
                for (int y = 0; y < tests.Count; y++)
                {
                    List<Solution> solutions = tests.ElementAt(y);
                    int idx = x * tests.Count + y;
                    for (int i = 0; i < totalIteration; i++)
                    {
                        algo.initialize(solutions);
                        for (int j = 0; j < samplePerIter; j++)
                        {
                            algo.iterate();
                            resOfAlgoByIter[idx, j] += algo.optimum.HFValue;
                        }
                    }
                }
            }
            //String header = "Names: ," + "OTVS_simple" + "," + "Kernel+Domi";// + "," + results3[i];
            //using (var sw = new StreamWriter("test.csv", true)) sw.WriteLine(header);
            /*
            for (int i = 0; i < samplePerIter; i++)
            {
                result[i] /= totalIteration;
                String newLine = (i + 3) + "," + results1[i] + "," + results2[i];// + "," + results3[i];
                using (var sw = new StreamWriter("test.csv", true)) sw.WriteLine(newLine);
            }
            */
        }
    }
}
