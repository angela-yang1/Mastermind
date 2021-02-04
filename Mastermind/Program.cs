using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGen = new RandomColourGenerator(Constants.NumberOfColours);
            var userInput = new InputReceiver();
            var errorHandler = new ConsoleErrorHandler();
            var displayMessage = new DisplayMessage();
            var gameEngine = new GameEngine(userInput, errorHandler);
            
            var mastermind = new MastermindWorld(randomGen, gameEngine, displayMessage);
            mastermind.Run();
        }
    }
}