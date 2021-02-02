using System;
using System.Globalization;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class UserInput : IUserInput
    {
        public string GetUserInput()
        {
            // separate getting user input and converting toUpperCase
            Console.WriteLine
                ("\nPlease enter your four guesses (separated by a comma), " +
                 "or 'Quit' to quit the game:");
            
            var userInput = Console.ReadLine();
            
            if (userInput != null)
            {
                userInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput.ToLower());
            }
            
            return userInput;
        }
    }
}