using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class RandomColourGeneratorTests
    {
        [Fact]
        public void GenerateFourRandomColours_WhenGameBegins()
        {
            var randomColourGenerator = new RandomColourGenerator(4);

            var result = randomColourGenerator.Generate();

            Assert.Equal(4, result.Length);
        }
    }
}