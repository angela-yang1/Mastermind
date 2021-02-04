using System;
using System.Runtime.InteropServices;
using Mastermind;
using Mastermind.Enums;
using Mastermind.Interfaces;
using Moq;
using Xunit;

namespace MastermindTests
{
    public class GameEngineTests
    {
        [Fact]
        public void GetUserAnswer_ValidatesAndReturnsAn_ColoursArrayWithFourItems()
        {
            var mockUserInput = new Mock<IInputReceiver>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mockUserInput.Setup(i => i.GetUserInput())
                .Returns("Red, Blue, Yellow, Green");
            
            var gameEngine = new GameEngine(mockUserInput.Object, mockErrorHandler.Object);
            var result = gameEngine.TakeATurn();
            
            mockErrorHandler.Verify(e => e.DisplayErrorMessage(It.IsAny<Exception>()), Times.Never);
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
        
            var gameEngine = new GameEngine(mockUserInput.Object, mockErrorHandler.Object);
            var result = gameEngine.TakeATurn();
        
            mockErrorHandler.Verify(m =>
                m.DisplayErrorMessage(It.Is<ArgumentException>(e => e.Message == "Pink is not a valid colour.")), Times.Once);
            Assert.Equal(new[] { Colour.Red, Colour.Blue, Colour.Yellow, Colour.Green }, result);
        }
    }
}