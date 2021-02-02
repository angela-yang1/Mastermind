using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class TurnCountTests
    {
        // Turn count starts at 1 - max tries is 60
        
        [Fact]
        public void NextTurn_ShouldIncrementGuessCountBy1()
        {
            var turnCount = new TurnCount();
            turnCount.NextTurn();

            var result = turnCount.Counter;
            
            Assert.Equal(2, result);
        }
        
        // [Fact]
        // public void WhenMaxGuessTriesReached_ReturnTrue()
        // {
        //     var turnCount = new TurnCount();
        //     turnCount.NextTurn();
        //     
        //     var result = turnCount.HasMaxTriesBeenReached();
        //     
        //     Assert.True(result);
        // }
        
        [Fact]
        public void WhenMaxGuessTriesNotReached_ReturnFalse()
        {
            var turnCount = new TurnCount();
            turnCount.NextTurn();
            
            var result = turnCount.HasMaxTriesBeenReached();
            
            Assert.False(result);
        }
    }
}