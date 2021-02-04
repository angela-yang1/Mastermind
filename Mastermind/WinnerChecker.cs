using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Enums;

namespace Mastermind
{
    public static class WinnerChecker
    {
        public static bool HasUserWon(List<ResultColour> winningCondition)
        {
            if (winningCondition.Count != Constants.NumberOfColours) 
                return false;
            
            var userHasWon = winningCondition
                .All(c => c == ResultColour.Black);
            
            return userHasWon;
        }
    }
}