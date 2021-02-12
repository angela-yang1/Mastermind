namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGen = new RandomColourColourGenerator(Constants.MasterColoursCount);
            var inputReceiver = new InputReceiver();
            var errorHandler = new ConsoleErrorHandler();
            var consoleDisplay = new ConsoleDisplay();
            var inputHandler = new InputHandler(inputReceiver, errorHandler);
            
            var gameEngine = new GameEngine(randomGen, inputHandler, consoleDisplay);
            gameEngine.Run();
        }
    }
}