using System;
using System.IO;
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
        public double proba { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
    }

    public abstract class Algorithm
    {
        protected static Random rand = new Random(0);

        public List<Solution> solutions { protected set; get; }
        public HashSet<Solution> solutionsSampled;
        public Solution lastSampled;
        public List<int> lfSampled { get { return solutionsSampled.Select(s => s.LFRank).ToList(); } }
        public List<int> lfNewlySampled { get; protected set; }
        

        public Solution optimum { get { return solutionsSampled.OrderBy(s => s.HFValue).First(); } }

        public Algorithm()
        {
        }

        public virtual void initialize(List<Solution> solutions)
        {
            this.solutions = solutions.OrderBy(s => s.LFValue).ToList();
            this.solutionsSampled = new HashSet<Solution>();
            this.lfNewlySampled = new List<int>();
        }

        protected void sample(Solution s)
        {
            solutionsSampled.Add(s);
            lfNewlySampled.Clear();
            lfNewlySampled.Add(s.LFRank);
            lastSampled = s;
        }

        public abstract void resetIteration();

        public abstract bool iterate();

        public virtual void snapShot(string name, int tryNo)
        {
            String header = "Legend:, Lower, Higher, Probability, Unsampled, Sampled, Last Sample";
            using (var sw = new StreamWriter("SnapChat" + name + "_try_" + tryNo + ".csv", true)) sw.WriteLine(header);
            foreach (Solution s in solutions)
            {
                string newLine = s.LFRank + "," + s.a + "," + s.b + "," + (s.proba > 0 ? s.proba.ToString() : "") + "," ;
                //Datapoint, Sampled, LastSampled
                if (s == lastSampled)
                {
                    newLine += ",," + s.HFValue;
                }
                else if (solutionsSampled.Contains(s))
                {
                    newLine += "," + s.HFValue;
                } else
                {
                    newLine += s.HFValue;
                }
                using (var sw = new StreamWriter("SnapChat" + name + "_try_" + tryNo + ".csv", true)) sw.WriteLine(newLine);
            }
        }

        public virtual int getStartingPoint()
        {
            return 1;
        }

        public virtual string getName()
        {
            return "ForgotToName";
        }
        
    }
}
