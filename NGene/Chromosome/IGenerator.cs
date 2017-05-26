namespace NGene.Chromosome
{
    public interface IGenerator<out T>
    {
        T New();
    }
}