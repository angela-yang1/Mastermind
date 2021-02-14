using System;
using System.Linq;
using Mastermind.Exceptions;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class ConsoleErrorHandler : IErrorHandler
    {
        public void DisplayParseExceptionMessage(ParseException e)
        {
            Console.WriteLine($"\n{string.Join(", ", e.InvalidColourInput)} is not a valid colour.");
        }

        public void DisplayLengthExceptionMessage(LengthException e)
        {
            Console.WriteLine($"\nError: You must pass {e.MasterColoursCount} colours. You have entered {e.InputColourCount}");
        }
    }
}