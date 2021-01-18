using System;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class UserInput : IUserInput
    {
        public string GetUserInput()
        {
            Console.WriteLine("\nPlease enter your four guesses (separated by a comma):");
            var userInput = Console.ReadLine();
            
            return userInput;
        }
    }
}