namespace NGene.Chromosome
{
    public interface IChromosomeGenerator<T>
    {
        IChromosome<T> New();
        IChromosomeGenerator<T> OfLength(int length);
        IChromosomeGenerator<T> WithGenerator(IGenerator<T> generator);
    }
}