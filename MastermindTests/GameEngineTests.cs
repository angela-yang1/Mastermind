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
        public void GetUserAnswer_ValidatesAndReturnsAn_EnumArrayWithFourItems()
        {
            var mock = new Mock<IUserInput>();
            mock.Setup(i => i.GetUserInput()).Returns("Red, Blue, Yellow, Green");
        
            var gameEngine = new GameEngine(mock.Object);
            var result = gameEngine.GetUserAnswer();
            
            Assert.Equal(new[] { Colours.Red, Colours.Blue, Colours.Yellow, Colours.Green }, result);
        }
    }
}