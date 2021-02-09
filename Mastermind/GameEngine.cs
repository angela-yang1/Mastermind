using System;
using System.Collections.Generic;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IInputHandler _inputHandler;
        private readonly IDisplay _display;
        private readonly ColourMatchResult _colourMatchResult;
        private readonly TurnCount _turnCount;
        private readonly WinnerChecker _winnerChecker;

        public GameEngine(IRandomGenerator randomGenerator, IInputHandler inputHandler, IDisplay display)
        {
            _randomGenerator = randomGenerator;
            _inputHandler = inputHandler;
            _display = display;
            _colourMatchResult = new ColourMatchResult();
            _turnCount = new TurnCount(Constants.MaxTries);
            _winnerChecker = new WinnerChecker(Constants.MasterColoursCount);
        }
        
        public void Run()
        {
            _display.Welcome();
            _display.AvailableColours();
            var hasAWinner = false;
            
            // generate 4 random colours
            var masterColours = _randomGenerator.Generate();
            // prints random 4 colours selected
            Console.WriteLine(string.Join(", ", masterColours));

            // loop until user wins or reaches max guesses
            while (!hasAWinner && !MaxTriesReached())
            {
                // get validated input
                var userAnswer = _inputHandler.TakeInput();

                // user selected menu option
                    // - extension method to make class more explicit and more descriptive
                if (userAnswer.GetSelectedAlternative() == 2)
                {
                    // value 2 = UserOption
                    var userSelectedOption = userAnswer.Value2;
                    
                    if (QuitApplication(userSelectedOption)) 
                        break;
                }
                
                // value 1 = colours array
                var userSelectedColours = userAnswer.Value1;

                // check for matching colours (output: black/white)
                var matchResult = _colourMatchResult.CreateResult(userSelectedColours, masterColours);

                // check for any matches
                if (matchResult.Count != 0)
                {
                    // check against guess checker
                    _display.TurnCounter(_turnCount.Counter, matchResult);
                    hasAWinner = IsThereAWinner(matchResult);
                }
                else
                {
                    _display.NoColourMatch();
                }
                
                _turnCount.NextTurn();
            }
        }

        private bool QuitApplication(UserOption userSelectedOption)
        {
            if (userSelectedOption != UserOption.Quit) return false;
            _display.Quit();
            return true;
        }

        private bool MaxTriesReached()
        {
            if (!_turnCount.HasMaxTriesBeenReached()) return false;
            _display.MaxGuesses();
            return true;
        }

        private bool IsThereAWinner(List<ResultColour> matchResult)
        {
            if (!_winnerChecker.HasUserWon(matchResult)) return false;
            _display.Win();
            return true;

        }
    }
}