namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGen = new RandomColourGenerator(Constants.MasterColoursCount);
            var userInput = new InputReceiver();
            var errorHandler = new ConsoleErrorHandler();
            var consoleDisplay = new ConsoleDisplay();
            var inputHandler = new InputHandler(userInput, errorHandler);
            
            var gameEngine = new GameEngine(randomGen, inputHandler, consoleDisplay);
            gameEngine.Run();
        }
    }
}