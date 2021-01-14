using System;
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
        
        [Theory]
        [InlineData(new[] { Colours.Red, Colours.Blue, Colours.Green })]
        [InlineData(new[] { Colours.Purple, Colours.Green })]
        [InlineData(new[] { Colours.Yellow })]
        public void UserInputArray_ContainingLessThanFourItems_ThrowsException(Colours[] inputArray)
        {
            var inputValidator = new UserInputValidator();
            
            Assert.Throws<ArgumentException>(() => inputValidator.ValidateUserInput(inputArray));
        }
        
        [Theory]
        [InlineData(new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Blue, Colours.Purple, Colours.Orange })]
        public void UserInputArray_ContainingMoreThanFourItems_ThrowsException(Colours[] inputArray)
        {
            var inputValidator = new UserInputValidator();
            
            Assert.Throws<ArgumentException>(() => inputValidator.ValidateUserInput(inputArray));
        }
    }
}