using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mastermind;
using Mastermind.Data;
using Xunit;

namespace MastermindTests
{
    public class UserInputTests
    {
        [Theory]
        [ClassData(typeof(UserInputTestData))]
        public void UserInputString_ShouldConvertToEnumArray(string input, Colours[] expected)
        {
            // Arrange
            SetUpConsoleReadLineToStringReader(input);
            var userInput = new UserInput();

            // Act
            var result = userInput.GetUserInput();

            // Assert
            Assert.Equal(expected, result);
        }
        
        private static void SetUpConsoleReadLineToStringReader(string input)
        {
            var stringReader = new StringReader(input);
            Console.Clear();
            Console.SetIn(stringReader);
        }
    }
    
    public class UserInputTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "Red, Blue, Orange, Yellow", 
                new[] { Colours.Red, Colours.Blue, Colours.Orange, Colours.Yellow }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}