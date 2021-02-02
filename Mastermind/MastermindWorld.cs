using System;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class MastermindWorld
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IGameEngine _gameEngine;
        private readonly WinnerChecker _winnerChecker;
        private readonly WinningResult _winningResult;
        private readonly TurnCount _turnCount;

        public MastermindWorld(IRandomGenerator randomGenerator, IGameEngine gameEngine)
        {
            _randomGenerator = randomGenerator;
            _gameEngine = gameEngine;
            _winnerChecker = new WinnerChecker();
            _winningResult = new WinningResult();
            _turnCount = new TurnCount(Constants.MaxTries);
        }
        
        public bool HasAWinner { get; private set; }
        
        
        public void Run()
        {
            DisplayMessage.Welcome();

            HasAWinner = false;
            
            // generate 4 random colours
            var masterColours = _randomGenerator.Generate();
            Console.WriteLine(string.Join(", ", masterColours));

            // loop until user wins or reaches max 60 guesses
            while (true)
            {
                // get validated input
                var userAnswer = _gameEngine.TakeATurn();
                
                // if user wants to quit
                if (QuitApplication(userAnswer)) 
                    break;
                
                // check for matching colours (output: black/white)
                var guessResult = _winningResult.CreateWinningResult(userAnswer, masterColours);

                // check for any matches
                if (guessResult.Count != 0)
                {
                    // check against guess checker
                    HasAWinner = _winnerChecker.HasUserWon(guessResult);
                    Console.WriteLine($"\nGuess {_turnCount.Counter} result is: {string.Join(", ", guessResult)}");
                }
                else
                {
                    DisplayMessage.NoColourMatch();
                }
                
                if (IsThereAWinner()) 
                    break;

                if (MaxTriesReached()) 
                    break;
            }
        }

        private bool QuitApplication(Colours[] userAnswer)
        {
            if (userAnswer != null) return false;
            DisplayMessage.Quit();
            return true;
        }

        private bool MaxTriesReached()
        {
            if (_turnCount.HasMaxTriesBeenReached())
            {
                DisplayMessage.MaxGuesses();
                return true;
            }

            _turnCount.NextTurn();
            return false;
        }

        private bool IsThereAWinner()
        {
            if (!HasAWinner) return false;
            DisplayMessage.Win();
            return true;
        }
    }
}