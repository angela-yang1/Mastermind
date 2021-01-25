using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGen = new RandomGenerator();
            var userInput = new UserInput();
            var errorHandler = new ConsoleErrorHandler();
            var gameEngine = new GameEngine(userInput, errorHandler);
            
            var mastermind = new MastermindWorld(randomGen, gameEngine);
            mastermind.Run();
        }
    }
}