using System;
using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class RandomGeneratorTests
    {
        [Fact]
        public void GenerateFourRandomColours_WhenGameBegins()
        {
            var randomGenerator = new RandomGenerator();
            // var mock = new Mock<IRandomGenerator>();
            // mock.Setup(r => r.Generate());

            var result = randomGenerator.Generate();

            Assert.Equal(4, result.Length);
        }
    }
}