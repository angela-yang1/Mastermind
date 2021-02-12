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
        public void GivenCorrectGuess_LoopShouldStop_AndPrintWinMessage()
        {
            var mockRandomGen = new Mock<IRandomColourGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockDisplay = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Once);
            mockDisplay.Verify(w => w.Win(), Times.Once);
        }
        
        [Fact]
        public void GivenNoColourMatches_ShouldDisplayNoMatchMessage()
        {
            var mockRandomGen = new Mock<IRandomColourGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.SetupSequence(ge => ge.TakeInput())
                .Returns(new[] { Colour.Red, Colour.Yellow, Colour.Green, Colour.Red })
                .Returns(new[] { Colour.Red, Colour.Blue, Colour.Blue, Colour.Red })
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockDisplay = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Exactly(3));
            mockDisplay.Verify(i => i.NoColourMatch(), Times.Once);
        }
        
        [Fact]
        public void GivenMaxTries60Reached_ShouldDisplayMaxGuessesMessage()
        {
            var mockRandomGen = new Mock<IRandomColourGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(new[] { Colour.Red, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockDisplay = new Mock<IDisplay>();
        
            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Exactly(60));
            mockDisplay.Verify(m => m.MaxGuesses(), Times.Once);
        }

        [Fact]
        public void GivenUserInput_IsUserOptionQuit_ShouldQuitGame()
        {
            var mockRandomGen = new Mock<IRandomColourGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(UserOption.Quit);
            var mockDisplay = new Mock<IDisplay>();
            
            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();

            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(i => i.TakeInput(), Times.Exactly(1));
            mockDisplay.Verify(q => q.Quit(), Times.Once);
        }
    }
}