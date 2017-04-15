using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace OT_UI
{
    public class MO2TOS_2 : MO2TOS
    {
        public MO2TOS_2(int groups, SamplingScheme scheme) : base(groups, scheme)
        {
        }

        protected double[] OCBARatios
        {
            get
            {
                var hfValues = solutionGroups.Select(g => g.Where(s => solutionsSampled.Contains(s)).Select(s => s.HFValue).ToList()).ToList();
                var means = hfValues.Select(g => g.Mean() - 2 * g.StandardDeviation()).ToArray();  //Changed only this line
                var stddevs = hfValues.Select(g => g.StandardDeviation()).ToArray();

                var indices = Enumerable.Range(0, means.Count()).ToList();
                var min = means.Min();
                var minIndices = indices.Where(i => means[i] == min).ToArray();
                if (minIndices.Count() < indices.Count())
                {
                    var ratios = indices.Select(i => Math.Pow(stddevs[i] / (means[i] - min), 2)).ToArray();
                    foreach (var i in minIndices) ratios[i] = stddevs[i] * Math.Sqrt(indices.Except(minIndices).Sum(j => Math.Pow(ratios[j] / stddevs[j], 2)));
                    var sum = ratios.Sum();
                    return ratios.Select(r => r / sum).ToArray();
                }
                return Enumerable.Repeat(1.0 / indices.Count, indices.Count).ToArray();
            }
        }
    }
}
