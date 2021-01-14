using System;
using Mastermind.ColoursData;

namespace Mastermind
{
    public class UserInputValidator
    {
        public bool ValidateUserInput(Colours[] userInput)
        {
            var arrayLength = IsArrayLengthFour(userInput);

            if (!arrayLength)
            {
                throw new ArgumentException("Incorrect number of colours entered");
            }

            return true;
        }

        private bool IsArrayLengthFour(Colours[] userInput)
        {
            // return void and throw exception?
            const int arrayLength = 4;

            return userInput.Length == arrayLength;
        }

        // public bool CheckForValidColours(string userInput, out Colours enumValue)
        // {
        //     // use .contains??
        //     // check if colour valid first - then convert to array, will fail to parse if colour doesn't match anything in the enum
        //     enumValue = default;
        //     var validated = Enum.IsDefined(typeof(Colours), userInput);
        //
        //     if (validated)
        //     {
        //         enumValue = (Colours) Enum.ToObject(typeof(Colours), userInput);
        //     }
        //     
        //     return validated;
        // }
    }
}