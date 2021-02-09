using System;
using Mastermind.Exceptions;

namespace Mastermind.Interfaces
{
    public interface IErrorHandler
    {
        public void DisplayParseErrorMessage(ParseException e);
        public void DisplayLengthErrorMessage(LengthException e);
    }
}