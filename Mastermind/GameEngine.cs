using System;
using System.Collections.Generic;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly IRandomColourGenerator _randomColourGenerator;
        private readonly IInputHandler _inputHandler;
        private readonly IDisplay _display;
        private readonly ColourMatchResult _colourMatchResult;
        private readonly TurnCountTracker _turnCountTracker;
        private readonly WinnerChecker _winnerChecker;

        public GameEngine(IRandomColourGenerator randomColourGenerator, IInputHandler inputHandler, IDisplay display)
        {
            _randomColourGenerator = randomColourGenerator;
            _inputHandler = inputHandler;
            _display = display;
            _colourMatchResult = new ColourMatchResult();
            _turnCountTracker = new TurnCountTracker(Constants.MaxTries);
            _winnerChecker = new WinnerChecker(Constants.MasterColoursCount);
        }
        
        public void Run()
        {
            _display.Welcome();
            _display.DisplayAvailableColours();
            var hasAWinner = false;
            
            var masterColours = _randomColourGenerator.Generate();
            //Console.WriteLine("MASTER COLOURS: "+ string.Join(", ", masterColours));

            while (!hasAWinner && !HasMaxTriesReached())
            {
                // Get validated input
                var userAnswer = _inputHandler.TakeInput();

                // User selected menu option
                    // - extension method to make class more explicit and more descriptive
                if (userAnswer.GetSelectedAlternative() == 2)
                {
                    var userSelectedOption = userAnswer.Value2;
                    
                    if (QuitApplication(userSelectedOption)) 
                        break;
                }
                
                var userSelectedColours = userAnswer.Value1;
                
                var matchResult = _colourMatchResult.CreateResult(userSelectedColours, masterColours);

                // Check for any matches
                if (matchResult.Count != 0)
                {
                    _display.TurnCounter(_turnCountTracker.Counter, matchResult);
                    hasAWinner = IsThereAWinner(matchResult);
                }
                else
                {
                    _display.NoColourMatch();
                }
                
                _turnCountTracker.NextTurn();
            }
        }

        private bool QuitApplication(UserOption userSelectedOption)
        {
            if (userSelectedOption != UserOption.Quit) return false;
            _display.Quit();
            return true;
        }

        private bool HasMaxTriesReached()
        {
            if (!_turnCountTracker.HasMaxTriesBeenReached()) return false;
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