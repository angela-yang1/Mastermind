using System;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class ColoursParserTests
    {
        [Theory]
        [InlineData("Red, Blue, Orange, Yellow", new[] { Colours.Red, Colours.Blue, Colours.Orange, Colours.Yellow })]
        [InlineData("Blue, Blue, Purple, Green", new[] { Colours.Blue, Colours.Blue, Colours.Purple, Colours.Green })]
        public void UserInputString_ShouldConvertToEnumArray(string input, Colours[] expected)
        {
            var result = ColoursParser.ParseFromString(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Red, Pink, White, Yellow")]
        [InlineData("Burgundy, , Blue, Yellow")]
        [InlineData(" , , Red, ")]
        [InlineData(" , , , ")]
        public void UserInputWithInvalidString_ShouldThrowException(string input)
        {
            Assert.Throws<ArgumentException>(() => ColoursParser.ParseFromString(input));
        }
    }
}