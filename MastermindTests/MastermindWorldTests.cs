using System;
using System.IO;
using Mastermind;
using Mastermind.Enums;
using Mastermind.Interfaces;
using Moq;
using Xunit;

namespace MastermindTests
{
    public class MastermindWorldTests
    {
        // mock up classes - test the loop runs as it should
        // integration test (no mocks) - run Mastermind, assert on string etc
        
        // Set winning scenario
        [Fact]
        public void Moq_GivenCorrectAnswer_HasAWinner_ShouldReturnTrue()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });

            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });

            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.TakeATurn(), Times.Once);
            Assert.True(result);
        }
        
        // Set incorrect guess
        [Fact]
        public void Moq_GivenIncorrectAnswer_HasAWinner_ShouldReturnFalse()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
            
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Returns(new[] { Colours.Red, Colours.Blue, Colours.Blue, Colours.Blue });

            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.TakeATurn(), Times.AtLeastOnce);
            Assert.False(result);
        }
        
        [Fact]
        public void Moq_SelectQuitOption_ShouldQuitGame()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
            
            // different types of inputs e.g. a guess or quit
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Equals(UserOptions.Quit);
            
            // what is the expected result
            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.TakeATurn(), Times.AtLeastOnce);
            Assert.False(result);
        }

        // [Theory]
        // [InlineData(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue }, new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue })]
        // public void GivenCorrectAnswer_HasAWinner_ShouldReturnTrue(Colours[] randomGenColours, Colours[] input)
        // {
        //     SetUpConsoleReadLineToStringReader(input);
        //     var userInput = new UserInput();
        //     var errorHandler = new ConsoleErrorHandler();
        //     var gameEngine = new GameEngine(userInput, errorHandler);
        //     var mastermind = new MastermindWorld(new RandomGenerator(), gameEngine);
        //     mastermind.Run();
        //     
        //     Assert.Equal(randomGenColours, input);
        // }
        //
        // private static void SetUpConsoleReadLineToStringReader(string input)
        // {
        //     var stringReader = new StringReader(input);
        //     Console.Clear();
        //     Console.SetIn(stringReader);
        // }
    }
}