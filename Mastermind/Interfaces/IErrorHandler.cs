using Mastermind.Exceptions;

namespace Mastermind.Interfaces
{
    public interface IErrorHandler
    {
        public void DisplayParseExceptionMessage(ParseException e);
        public void DisplayLengthExceptionMessage(LengthException e);
    }
}