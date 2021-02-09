using System;
using System.Linq;
using Mastermind.Exceptions;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class ConsoleErrorHandler : IErrorHandler
    {
        public void DisplayParseErrorMessage(ParseException e)
        {
            Console.WriteLine($"\n{string.Join(", ", e.InvalidColourInput)} is not a valid colour.");
        }

        public void DisplayLengthErrorMessage(LengthException e)
        {
            Console.WriteLine($"\nError: You must pass {e.MasterColourCount} colours. You have entered {e.InputColourCount}");
        }
    }
}