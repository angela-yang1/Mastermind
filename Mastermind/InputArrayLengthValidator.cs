using System;
using Mastermind.Enums;
using Mastermind.Exceptions;

namespace Mastermind
{
    public class InputArrayLengthValidator
    {
        private readonly int _masterColoursCount;

        public InputArrayLengthValidator(int masterColoursCount)
        {
            _masterColoursCount = masterColoursCount;
        }

        public void ValidateUserInput(Colour[] userInput)
        {
            if (userInput.Length != _masterColoursCount)
            {
                throw new LengthException(_masterColoursCount, userInput.Length);
            }
        }
    }
}