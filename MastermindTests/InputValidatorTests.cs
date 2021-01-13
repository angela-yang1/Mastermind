using System.Collections;
using System.Collections.Generic;
using Mastermind;
using Mastermind.Data;
using Xunit;

namespace MastermindTests
{
    public class InputValidatorTests
    {
        public static IEnumerable<object[]> UserInputArrayLength()
        {
            yield return new object[]
            {
                new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow },
            };
        }
        
        [Theory]
        [MemberData(nameof(UserInputArrayLength))]
        public void UserInput_ShouldReturnArray_WithFourItems(Colours[] inputArray)
        {
            var inputValidator = new InputValidator();
            
            var result = inputValidator.CheckArrayLength(inputArray);
            
            Assert.True(result);
        }
    }
}