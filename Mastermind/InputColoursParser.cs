using System;
using System.Collections.Generic;
using System.Globalization;
using Mastermind.Enums;

namespace Mastermind
{
    public static class InputColoursParser
    {
        public static Colour[] ParseFromString(string userInputToConvert)
        {
            var coloursStringArray = userInputToConvert.Split(", ");
            
            var enumArray = new Colour[coloursStringArray.Length];

            var invalidColours = new List<string>();

            for(var i = 0; i < coloursStringArray.Length; i++)
            {
                try {
                    var enumColour = (Colour) Enum.Parse(typeof(Colour), StringToTitleCase(coloursStringArray[i]));
                    enumArray[i] = enumColour;
                }
                catch (ArgumentException) {
                    // add errors to list - custom exception
                    invalidColours.Add(coloursStringArray[i]);
                }
            }

            if (invalidColours.Count > 0)
            {
                // use ParseException
                throw new ArgumentException($"{String.Join(", ", invalidColours)} is not a valid colour.");
            }
            
            // only return after validating user input and converting string[] to enum[]
            return enumArray;
        }
        
        // move into own class to use in GameEngine
        private static string StringToTitleCase(string userInput)
        {
            userInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
            return userInput;
        }
    }
}