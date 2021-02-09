using System;
using System.Runtime.InteropServices;
using Mastermind;
using Mastermind.Enums;
using Mastermind.Exceptions;
using Mastermind.Interfaces;
using Moq;
using Xunit;

namespace MastermindTests
{
    public class InputHandlerTests
    {
        [Fact]
        public void GetUserAnswer_ValidatesAndReturnsAn_ColoursArrayWithFourItems()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mockUserInput.Setup(i => i.GetUserInput())
                .Returns("Red, Blue, Yellow, Green");
            
            var inputHandler = new InputHandler(mockUserInput.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
            
            mockErrorHandler.Verify(e => e.DisplayParseErrorMessage(It.IsAny<ParseException>()), Times.Never);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
        
        [Fact]
        public void InvalidUserAnswer_ShouldCallDisplayExceptionMessage()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            
            mockUserInput.SetupSequence(i => i.GetUserInput())
                .Returns("Pink, Blue, Yellow, Green")
                .Returns("Red, Blue, Yellow, Green");
        
            var inputHandler = new InputHandler(mockUserInput.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
        
            mockErrorHandler.Verify(m =>
                m.DisplayParseErrorMessage(It.Is<ParseException>(e => e.InvalidColourInput.Contains("Pink"))), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
    }
}