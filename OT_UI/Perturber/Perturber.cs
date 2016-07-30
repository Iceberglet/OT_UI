using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_UI
{
    //All perturbers are supposed to perturb 1/4 of the max value ON AVERAGE
    public class Perturber
    {
        public virtual IList<Solution> perturb(IList<Double> highFValues)
        {
            return null;
        }

        IList<Solution> perturb(IList<Solution> alreadyDone)
        {
            return perturb((IList<Solution>)alreadyDone.Select(s => s.LFValue));
        }
    }

    public class RandomPerturber : Perturber
    {
        Double max;
        Random r = new Random(1);

        public override IList<Solution> perturb(IList<Double> hf)
        {
            this.max = hf.Max(v => Math.Abs(v)) / 2;
            List<Solution> res = new List<Solution>();
            foreach (var v in hf)
            {
                var perturb = (r.NextDouble() - 0.5) * max;
                res.Add(new Solution {
                                        HFValue = v,
                                        LFValue = v + perturb
                                     });
            }
            return res;
        }
    }

    public class GuassianPerturber : Perturber
    {
        Double max;
        Random r = new Random(2);

        public override IList<Solution> perturb(IList<Double> hf)
        {
            this.max = hf.Max(v => Math.Abs(v)) / 2;
            List<Solution> res = new List<Solution>();
            foreach (var v in hf)
            {
                double u1 = r.NextDouble(); //these are uniform(0,1) random doubles
                double u2 = r.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                double perturb = max * randStdNormal; //random normal(mean,stdDev^2)
                res.Add(new Solution
                {
                    HFValue = v,
                    LFValue = v + perturb
                });
            }
            return res;
        }
    }

    //TODO:
    public class FavourOptimal : Perturber
    {
        Double max;
        Random r = new Random(2);

        public override IList<Solution> perturb(IList<Double> hf)
        {
            this.max = hf.Max(v => Math.Abs(v)) / 2;
            List<Solution> res = new List<Solution>();
            foreach (var v in hf)
            {
                double u1 = r.NextDouble(); //these are uniform(0,1) random doubles
                double u2 = r.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                double perturb = max * randStdNormal; //random normal(mean,stdDev^2)
                res.Add(new Solution
                {
                    HFValue = v,
                    LFValue = v + perturb
                });
            }
            return res;
        }
    }
}
