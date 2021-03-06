using System.Collections.Generic;
using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IDisplay
    {
        public void Welcome();
        public void AvailableColours();
        public void Won();
        public void NoColourMatch();
        public void MaxGuesses();
        public void Quit();
        public void TurnCounter(int turnCount, List<ResultColour> guessResult);
    }
}