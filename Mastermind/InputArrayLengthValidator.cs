using System;
using Mastermind.Enums;

namespace Mastermind
{
    public class InputArrayLengthValidator
    {
        private readonly int _numberOfColours;

        public InputArrayLengthValidator(int numberOfColours)
        {
            _numberOfColours = numberOfColours;
        }

        public void ValidateUserInput(Colour[] userInput)
        {
            var isCorrectLength = IsArrayLengthCorrect(userInput);

            if (!isCorrectLength)
            {
                throw new ArgumentException($"Error: You must pass {_numberOfColours} colours. You have entered {userInput.Length}");
            }
        }

        private bool IsArrayLengthCorrect(Colour[] userInput)
        {
            // return void and throw exception?
            var arrayLength = _numberOfColours;

            return userInput.Length == arrayLength;
        }
    }
}