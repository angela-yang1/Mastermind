using System;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class ErrorHandler : IErrorHandler
    {
        public void DisplayErrorMessage(ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}