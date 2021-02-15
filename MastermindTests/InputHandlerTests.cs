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
            var mockInputReceiver = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mockInputReceiver.Setup(i => i.GetUserInput())
                .Returns("Red, Blue, Yellow, Green");
            
            var inputHandler = new InputHandler(mockInputReceiver.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
            
            mockErrorHandler.Verify(e => e.DisplayParseExceptionMessage(It.IsAny<ParseException>()), Times.Never);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }

        [Fact]
        public void GivenInvalidColour_ShouldCallDisplayParseExceptionMessage()
        {
            var mockInputReceiver = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            
            mockInputReceiver.SetupSequence(i => i.GetUserInput())
                .Returns("Pink, Blue, Yellow, Green")
                .Returns("Red, Blue, Yellow, Green");
        
            var inputHandler = new InputHandler(mockInputReceiver.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
        
            mockErrorHandler.Verify(e =>
                e.DisplayParseExceptionMessage(It.Is<ParseException>(parseException => parseException.InvalidColourInput.Contains("Pink"))), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
        
        [Fact]
        public void GivenInvalidMasterColourLength_ShouldCallDisplayLengthExceptionMessage()
        {
            var mockInputReceiver = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();

            mockInputReceiver.SetupSequence(i => i.GetUserInput())
                .Returns("Blue, Yellow, Green")
                .Returns("Red, Blue, Yellow, Green");
        
            var inputHandler = new InputHandler(mockInputReceiver.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
        
            mockErrorHandler.Verify(e =>
                e.DisplayLengthExceptionMessage(It.Is<LengthException>(lengthException => lengthException.InputColourCount == 3)), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
        
        [Fact]
        public void GetUserAnswer_ValidatesAndReturnsUserOption_Quit()
        {
            var mockInputReceiver = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mockInputReceiver.Setup(i => i.GetUserInput())
                .Returns("Quit");
            
            var inputHandler = new InputHandler(mockInputReceiver.Object, mockErrorHandler.Object);
            var result = inputHandler.TakeInput();
            
            mockErrorHandler.Verify(e => e.DisplayParseExceptionMessage(It.IsAny<ParseException>()), Times.Never);
            Assert.Equal(UserOption.Quit, result);
        }
    }
}