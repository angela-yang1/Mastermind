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
        public void GivenCorrectGuess_RunLoopShouldStop()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockDisplayMessage = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplayMessage.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Once);
            mockDisplayMessage.Verify(w => w.Win(), Times.Once);
        }
        
        [Fact]
        public void GivenIncorrectGuess_RunLoopShouldKeepRunning()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(new[] { Colour.Red, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockDisplayMessage = new Mock<IDisplay>();

            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplayMessage.Object);
            gameEngine.Run();
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.AtLeastOnce);
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
            
            var mockDisplayMessage = new Mock<IDisplay>();
            
            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplayMessage.Object);
            gameEngine.Run();

            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Once);
            mockDisplayMessage.Verify(q => q.Quit(), Times.Once);
        }
    }
}