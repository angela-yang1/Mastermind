using System;
using System.Collections.Generic;
using System.Globalization;
using Mastermind.Enums;
using Mastermind.Exceptions;

namespace Mastermind
{
    public static class InputColourParser
    {
        public static Colour[] ParseFromString(string userInputToConvert)
        {
            var inputItemArray = userInputToConvert.Split(",");
            
            var colourArray = new Colour[inputItemArray.Length];

            var invalidColours = new List<string>();

            for(var i = 0; i < inputItemArray.Length; i++)
            {
                var trimmedInput = inputItemArray[i].Trim();
                
                try {
                    var colour = (Colour) Enum.Parse(typeof(Colour), StringToTitleCase(trimmedInput));
                    colourArray[i] = colour;
                }
                catch (ArgumentException) {
                    // add errors to list - custom exception (only once)
                    if (!invalidColours.Contains(trimmedInput))
                    {
                        invalidColours.Add(trimmedInput);
                    }
                }
            }

            if (invalidColours.Count > 0)
            {
                // use ParseException
                //throw new ArgumentException($"{String.Join(", ", invalidColours)} is not a valid colour.");

                throw new ParseException(invalidColours);
            }
            
            // only return after validating user input and converting string[] to enum[]
            return colourArray;
        }
        
        // move into own class to use in InputHandler
        private static string StringToTitleCase(string userInput)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
        }
    }
}