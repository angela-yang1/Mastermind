using System.Collections.Generic;
using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IDisplayMessage
    {
        public void Welcome();
        public void Win();
        public void NoColourMatch();
        public void MaxGuesses();
        public void Quit();
        public void TurnCounter(int turnCount, List<ResultColour> guessResult);
    }
}