using System;
using Mastermind;
using Mastermind.ColoursData;
using Xunit;

namespace MastermindTests
{
    public class WinningConditionTests
    {
        private readonly ResultColours[] _winningColours = 
            { ResultColours.Black, ResultColours.Black, ResultColours.Black, ResultColours.Black };

        private readonly Colours[] _selectedColours = 
            { Colours.Blue, Colours.Green, Colours.Yellow, Colours.Blue};
        
        // Pass selected colours and user guesses into method to CheckWin (rather than pass into constructor)
        // don't have to rely on list of black/white to determine winning
        [Fact]
        public void ForEveryCorrectGuess_AddBlackToWinningArray()
        {
            var winningCondition = new WinningCondition();
            var userGuesses = new[] { Colours.Red, Colours.Blue, Colours.Red, Colours.Yellow };
            winningCondition.CreateWinningCondition(userGuesses, _selectedColours);

            // var result = winningCondition.HasUserWon();
            //
            // Assert.Equal(result, _winningColours);
        }
    }
}