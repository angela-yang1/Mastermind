using System.Collections.Generic;
using Mastermind.ColoursData;
using System.Linq;

namespace Mastermind
{
    public class WinningResult
    {
        public List<ResultColours> CreateWinningResult(Colours[] guesses, Colours[] selectedColours)
        {
            var result = new List<ResultColours>();
            var guessesList = guesses.ToList();
            var selectedColoursList = selectedColours.ToList();

            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (guessesList[i] == selectedColoursList[i])
                {
                    result.Add(ResultColours.Black);
                    guessesList.RemoveAt(i);
                    selectedColoursList.RemoveAt(i);
                }
            }

            for (var i = guessesList.Count - 1; i >= 0; i--)
            {
                if (selectedColoursList.Contains(guessesList[i]))
                {
                    result.Add(ResultColours.White);
                }
            }
            return result;
        }
    }
}