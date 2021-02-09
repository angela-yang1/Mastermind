using Mastermind;
using Mastermind.Enums;
using Mastermind.Interfaces;
using Moq;
using Xunit;

namespace MastermindTests
{
    public class GameEngineTests
    {
        // mock up classes - test the loop runs as it should
        // integration test (no mocks) - run Mastermind, assert on string etc
        
        // Set winning scenario
        [Fact]
        public void Moq_GivenCorrectAnswer_HasAWinner_ShouldReturnTrue()
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
            //var result = gameEngine.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.Once);
            //Assert.True(result);
        }
        
        // Set incorrect guess
        [Fact]
        public void Moq_GivenIncorrectAnswer_HasAWinner_ShouldReturnFalse()
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
            //var result = gameEngine.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.AtLeastOnce);
            //Assert.False(result);
        }
        
        [Fact]
        public void Moq_SelectQuitOption_ShouldQuitGame()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            // different types of inputs e.g. a guess or quit
            var mockInputHandler = new Mock<IInputHandler>();
            mockInputHandler.Setup(ge => ge.TakeInput())
                .Returns(UserOption.Quit);
            
            var mockDisplayMessage = new Mock<IDisplay>();
            
            // what is the expected result
            var gameEngine = new GameEngine(mockRandomGen.Object, mockInputHandler.Object, mockDisplayMessage.Object);
            gameEngine.Run();
            //var result = gameEngine.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockInputHandler.Verify(ge => ge.TakeInput(), Times.AtLeastOnce);
            //Assert.False(result);
        }
    }
}