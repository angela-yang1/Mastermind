using System.Collections.Generic;
using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IDisplay
    {
        public void Welcome();
        public void DisplayAvailableColours();
        public void Win();
        public void NoColourMatch();
        public void MaxGuesses();
        public void Quit();
        public void TurnCounter(int turnCount, List<ResultColour> guessResult);
    }
}