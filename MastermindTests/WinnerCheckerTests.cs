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
            var winningCondition = new List<ResultColour>()
            { ResultColour.Black, ResultColour.Black, ResultColour.Black, ResultColour.Black };

            var result = WinnerChecker.HasUserWon(winningCondition);
            
            Assert.True(result);
        }
        
        [Fact]
        public void IfUserAnswer_DoesNotEqualAllBlack_UserHasNotWon()
        {
            var winningCondition = new List<ResultColour>()
                { ResultColour.Black, ResultColour.Black, ResultColour.Black };

            var result = WinnerChecker.HasUserWon(winningCondition);
            
            Assert.False(result);
        }
    }
}