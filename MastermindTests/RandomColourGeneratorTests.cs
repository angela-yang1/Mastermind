using System;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class RandomColourGeneratorTests
    {
        [Fact]
        public void GenerateFourRandomColours_WhenGameBegins()
        {
            var randomGenerator = new RandomColourGenerator(4);

            var result = randomGenerator.Generate();

            Assert.Equal(4, result.Length);
        }
        
        [Fact]
        public void GenerateFourRandomColours_ShouldContainColourValues()
        {
            var randomGenerator = new RandomColourGenerator(4);

            var result = randomGenerator.Generate();

            Assert.IsType<Colour[]>(result);
        }
    }
}