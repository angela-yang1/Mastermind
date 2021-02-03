using System;
using Mastermind.Enums;

namespace Mastermind
{
    public class InputArrayLengthValidator
    {
        private readonly int _userInputLength;

        public InputArrayLengthValidator(int userInputLength)
        {
            _userInputLength = userInputLength;
        }

        public void ValidateUserInput(Colours[] userInput)
        {
            var arrayLength = IsArrayLengthFour(userInput);

            if (!arrayLength)
            {
                throw new ArgumentException($"Error: You must pass 4 colours. You have entered {userInput.Length}");
            }
        }

        private bool IsArrayLengthFour(Colours[] userInput)
        {
            // return void and throw exception?
            var arrayLength = _userInputLength;

            return userInput.Length == arrayLength;
        }
    }
}