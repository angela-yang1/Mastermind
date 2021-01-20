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

            var result = randomGenerator.Generate();

            Assert.Equal(4, result.Length);
        }
    }
}