using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NGene.Chromosome;

namespace NGene.Tests.Chromosome
{
    [TestClass]
    public class BinaryChromosomeTests
    {
        private IChromosomeGenerator<bool> _chromosomeGenerator;
        private Mock<IGenerator<bool>> _boolChromosomeGeneratorMock;

        [TestInitialize]
        public void Init()
        {
            _boolChromosomeGeneratorMock = new Mock<IGenerator<bool>>();
            _chromosomeGenerator = new BinaryChromosome.ChromosomeGenerator().WithGenerator(_boolChromosomeGeneratorMock.Object);
        }

        [TestMethod]
        public void ShouldGenerateRandomChromosome()
        {
            _boolChromosomeGeneratorMock.SetupSequence(m => m.New()).Returns(true)
                                                                    .Returns(false)
                                                                    .Returns(true)
                                                                    .Returns(false);
            var chromosome =  _chromosomeGenerator.OfLength(4).New();
            Assert.AreEqual(4, chromosome.Length);
            CollectionAssert.AreEqual(new [] { true, false, true, false}, chromosome.Genes.ToArray());
        }

        [TestMethod]
        public void ShouldGetAndSetGenes()
        {
            _boolChromosomeGeneratorMock.Setup(m => m.New()).Returns(true);
            var chromosome =  _chromosomeGenerator.OfLength(3).New();
            chromosome[0] = true;
            chromosome[1] = false;
            chromosome[2] = true;
            Assert.AreEqual(3, chromosome.Length);
            Assert.AreEqual(true, chromosome[0]);
            Assert.AreEqual(false, chromosome[1]);
            Assert.AreEqual(true, chromosome[2]);
        }
    }
}
