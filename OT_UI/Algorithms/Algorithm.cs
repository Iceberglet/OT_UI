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
        public double proba { get; set; }
    }

    public abstract class Algorithm
    {
        protected static Random rand = new Random(0);

        public List<Solution> solutions { protected set; get; }
        protected HashSet<Solution> solutionsSampled;
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
            lfNewlySampled.Add(s.LFRank);
        }

        public abstract void resetIteration();

        public abstract bool iterate();
    }
}
