namespace NGene.Chromosome
{
    public interface IChromosome<T>
    {
        T this[int index] { get; set; }
        int Length { get; }
        T[] Genes { get; }
    }
}