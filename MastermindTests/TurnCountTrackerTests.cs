using Mastermind;
using Xunit;

namespace MastermindTests
{
    public class TurnCountTrackerTests
    {
        [Fact]
        public void CallingNextTurn_ShouldIncrementGuessCountBy1()
        {
            var turnCountTracker = new TurnCountTracker(Constants.MaxTries);
            turnCountTracker.NextTurn();

            var result = turnCountTracker.Counter;
            
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void CallingNextTurn_ShouldIncrementGuessCounterTo6()
        {
            var turnCountTracker = new TurnCountTracker(Constants.MaxTries);
            turnCountTracker.NextTurn();
            turnCountTracker.NextTurn();
            turnCountTracker.NextTurn();
            turnCountTracker.NextTurn();
            turnCountTracker.NextTurn();

            var result = turnCountTracker.Counter;
            
            Assert.Equal(6, result);
        }
        
        [Fact]
        public void HasMaxTriesBeenReached_ShouldReturnTrue_WhenMaxTriesReached()
        {
            var turnCountTracker = new TurnCountTracker(2);
            turnCountTracker.NextTurn();
            turnCountTracker.NextTurn();

            var result = turnCountTracker.HasMaxTriesBeenReached();
            
            Assert.True(result);
        }
        
        [Fact]
        public void HasMaxTriesBeenReached_ShouldReturnFalse_WhenMaxTriesNotReached()
        {
            var turnCountTracker = new TurnCountTracker(Constants.MaxTries);
            turnCountTracker.NextTurn();
            
            var result = turnCountTracker.HasMaxTriesBeenReached();
            
            Assert.False(result);
        }
    }
}