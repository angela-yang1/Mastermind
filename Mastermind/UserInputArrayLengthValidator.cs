using System;
using Mastermind.Enums;

namespace Mastermind
{
    public class UserInputArrayLengthValidator
    {
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
            const int arrayLength = 4;

            return userInput.Length == arrayLength;
        }
    }
}