using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Enums;

namespace Mastermind
{
    public class WinnerChecker
    {
        public bool UserHasWon { get; set; }
        
        public bool HasUserWon(List<ResultColours> winningCondition)
        {
            if (winningCondition.Count != 4) 
                return false;
            
            UserHasWon = winningCondition
                .All(c => c == ResultColours.Black);
            
            return UserHasWon;
        }
    }
}