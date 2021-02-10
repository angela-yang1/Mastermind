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
            var mockRandomGen = new Mock<IRandomGenerator>();
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
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.SetupSequence(ge => ge.TakeInput())
                .Returns(new[] { Colour.Red, Colour.Yellow, Colour.Green, Colour.Red })
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockDisplay = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.AtLeastOnce);
            mockDisplay.Verify(i => i.NoColourMatch(), Times.Once);
            mockDisplay.Verify(w => w.Win(), Times.Once);
        }
        
        [Fact]
        public void GivenIncorrectGuess_LoopShouldKeepRunning()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(new[] { Colour.Red, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockDisplay = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(i => i.TakeInput(), Times.AtLeastOnce);
        }
        
        [Fact]
        public void GivenUserInput_IsUserOptionQuit_ShouldQuitGame()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(UserOption.Quit);
            
            var mockDisplay = new Mock<IDisplay>();
            
            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplay.Object);
            gameEngine.Run();

            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(i => i.TakeInput(), Times.Once);
            mockDisplay.Verify(q => q.Quit(), Times.Once);
        }
    }
}