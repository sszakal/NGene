namespace NGene
{
    interface ISelector
    {
        Population<TG> Select<TG>(Population<TG> population,int count, Optimize opt);
    }
}
