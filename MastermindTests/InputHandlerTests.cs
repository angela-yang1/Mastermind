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
        public void GivenInvalidColour_ShouldCallDisplayParseExceptionMessage()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            
            mockUserInput.SetupSequence(i => i.GetUserInput())
                .Returns("Pink, Blue, Yellow, Green")
                .Returns("Red, Blue, Yellow, Green");
        
            var inputHandler = new InputHandler(mockUserInput.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
        
            mockErrorHandler.Verify(e =>
                e.DisplayParseErrorMessage(It.Is<ParseException>(e => e.InvalidColourInput.Contains("Pink"))), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
        
        [Fact]
        public void GivenInvalidMasterColourLength_ShouldCallDisplayLengthExceptionMessage()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();

            mockUserInput.SetupSequence(i => i.GetUserInput())
                .Returns("Blue, Yellow, Green")
                .Returns("Red, Blue, Yellow, Green");;
        
            var inputHandler = new InputHandler(mockUserInput.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
        
            mockErrorHandler.Verify(e =>
                e.DisplayLengthErrorMessage(It.Is<LengthException>(e => e.InputColourCount == 3)), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
        
        [Fact]
        public void GetUserAnswer_ValidatesAndReturnsUserOption_Quit()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mockUserInput.Setup(i => i.GetUserInput())
                .Returns("Quit");
            
            var inputHandler = new InputHandler(mockUserInput.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
            
            mockErrorHandler.Verify(e => e.DisplayParseErrorMessage(It.IsAny<ParseException>()), Times.Never);
            Assert.Equal(UserOption.Quit, result);
        }
    }
}