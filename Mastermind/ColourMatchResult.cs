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

            // black
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (guessesList[i] == masterColoursList[i])
                {
                    result.Add(ResultColour.Black);
                    guessesList.RemoveAt(i);
                    masterColoursList.RemoveAt(i);
                }
            }

            // white
            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (masterColoursList.Contains(guessesList[i]))
                {
                    result.Add(ResultColour.White);
                }
            }
            
            //return result.OrderBy(x => Guid.NewGuid()).ToList();
            Shuffle(result);
            return result;
        }

        // look into using with OrderBy - rng
        private void Shuffle(List<ResultColour> matchResult)
        {
            var random = new Random();
            var num = matchResult.Count;

            while (num > 1)
            {
                num--;
                var randomNum = random.Next(num + 1);
                var value = matchResult[randomNum];
                matchResult[randomNum] = matchResult[num];
                matchResult[num] = value;
            }
        }
    }
}