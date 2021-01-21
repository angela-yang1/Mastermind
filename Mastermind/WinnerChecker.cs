using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class WinnerChecker
    {
        public bool HasUserWon(List<ResultColours> winningCondition)
        {
            if (winningCondition.Count != 4) 
                return false;
            
            var userHasWon = winningCondition
                .All(c => c == ResultColours.Black);
            return userHasWon;
        }
    }
}