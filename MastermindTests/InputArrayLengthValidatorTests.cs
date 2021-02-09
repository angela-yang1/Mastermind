using System;
using System.Collections;
using System.Collections.Generic;
using Mastermind;
using Mastermind.Enums;
using Mastermind.Exceptions;
using Xunit;

namespace MastermindTests
{
    public class InputArrayLengthValidatorTests
    {
        [Fact]
        public void UserInput_ShouldReturnArray_WithFourItems()
        {
            var inputValidator = new InputArrayLengthValidator(4);
            var inputArray = new[] { Colour.Red, Colour.Blue, Colour.Green, Colour.Yellow };
            inputValidator.ValidateUserInput(inputArray);

            var result = inputArray.Length;
            
            Assert.Equal(4, result);
        }
        
        [Theory]
        [InlineData(new[] { Colour.Red, Colour.Blue, Colour.Green })]
        [InlineData(new[] { Colour.Purple, Colour.Green })]
        [InlineData(new[] { Colour.Yellow })]
        public void UserInputArray_ContainingLessThanFourItems_ThrowsException(Colour[] inputArray)
        {
            var inputValidator = new InputArrayLengthValidator(4);
            
            Assert.Throws<LengthException>(() => inputValidator.ValidateUserInput(inputArray));
        }
        
        [Theory]
        [InlineData(new[] { Colour.Red, Colour.Blue, Colour.Green, Colour.Blue, Colour.Purple, Colour.Orange })]
        public void UserInputArray_ContainingMoreThanFourItems_ThrowsException(Colour[] inputArray)
        {
            var inputValidator = new InputArrayLengthValidator(4);
            
            Assert.Throws<LengthException>(() => inputValidator.ValidateUserInput(inputArray));
        }
    }
}