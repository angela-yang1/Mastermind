using System.Collections.Generic;
using Mastermind;
using Mastermind.Enums;
using Xunit;

namespace MastermindTests
{
    public class WinnerCheckerTests
    {
        [Fact]
        public void IfUserAnswer_EqualsAllBlack_UserHasWon()
        {
            var winnerChecker = new WinnerChecker();
            var winningCondition = new List<ResultColours>()
            { ResultColours.Black, ResultColours.Black, ResultColours.Black, ResultColours.Black };

            var result = winnerChecker.HasUserWon(winningCondition);
            
            Assert.True(result);
        }
        
        [Fact]
        public void IfUserAnswer_DoesNotEqualAllBlack_UserHasNotWon()
        {
            var winnerChecker = new WinnerChecker();
            var winningCondition = new List<ResultColours>()
                { ResultColours.Black, ResultColours.Black, ResultColours.Black };

            var result = winnerChecker.HasUserWon(winningCondition);
            
            Assert.False(result);
        }
    }
}