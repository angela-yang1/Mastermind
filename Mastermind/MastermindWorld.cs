using System;
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
            _turnCount = new TurnCount(60);
        }
        
        public bool HasAWinner { get; private set; }
        
        // mock up classes - test the loop runs as it should
        // integration test (no mocks) - run Mastermind, assert on string etc
        public void Run()
        {
            Console.WriteLine("Welcome to Mastermind");

            HasAWinner = false;
            
            // generate 4 random colours
            var masterColours = _randomGenerator.Generate();
            Console.WriteLine(string.Join(", ", masterColours));

            // loop until user wins or reaches max 60 guesses
            while (true)
            {
                // get validated input (lowercase/uppercase as well)
                var userAnswer = _gameEngine.GetUserAnswer();
                var guessResult = _winningResult.CreateWinningResult(userAnswer, masterColours);

                // check against guess checker
                HasAWinner = _winnerChecker.HasUserWon(guessResult);
                Console.WriteLine($"Guess {_turnCount.Counter} result is: {string.Join(", ", guessResult)}");

                if (HasAWinner)
                {
                    Console.WriteLine("\nYou've won");
                    break;
                }

                if (_turnCount.HasMaxTriesBeenReached())
                {
                    Console.WriteLine("You lost");
                    break;
                }
                
                _turnCount.NextTurn();
            }
        }
    }
}