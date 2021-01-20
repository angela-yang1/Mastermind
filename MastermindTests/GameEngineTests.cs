using System;
using Mastermind;
using Mastermind.ColoursData;
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
            var mock = new Mock<IUserInput>();
            var mockErrorHandler = new Mock<IErrorHandler>();
            mock.SetupSequence(i => i.GetUserInput()).Returns("Red, Blue, Yellow, Green");
        
            var gameEngine = new GameEngine(mock.Object, mockErrorHandler.Object);
            var result = gameEngine.GetUserAnswer();
            
            mockErrorHandler.Verify(e => e.DisplayErrorMessage(It.IsAny<Exception>()), Times.Never);
            Assert.Equal(new[] { Colours.Red, Colours.Blue, Colours.Yellow, Colours.Green }, result);
        }
        
        // [Fact]
        // public void InvalidUserAnswer_ShouldCallDisplayExceptionMessage()
        // {
        //     var mock = new Mock<IUserInput>();
        //     var mockErrorHandler = new Mock<IErrorHandler>();
        //     mock.SetupSequence(i => i.GetUserInput())
        //         .Returns("Pink, Blue, Yellow, Green")
        //         .Returns("Red, Blue, Yellow, Green");
        //
        //     var gameEngine = new GameEngine(mock.Object, mockErrorHandler.Object);
        //     //var result = gameEngine.GetUserAnswer();
        //     
        //     mockErrorHandler.Verify(e => e.DisplayErrorMessage(new ArgumentException()), Times.Once);
        //     Assert.Throws<Exception>(() => gameEngine.GetUserAnswer());
        // }
    }
}