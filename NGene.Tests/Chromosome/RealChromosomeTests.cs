using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NGene.Chromosome;

namespace NGene.Tests.Chromosome
{
    [TestClass]
    public class RealChromosomeTests
    {
        private IChromosomeGenerator<double> _chromosomeGenerator;
        private Mock<IGenerator<double>> _doubleChromosomeGeneratorMock;

        [TestInitialize]
        public void Init()
        {
            _doubleChromosomeGeneratorMock = new Mock<IGenerator<double>>();
            _chromosomeGenerator = new RealChromosome.ChromosomeGenerator().WithGenerator(_doubleChromosomeGeneratorMock.Object);
        }

        [TestMethod]
        public void ShouldGenerateRandomChromosome()
        {
            _doubleChromosomeGeneratorMock.SetupSequence(m => m.New()).Returns(1.1)
                                                                    .Returns(2.2)
                                                                    .Returns(3.3)
                                                                    .Returns(4.4);
            var chromosome =  _chromosomeGenerator.OfLength(4).New();
            Assert.AreEqual(4, chromosome.Length);
            CollectionAssert.AreEqual(new [] { 1.1, 2.2, 3.3, 4.4}, chromosome.Genes.ToArray());
        }

        [TestMethod]
        public void ShouldGetAndSetGenes()
        {
            _doubleChromosomeGeneratorMock.Setup(m => m.New()).Returns(1);
            var chromosome =  _chromosomeGenerator.OfLength(3).New();
            chromosome[0] = 3.1;
            chromosome[1] = 2.2;
            chromosome[2] = 1.3;
            
            Assert.AreEqual(3.1, chromosome[0]);
            Assert.AreEqual(2.2, chromosome[1]);
            Assert.AreEqual(1.3, chromosome[2]);
        }
    }
}
