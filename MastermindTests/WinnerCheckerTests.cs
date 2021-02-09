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
            var winnerChecker = new WinnerChecker(Constants.MasterColoursCount);
            var colourMatchResult = new List<ResultColour>()
            { ResultColour.Black, ResultColour.Black, ResultColour.Black, ResultColour.Black };

            var result = winnerChecker.HasUserWon(colourMatchResult);
            
            Assert.True(result);
        }
        
        [Fact]
        public void IfUserAnswer_DoesNotEqualAllBlack_UserHasNotWon()
        {
            var winnerChecker = new WinnerChecker(Constants.MasterColoursCount);
            var colourMatchResult = new List<ResultColour>()
                { ResultColour.Black, ResultColour.Black, ResultColour.Black };

            var result = winnerChecker.HasUserWon(colourMatchResult);
            
            Assert.False(result);
        }
    }
}