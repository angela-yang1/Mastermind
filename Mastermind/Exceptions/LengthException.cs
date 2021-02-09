using System;

namespace Mastermind.Exceptions
{
    public class LengthException : Exception
    {
        public int MasterColourCount { get; }
        public int InputColourCount { get; }

        public LengthException(int masterColourCount, int inputColourCount)
        {
            MasterColourCount = masterColourCount;
            InputColourCount = inputColourCount;
        }
    }
}