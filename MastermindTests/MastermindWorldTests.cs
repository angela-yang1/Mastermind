using Mastermind;
using Mastermind.Enums;
using Mastermind.Interfaces;
using Moq;
using Xunit;

namespace MastermindTests
{
    public class MastermindWorldTests
    {
        [Fact]
        public void Moq_GivenCorrectAnswer_HasAWinner_ShouldReturnTrue()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
            
            // different types of inputs e.g. a guess or quit
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.GetUserAnswer())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
            
            // what is the expected result
            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.GetUserAnswer(), Times.Once);
            Assert.True(result);
        }
        
        // set losing condition result in loop
        [Fact]
        public void Moq_GivenIncorrectAnswer_HasAWinner_ShouldReturnFalse()
        {
            var mockRandomGen = new Mock<IRandomGenerator>();
            mockRandomGen.Setup(rng => rng.Generate())
                .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
            
            // different types of inputs e.g. a guess or quit
            var mockGameEngine = new Mock<IGameEngine>();
            mockGameEngine.Setup(ge => ge.GetUserAnswer())
                .Returns(new[] { Colours.Red, Colours.Blue, Colours.Blue, Colours.Blue });
            
            // what is the expected result
            var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
            mastermind.Run();
            var result = mastermind.HasAWinner;
            
            mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
            mockGameEngine.Verify(ge => ge.GetUserAnswer(), Times.Once);
            Assert.False(result);
        }
        
        // [Fact]
        // public void Moq_SelectQuitOption_ShouldQuitGame()
        // {
        //     var mockRandomGen = new Mock<IRandomGenerator>();
        //     mockRandomGen.Setup(rng => rng.Generate())
        //         .Returns(new[] { Colours.Blue, Colours.Blue, Colours.Blue, Colours.Blue });
        //     
        //     // different types of inputs e.g. a guess or quit
        //     var mockGameEngine = new Mock<IGameEngine>();
        //     mockGameEngine.Setup(ge => ge.GetUserAnswer())
        //         // input should be quit
        //         //.Returns(new[] { Colours.Red, Colours.Blue, Colours.Blue, Colours.Blue });
        //     
        //     // what is the expected result
        //     var mastermind = new MastermindWorld(mockRandomGen.Object, mockGameEngine.Object);
        //     mastermind.Run();
        //     var result = mastermind.HasAWinner;
        //     
        //     mockRandomGen.Verify(rng => rng.Generate(), Times.Once);
        //     mockGameEngine.Verify(ge => ge.GetUserAnswer(), Times.Once);
        //     Assert.False(result);
        // }
    }
}