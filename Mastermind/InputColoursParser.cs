using System;
using System.Collections.Generic;
using Mastermind.Enums;

namespace Mastermind
{
    public static class InputColoursParser
    {
        public static Colours[] ParseFromString(string userInputToConvert)
        {
            var coloursStringArray = userInputToConvert.Split(", ");
            
            var enumArray = new Colours[Constants.ArrayLength];

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