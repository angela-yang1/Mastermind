using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class MastermindWorld
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IGameEngine _gameEngine;
        private readonly IDisplayMessage _displayMessage;
        private readonly ResultOutput _resultOutput;
        private readonly TurnCount _turnCount;

        public MastermindWorld(IRandomGenerator randomGenerator, IGameEngine gameEngine, IDisplayMessage displayMessage)
        {
            _randomGenerator = randomGenerator;
            _gameEngine = gameEngine;
            _displayMessage = displayMessage;
            _resultOutput = new ResultOutput();
            _turnCount = new TurnCount(Constants.MaxTries);
        }
        
        public bool HasAWinner { get; private set; }
        
        
        public void Run()
        {
            _displayMessage.Welcome();

            HasAWinner = false;
            
            // generate 4 random colours
            var masterColours = _randomGenerator.Generate();
            Console.WriteLine(string.Join(", ", masterColours));

            // loop until user wins or reaches max 60 guesses
            // do while loop??
            while (true)
            {
                // get validated input
                var userAnswer = _gameEngine.TakeATurn();

                //user selected menu option
                if (userAnswer.GetSelectedAlternative() != 1)
                {
                    //quit
                    var userSelectedOption = userAnswer.Value2;
                    if (userSelectedOption == UserOption.Quit)
                    {
                        _displayMessage.Quit();
                        break;
                    }
                }
                
                var userSelectedColours = userAnswer.Value1;

                // check for matching colours (output: black/white)
                var outputResult = _resultOutput.CreateWinningResult(userSelectedColours, masterColours);

                // check for any matches
                if (outputResult.Count != 0)
                {
                    // check against guess checker
                    HasAWinner = WinnerChecker.HasUserWon(outputResult);
                    _displayMessage.TurnCounter(_turnCount.Counter, outputResult);
                }
                else
                {
                    _displayMessage.NoColourMatch();
                }
                
                if (IsThereAWinner()) 
                    break;

                
                if (MaxTriesReached()) 
                    break;
                
                _turnCount.NextTurn();
            }
        }

        private bool MaxTriesReached()
        {
            if (!_turnCount.HasMaxTriesBeenReached()) return false;
            _displayMessage.MaxGuesses();
            return true;
        }

        private bool IsThereAWinner()
        {
            if (!HasAWinner) return false;
            _displayMessage.Win();
            return true;
        }
    }
}