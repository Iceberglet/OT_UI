using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace OT_UI
{
    public abstract class AlgorithmMultiF
    {
        public IReadOnlyCollection<SolutionMultiF> solutions { get; protected set; }
        public List<SolutionMultiF> sampled { get; protected set; }
        public SolutionMultiF lastSample;
        protected readonly static Random rand = new Random();

        //The one with MINIMUM y value
        public SolutionMultiF optimum { get { return sampled.Aggregate((agg, next) => next.y < agg.y ? next : agg); } }

        public AlgorithmMultiF(IReadOnlyCollection<SolutionMultiF> sols)
        {
            this.solutions = sols;
        }

        public virtual void initialize()
        {
            this.sampled = new List<SolutionMultiF>();
        }

        protected virtual void sample(SolutionMultiF s)
        {
            this.sampled.Add(s);
            lastSample = s;
        }

        public virtual bool iterate()
        {
            //Decide which solution to sample according to multiple data provider
            return false;
        }

        public virtual void resetIteration()
        {
            throw new NotImplementedException();
        }

        public virtual int getStartingPoint()
        {
            return 1;
        }

        public abstract string getName();
    }
}
