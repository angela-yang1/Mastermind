using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Enums;

namespace Mastermind
{
    public class WinningResult
    {
        public List<ResultColour> CreateWinningResult(Colour[] guesses, Colour[] selectedColours)
        {
            var result = new List<ResultColour>();
            var guessesList = guesses.ToList();
            var selectedColoursList = selectedColours.ToList();

            // black
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (guessesList[i] == selectedColoursList[i])
                {
                    result.Add(ResultColour.Black);
                    guessesList.RemoveAt(i);
                    selectedColoursList.RemoveAt(i);
                }
            }

            // white
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (selectedColoursList.Contains(guessesList[i]))
                {
                    result.Add(ResultColour.White);
                }
            }
            
            return result.OrderBy(x => Guid.NewGuid()).ToList();;
        }
    }
}