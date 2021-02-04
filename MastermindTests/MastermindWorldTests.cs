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
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });

            var mockDisplayMessage = new Mock<IDisplayMessage>();

            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object, mockDisplayMessage.Object);
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
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Returns(new[] { Colour.Red, Colour.Blue, Colour.Blue, Colour.Blue });
            
            var mockDisplayMessage = new Mock<IDisplayMessage>();

            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object, mockDisplayMessage.Object);
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
                .Returns(new[] { Colour.Blue, Colour.Blue, Colour.Blue, Colour.Blue });
            
            // different types of inputs e.g. a guess or quit
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.TakeATurn())
                .Returns(UserOption.Quit);
            
            var mockDisplayMessage = new Mock<IDisplayMessage>();
            
            // what is the expected result
            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object, mockDisplayMessage.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.TakeATurn(), Times.AtLeastOnce);
            Assert.False(result);
        }
    }
}