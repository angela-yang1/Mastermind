using System;

namespace Mastermind
{
    public static class DisplayMessage
    {
        public static void Welcome()
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

        public static void Win()
        {
            Console.WriteLine("You've won!");
        }

        public static void Lose()
        {
            Console.WriteLine("You've lost!");
        }

        public static void NoColourMatch()
        {
            Console.WriteLine("\nNone of your guesses matched the colours. Please try again");
        }
        
        public static void MaxGuesses()
        {
            Console.WriteLine("Game over! You've reached the maximum guesses of 60");
        }
        
        public static void Quit()
        {
            Console.WriteLine("\nYou've quit the game");
        }
    }
}