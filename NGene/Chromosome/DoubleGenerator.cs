using NGene.Random;

namespace NGene.Chromosome
{
    public class DoubleGenerator : IGenerator<double>
    {
        private readonly IRandomProvider _random;
        private readonly int _maxValue;
        private readonly int _minValue;

        public DoubleGenerator(IRandomProvider randomProvider, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _random = randomProvider;
        }

        public double New()
        {
            return _random.NextDouble() * (_maxValue - _minValue) + _minValue;
        }
    }
}