using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class ParseException : Exception
    {
        public List<string> ColoursInput { get; }

        public ParseException(List<string> coloursInput)
        {
            ColoursInput = coloursInput;
        }
    }
}