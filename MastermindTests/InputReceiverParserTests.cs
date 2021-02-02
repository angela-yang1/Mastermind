using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class InputReceiverParserTests
    {
        [Theory]
        [InlineData("blue, blue, blue, blue", "Blue, Blue, Blue, Blue")]
        [InlineData("Blue, blue, Blue, blue", "Blue, Blue, Blue, Blue")]
        [InlineData("Red, yellow, blue, Purple", "Red, Yellow, Blue, Purple")]
        [InlineData("yellow, Green, blue, Blue", "Yellow, Green, Blue, Blue")]
        public void UserInputString_ShouldConvertToCapitalisedString(string input, string expected)
        {
            var result = InputReceiverParser.ParseUserInput(input);
            
            Assert.Equal(expected, result);
        }
    }
}