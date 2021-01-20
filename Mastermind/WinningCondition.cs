using System.Collections.Generic;
using Mastermind.ColoursData;
using System.Linq;

namespace Mastermind
{
    public class WinningCondition
    {
        public List<ResultColours> CreateWinningCondition(Colours[] userGuess, Colours[] selectedColours)
        {
            // list as it may not contain 4 items, but up to 4 items only (depends on how many colour are guessed correctly)
            var output = new List<ResultColours>();

            for (var i = 0; i < userGuess.Length; i++)
            {
                if (userGuess[i] == selectedColours[i])
                {
                    output.Add(ResultColours.Black);
                }
                else if (selectedColours.Contains(userGuess[i]))
                {
                    output.Add(ResultColours.White);
                }
            }

            return output;
        }
    }
}