using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    public class SolutionMultiF
    {
        public readonly int idx;        //Only used by plotter to make graph nicer. Essentially same to one of fidelity rank
        public readonly double y;
        public readonly int yRank;
        public SolutionSingleF[] lfs { get; private set; }
        public double proba; // { get; private set; }
        public double upper; // { get; private set; }
        public double lower; // { get; private set; }

        public SolutionMultiF(double y, int yRank, int fidelities, int idx)
        {
            this.idx = idx;
            this.y = y;
            this.yRank = yRank;
            this.lfs = new SolutionSingleF[fidelities];
        }
    }

    public class SolutionSingleF
    {
        public readonly double y;
        public readonly int yRank;
        public readonly double x;
        public readonly int xRank;

        public SolutionSingleF(double y, int yRank, double x, int xRank)
        {
            this.y = y;
            this.yRank = yRank;
            this.x = x;
            this.xRank = xRank;
        }
    }
}
