using System;
using Mastermind.ColoursData;

namespace Mastermind
{
    public class ParseUserInput
    {
        public Colours[] ParseUserInput(string userInputToConvert)
        {
            // check there are 4 items
            // add user input to list then convert to array?
            var coloursStringArray = userInputToConvert.Split(", ");
            
            var enumArray = new Colours[coloursStringArray.Length];

            for(var i = 0; i < coloursStringArray.Length; i++)
            {
                try {
                    var enumColour = (Colours) Enum.Parse(typeof(Colours), coloursStringArray[i]);
                    enumArray[i] = enumColour;
                }
                catch (ArgumentException) {
                    // add errors to list - custom exception
                    Console.WriteLine("{0} is not a member of the Colours enum.", coloursStringArray[i]);
                }
            }
            // only return after validating user input and converting string[] to enum[]
            return enumArray;
        }
    }
}