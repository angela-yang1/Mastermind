using System;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class InputColoursParserTests
    {
        [Theory]
        [InlineData("Red, Blue, Orange, Yellow", new[] { Colours.Red, Colours.Blue, Colours.Orange, Colours.Yellow })]
        [InlineData("Blue, Blue, Purple, Green", new[] { Colours.Blue, Colours.Blue, Colours.Purple, Colours.Green })]
        [InlineData("Blue, Blue, Blue, Blue", new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue })]
        [InlineData("blue, blue, blue, blue", new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue })]
        [InlineData("Red, yellow, blue, Purple", new[] { Colours.Red, Colours.Yellow, Colours.Blue, Colours.Purple})]
        [InlineData("yellow, Green, blue, Blue", new[] { Colours.Yellow, Colours.Green, Colours.Blue, Colours.Blue})]
        public void UserInputString_ShouldConvertToEnumArray(string input, Colours[] expected)
        {
            var result = InputColoursParser.ParseFromString(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Red, Pink, White, Yellow")]
        [InlineData("Burgundy, , Blue, Yellow")]
        [InlineData(" , , Red, ")]
        [InlineData(" , , , ")]
        public void UserInputWithInvalidString_ShouldThrowException(string input)
        {
            Assert.Throws<ArgumentException>(() => InputColoursParser.ParseFromString(input));
        }
    }
}