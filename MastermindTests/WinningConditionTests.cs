using System;
using System.Collections.Generic;
using Mastermind;
using Mastermind.ColoursData;
using Xunit;

namespace MastermindTests
{
    public class WinningConditionTests
    {
        private readonly Colours[] _selectedColours = 
            { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue};
        
        // Pass selected colours and user guesses into method to CheckWin (rather than pass into constructor)
        // don't have to rely on list of black/white to determine winning
        [Fact]
        public void AllCorrectGuesses_AddsBlackToList_UserWins()
        {
            var winningCondition = new WinningCondition();
            var userGuesses = new[] 
                { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue };
            var actual = new List<ResultColours> 
                { ResultColours.Black, ResultColours.Black, ResultColours.Black, ResultColours.Black };
            winningCondition.CreateWinningCondition(userGuesses, _selectedColours);

            var result = winningCondition.CreateWinningCondition(userGuesses, _selectedColours);
            
            Assert.Equal(result, actual);
        }
        
        [Fact]
        public void UserCorrectGuessesInWrongIndex_AddWhiteToList_ReturnsList()
        {
            var winningCondition = new WinningCondition();
            var userGuesses = new[] 
                { Colours.Red, Colours.Blue, Colours.Green, Colours.Orange };
            var actual = new List<ResultColours> 
                { ResultColours.White, ResultColours.White };
            winningCondition.CreateWinningCondition(userGuesses, _selectedColours);

            var result = winningCondition.CreateWinningCondition(userGuesses, _selectedColours);
            
            Assert.Equal(result, actual);
        }
    }
}