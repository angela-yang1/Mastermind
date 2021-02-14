using System;

namespace Mastermind.Exceptions
{
    public class LengthException : Exception
    {
        public int MasterColoursCount { get; }
        public int InputColourCount { get; }

        public LengthException(int masterColoursCount, int inputColourCount)
        {
            MasterColoursCount = masterColoursCount;
            InputColourCount = inputColourCount;
        }
    }
}