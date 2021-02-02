using System.Globalization;

namespace Mastermind
{
    public static class InputReceiverParser
    {
        public static string ParseUserInput(string userInput)
        {
            if (userInput != null)
            {
                userInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput.ToLower());
            }

            return userInput;
        }
    }
}