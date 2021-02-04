using System;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class InputColoursParserTests
    {
        [Theory]
        [InlineData("Red, Blue, Orange, Yellow", new[] { Colour.Red, Colour.Blue, Colour.Orange, Colour.Yellow })]
        [InlineData("Blue, Blue, Purple, Green", new[] { Colour.Blue, Colour.Blue, Colour.Purple, Colour.Green })]
        [InlineData("Blue, Blue, Blue, Blue", new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue })]
        [InlineData("blue, blue, blue, blue", new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue })]
        [InlineData("Red, yellow, blue, Purple", new[] { Colour.Red, Colour.Yellow, Colour.Blue, Colour.Purple})]
        [InlineData("yellow, Green, blue, Blue", new[] { Colour.Yellow, Colour.Green, Colour.Blue, Colour.Blue})]
        public void UserInputString_ShouldConvertToEnumArray(string input, Colour[] expected)
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