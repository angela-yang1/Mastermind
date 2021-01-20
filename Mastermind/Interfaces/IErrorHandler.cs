using System;

namespace Mastermind.Interfaces
{
    public interface IErrorHandler
    {
        public void DisplayErrorMessage(Exception e);
    }
}