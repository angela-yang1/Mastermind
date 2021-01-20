using System;
using Mastermind.Interfaces;

namespace Mastermind
{
    public class ConsoleErrorHandler : IErrorHandler
    {
        public void DisplayErrorMessage(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}