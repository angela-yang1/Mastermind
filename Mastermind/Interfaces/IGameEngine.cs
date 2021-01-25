using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IGameEngine
    {
        public Colours[] GetUserAnswer();
    }
}