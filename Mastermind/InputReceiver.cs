using System;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class InputReceiver : IInputReceiver
    {
        public string GetUserInput()
        {
            Console.WriteLine
                ("\nPlease enter your four guesses (separated by a comma), " +
                 "or 'Quit' to quit the game:");
            
            var userInput = Console.ReadLine();
 
            return userInput;
        }
    }
}