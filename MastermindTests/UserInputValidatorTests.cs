using System.Collections;
using System.Collections.Generic;
using Mastermind;
using Mastermind.ColoursData;
using Xunit;

namespace MastermindTests
{
    public class UserInputValidatorTests
    {
        [Fact]
        public void UserInput_ShouldReturnArray_WithFourItems()
        {
            var inputValidator = new UserInputValidator();
            var inputArray = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
            
            var result = inputValidator.ValidateUserInput(inputArray);
            
            Assert.True(result);
        }
        
        [Fact]
        public void UserInput_ContainingLessThanFourItems_ReturnsFalse()
        {
            var inputValidator = new UserInputValidator();
            var inputArray = new[] { Colours.Red, Colours.Blue, Colours.Green };
            
            var result = inputValidator.ValidateUserInput(inputArray);
            
            Assert.False(result);
        }
    }
}