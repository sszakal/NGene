using System.Collections.Generic;
using System.Linq;

namespace NGene.Chromosome
{
    public partial class BinaryChromosome: IChromosome<bool>
    {
        private readonly int[] _genes;
        private readonly int _length;

        public bool this[int index]
        {
            get => (_genes[index / sizeof(int)] & (1 << index % sizeof(int))) > 0;
            set 
            {
                if (value) _genes[index / sizeof(int)] |= 1 << index % sizeof(int);
                else _genes[index / sizeof(int)] &= ~(1 << index % sizeof(int));
            }
        }

        public int Length => _length;

        public bool[] Genes => AsBool().ToArray();

        private IEnumerable<bool> AsBool()
        {
            for (var i = 0; i < _genes.Length; i++)
                for (var j = 0; j < sizeof(int); j++)
                    yield return (_genes[i] & (1 << j)) > 0;
        }

        private BinaryChromosome(bool[] genes)
        {
            _length = genes.Length;
            _genes = new int[_length / sizeof(int) + (_length % sizeof(int)>0?1:0)];
            for(var i = 0; i < _genes.Length; i++)
                for (var j = 0; j < sizeof(int); j++)
                {
                    if (sizeof(int) * i + j >= genes.Length) break;
                    if(!genes[sizeof(int) * i + j]) continue;
                    _genes[i] |= 1 << j;
                }
        }

        public class ChromosomeGenerator : IChromosomeGenerator<bool>
        {
            private int _length;
            private IGenerator<bool> _generator;

            public IChromosomeGenerator<bool> OfLength(int length)
            {
                _length = length;
                return this;
            }

            public IChromosomeGenerator<bool> WithGenerator(IGenerator<bool> generator)
            {
                _generator = generator;
                return this;
            }

            public IChromosome<bool> New()
            {
                var genes = new bool[_length];

                for (var i = 0; i < _length; i++)
                {
                    genes[i] = _generator.New();
                }

                return new BinaryChromosome(genes);
            }
        }
    }
}