using System;
using System.Collections;
using System.Collections.Generic;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class UserInputArrayLengthValidatorTests
    {
        [Fact]
        public void UserInput_ShouldReturnArray_WithFourItems()
        {
            var inputValidator = new UserInputArrayLengthValidator();
            var inputArray = new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Yellow };
            inputValidator.ValidateUserInput(inputArray);

            var result = inputArray.Length;
            
            Assert.Equal(4, result);
        }
        
        [Theory]
        [InlineData(new[] { Colours.Red, Colours.Blue, Colours.Green })]
        [InlineData(new[] { Colours.Purple, Colours.Green })]
        [InlineData(new[] { Colours.Yellow })]
        public void UserInputArray_ContainingLessThanFourItems_ThrowsException(Colours[] inputArray)
        {
            var inputValidator = new UserInputArrayLengthValidator();
            
            Assert.Throws<ArgumentException>(() => inputValidator.ValidateUserInput(inputArray));
        }
        
        [Theory]
        [InlineData(new[] { Colours.Red, Colours.Blue, Colours.Green, Colours.Blue, Colours.Purple, Colours.Orange })]
        public void UserInputArray_ContainingMoreThanFourItems_ThrowsException(Colours[] inputArray)
        {
            var inputValidator = new UserInputArrayLengthValidator();
            
            Assert.Throws<ArgumentException>(() => inputValidator.ValidateUserInput(inputArray));
        }
    }
}