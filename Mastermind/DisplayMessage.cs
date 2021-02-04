using System;
using System.Collections.Generic;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class DisplayMessage : IDisplayMessage
    {
        public void Welcome()
        {
            Console.WriteLine("Welcome to Mastermind! \n");
            Console.WriteLine("Here are your available colours:");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red");
            Console.ResetColor();
            Console.Write(", ");
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Blue");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Green");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Orange");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Purple");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Yellow \n");
            
            Console.ResetColor();
        }

        public void Win()
        {
            Console.WriteLine("You've won!");
        }

        public void NoColourMatch()
        {
            Console.WriteLine("\nNone of your guesses matched the colours. Please try again");
        }
        
        public void MaxGuesses()
        {
            Console.WriteLine("Game over! You've reached the maximum guesses of 60");
        }
        
        public void Quit()
        {
            Console.WriteLine("\nYou've quit the game");
        }

        public void TurnCounter(int turnCount, List<ResultColour> guessResult)
        {
            Console.WriteLine($"\nGuess {turnCount} result is: {string.Join(", ", guessResult)}");
        }
    }
}