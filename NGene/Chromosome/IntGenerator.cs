using NGene.Random;

namespace NGene.Chromosome
{
    public class IntGenerator : IGenerator<int>
    {
        private readonly IRandomProvider _random;
        private readonly int _maxValue;
        private readonly int _minValue;

        public IntGenerator(IRandomProvider randomProvider, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _random = randomProvider;
        }

        public int New()
        {
            return _random.Next(_minValue, _maxValue);
        }
    }
}