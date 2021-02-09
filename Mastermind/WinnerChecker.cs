using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Enums;

namespace Mastermind
{
    public class WinnerChecker
    {
        private readonly int _masterColoursCount;
        
        public WinnerChecker(int masterColoursCount)
        {
            _masterColoursCount = masterColoursCount;
        }
        
        public bool HasUserWon(List<ResultColour> colourMatchResult)
        {
            if (colourMatchResult.Count != _masterColoursCount) 
                return false;
            
            var userHasWon = colourMatchResult
                .All(c => c == ResultColour.Black);
            
            return userHasWon;
        }
    }
}