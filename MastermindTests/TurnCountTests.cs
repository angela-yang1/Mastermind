using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class TurnCountTests
    {
        [Fact]
        public void NextTurn_ShouldIncrementTurnBy1()
        {
            var turnCount = new TurnCount(60);
            turnCount.NextTurn();
            
            // turn count starts at 1
            var result = turnCount.Counter;
            
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void WhenMaxTriesReached_ReturnTrue()
        {
            var turnCount = new TurnCount(2);
            turnCount.NextTurn();
            
            // turn count starts at 1
            var result = turnCount.HasMaxTriesBeenReached();
            
            Assert.True(result);
        }
    }
}