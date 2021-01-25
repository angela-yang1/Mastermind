using System;
using System.Collections.Generic;
using Mastermind.Enums;

namespace Mastermind
{
    public static class ColoursParser
    {
        public static Colours[] ParseFromString(string userInputToConvert)
        {
            // check there are 4 items
            // add user input to list then convert to array?
            var coloursStringArray = userInputToConvert.Split(", ");
            
            var enumArray = new Colours[coloursStringArray.Length];

            var invalidColours = new List<string>();

            for(var i = 0; i < coloursStringArray.Length; i++)
            {
                try {
                    var enumColour = (Colours) Enum.Parse(typeof(Colours), coloursStringArray[i]);
                    enumArray[i] = enumColour;
                }
                catch (ArgumentException) {
                    // add errors to list - custom exception
                    invalidColours.Add(coloursStringArray[i]);
                }
            }

            if (invalidColours.Count > 0)
            {
                throw new ArgumentException($"{String.Join(", ", invalidColours)} is not a valid colour.");
            }
            
            // only return after validating user input and converting string[] to enum[]
            return enumArray;
        }
    }
}