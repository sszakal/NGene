using System;

namespace NGene.Random
{
    public class NormalDistribution : System.Random, IRandomProvider
    {
        private readonly double _zscore;

        public NormalDistribution(double zscore, int seed = 0) : base(seed)
        {
            _zscore = zscore;
        }

        public override double NextDouble()
        {
            return 1 / Math.Sqrt(2 * Math.PI) * Math.Exp(-(_zscore * _zscore) / 2);
        }
    }
}
