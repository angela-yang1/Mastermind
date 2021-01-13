using Mastermind.Data;

namespace Mastermind
{
    public class InputValidator
    {
        // to validate:
            // array length
            // valid colours
            
        public bool CheckArrayLength(Colours[] userInput)
        {
            var arrayLength = 4;

            return userInput.Length == arrayLength;
        }
    }
}