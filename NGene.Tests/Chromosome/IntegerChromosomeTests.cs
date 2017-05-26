using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NGene.Chromosome;

namespace NGene.Tests.Chromosome
{
    [TestClass]
    public class IntegerChromosomeTests
    {
        private IChromosomeGenerator<int> _chromosomeGenerator;
        private Mock<IGenerator<int>> _integerChromosomeGeneratorMock;

        [TestInitialize]
        public void Init()
        {
            _integerChromosomeGeneratorMock = new Mock<IGenerator<int>>();
            _chromosomeGenerator = new IntegerChromosome.ChromosomeGenerator().WithGenerator(_integerChromosomeGeneratorMock.Object);
        }

        [TestMethod]
        public void ShouldGenerateRandomChromosome()
        {
            _integerChromosomeGeneratorMock.SetupSequence(m => m.New()).Returns(1)
                                                                    .Returns(2)
                                                                    .Returns(3)
                                                                    .Returns(4);
            var chromosome =  _chromosomeGenerator.OfLength(4).New();
            Assert.AreEqual(4, chromosome.Length);
            CollectionAssert.AreEqual(new [] { 1, 2, 3, 4}, chromosome.Genes.ToArray());
        }

        [TestMethod]
        public void ShouldGetAndSetGenes()
        {
            _integerChromosomeGeneratorMock.Setup(m => m.New()).Returns(1);
            var chromosome =  _chromosomeGenerator.OfLength(3).New();
            chromosome[0] = 3;
            chromosome[1] = 2;
            chromosome[2] = 1;
            
            Assert.AreEqual(3, chromosome[0]);
            Assert.AreEqual(2, chromosome[1]);
            Assert.AreEqual(1, chromosome[2]);
        }
    }
}
