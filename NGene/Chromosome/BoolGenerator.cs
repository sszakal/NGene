using NGene.Random;

namespace NGene.Chromosome
{
    public class BoolGenerator : IGenerator<bool>
    {
        private readonly IRandomProvider _random;

        public BoolGenerator(IRandomProvider randomProvider)
        {
            _random = randomProvider;
        }

        public bool New()
        {
            return _random.NextDouble() < 0.5;
        }
    }
}