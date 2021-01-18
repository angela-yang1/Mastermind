using System;
using System.Collections;
using System.Collections.Generic;
using Mastermind;
using Mastermind.ColoursData;
using Xunit;

namespace MastermindTests
{
    public class ColoursParserTests
    {
        [Theory]
        [InlineData("Red, Blue, Orange, Yellow", new[] { Colours.Red, Colours.Blue, Colours.Orange, Colours.Yellow })]
        public void UserInputString_ShouldConvertToEnumArrayTest(string input, Colours[] expected)
        {
            // Arrange

            // Act
            var result = ColoursParser.ParseFromString(input);

            // Assert
            Assert.Equal(expected, result);
        }
        
    //     [Theory]
    //     [ClassData(typeof(UserInputTestData))]
    //     public void UserInputString_ShouldConvertToEnumArray(string input, Colours[] expected)
    //     {
    //         // Arrange
    //
    //         // Act
    //         var result = ColoursParser.ParseFromString(input);
    //
    //         // Assert
    //         Assert.Equal(expected, result);
    //     }
    //
    // }
    //
    // public class UserInputTestData : IEnumerable<object[]>
    // {
    //     public IEnumerator<object[]> GetEnumerator()
    //     {
    //         yield return new object[]
    //         {
    //             "Red, Blue, Orange, Yellow", 
    //             new[] { Colours.Red, Colours.Blue, Colours.Orange, Colours.Yellow }
    //         };
    //     }
    //
    //     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}