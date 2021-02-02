using System;
using System.IO;
using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class InputReceiverTests
    {
        [Theory]
        [InlineData("red, red, red, red", "red, red, red, red")]
        [InlineData("Red, red, Red, red", "Red, red, Red, red")]
        [InlineData("red, Red, Red, red", "red, Red, Red, red")]
        public void InputReceiver_ShouldReturnString(string input, string expected)
        {
            SetUpConsoleReadLineToStringReader(input);
            var inputReceiver = new InputReceiver();

            var result = inputReceiver.GetUserInput();
            
            Assert.Equal(expected, result);
        }
        
        private static void SetUpConsoleReadLineToStringReader(string input)
        {
            var stringReader = new StringReader(input);
            Console.Clear();
            Console.SetIn(stringReader);
        }
    }
}