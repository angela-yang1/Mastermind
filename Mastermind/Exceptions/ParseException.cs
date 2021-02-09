using System;
using System.Collections.Generic;

namespace Mastermind.Exceptions
{
    public class ParseException : Exception
    {
        public List<string> InvalidColourInput { get; }

        public ParseException(List<string> invalidColourInput)
        {
            InvalidColourInput = invalidColourInput;
        }
    }
}