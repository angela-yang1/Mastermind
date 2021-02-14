using System;
using System.Collections.Generic;
using System.Drawing;
using Figgle;
using Mastermind.Enums;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class ConsoleDisplay : IDisplay
    {
        public void Welcome()
        {
            Console.WriteLine(
                FiggleFonts.Bolger.Render("Mastermind"));
        }

        public void AvailableColours()
        {
            Console.WriteLine("🧠 Here are your available colours: 🧠");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{ Colour.Red }");
            Console.ResetColor();
            Console.Write(", ");
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{ Colour.Blue }");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{ Colour.Green }");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{ Colour.Orange }");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{ Colour.Purple }");
            Console.ResetColor();
            Console.Write(", ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{ Colour.Yellow }\n");
            
            Console.ResetColor();
        }

        public void Won()
        {
            Console.WriteLine("\nAll your guesses match! You've won!\n");
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