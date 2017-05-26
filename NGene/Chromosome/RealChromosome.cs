namespace NGene.Chromosome
{
    public class RealChromosome : IChromosome<double>
    {
        private readonly double[] _genes;

        public double this[int index]
        {
            get => _genes[index];
            set => _genes[index] = value;
        }

        public int Length => _genes.Length;

        public double[] Genes => _genes.Clone() as double[];

        private RealChromosome(double[] genes)
        {
            _genes = genes;
        }

        public class ChromosomeGenerator : IChromosomeGenerator<double>
        {
            private int _length;
            private IGenerator<double> _generator;

            public IChromosomeGenerator<double> OfLength(int length)
            {
                _length = length;
                return this;
            }

            public IChromosomeGenerator<double> WithGenerator(IGenerator<double> generator)
            {
                _generator = generator;
                return this;
            }

            public IChromosome<double> New()
            {
                double[] genes = new double[_length];

                for (var i = 0; i < _length; i++)
                {
                    genes[i] = _generator.New();
                }

                return new RealChromosome(genes);
            }
        }
    }
}