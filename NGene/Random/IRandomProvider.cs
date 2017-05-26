namespace NGene.Random
{
    public interface IRandomProvider
    {
        int Next();
        int Next(int minValue, int maxValue);
        int Next(int maxValue);
        void NextBytes(byte[] buffer);
        double NextDouble();
    }
}
