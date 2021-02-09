using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class TurnCountTests
    {
        [Fact]
        public void NextTurn_ShouldIncrementGuessCountBy1()
        {
            var turnCount = new TurnCount(Constants.MaxTries);
            turnCount.NextTurn();

            var result = turnCount.Counter;
            
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void NextTurn_ShouldIncrementGuessCountBy5()
        {
            var turnCount = new TurnCount(Constants.MaxTries);
            turnCount.NextTurn();
            turnCount.NextTurn();
            turnCount.NextTurn();
            turnCount.NextTurn();
            turnCount.NextTurn();

            var result = turnCount.Counter;
            
            Assert.Equal(6, result);
        }
        
        [Fact]
        public void WhenMaxGuessTriesReached_ReturnTrue()
        {
            var turnCount = new TurnCount(2);
            turnCount.NextTurn();
            turnCount.NextTurn();

            var result = turnCount.HasMaxTriesBeenReached();
            
            Assert.True(result);
        }
        
        [Fact]
        public void WhenMaxGuessTriesNotReached_ReturnFalse()
        {
            var turnCount = new TurnCount(Constants.MaxTries);
            turnCount.NextTurn();
            
            var result = turnCount.HasMaxTriesBeenReached();
            
            Assert.False(result);
        }
    }
}