namespace NGene.Chromosome
{
    public class IntegerChromosome: IChromosome<int>
    {
        private readonly int[] _genes;

        public int this[int index]
        {
            get => _genes[index];
            set => _genes[index] = value;
        }

        public int Length => _genes.Length;

        public int[] Genes => _genes.Clone() as int[];

        private IntegerChromosome(int[] genes)
        {
            _genes = genes;
        }

        public class ChromosomeGenerator : IChromosomeGenerator<int>
        {
            private int _length;
            private IGenerator<int> _generator;

            public IChromosomeGenerator<int> OfLength(int length)
            {
                _length = length;
                return this;
            }

            public IChromosomeGenerator<int> WithGenerator(IGenerator<int> generator)
            {
                _generator = generator;
                return this;
            }

            public IChromosome<int> New()
            {
                var genes = new int[_length];

                for (var i = 0; i < _length; i++)
                {
                    genes[i] = _generator.New();
                }

                return new IntegerChromosome(genes);
            }
        }
    }
}