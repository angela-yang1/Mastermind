using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Enums;

namespace Mastermind
{
    public class ColourMatchResult
    {
        public List<ResultColour> CreateResult(Colour[] masterColours, Colour[] guesses)
        {
            var result = new List<ResultColour>();
            var guessesList = guesses.ToList();
            var masterColoursList = masterColours.ToList();
            
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (guessesList[i] == masterColoursList[i])
                {
                    result.Add(ResultColour.Black);
                    guessesList.RemoveAt(i);
                    masterColoursList.RemoveAt(i);
                }
            }
            
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (masterColoursList.Contains(guessesList[i]))
                {
                    result.Add(ResultColour.White);
                }
            }

            var rng = new Random();
            var shuffledResult = result.OrderBy(a => rng.Next()).ToList();

            return shuffledResult;
        }
    }
}