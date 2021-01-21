﻿using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var random = new RandomGenerator();
            var computerColours = random.Generate();
            Console.WriteLine(string.Join(", ", computerColours));
            
            var userInput = new UserInput();
            var errorHandler = new ConsoleErrorHandler();
            var gameEngine = new GameEngine(userInput, errorHandler);
            var userAnswer = gameEngine.GetUserAnswer();
            //Console.WriteLine(userAnswer.ToString());
            
            // foreach (var c in test)
            // {
            //     Console.WriteLine(c.ToString());
            // }
        }
    }
}