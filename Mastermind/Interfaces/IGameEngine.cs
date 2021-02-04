using BCL;
using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IGameEngine
    {
        public Either<Colour[], UserOption> TakeATurn();
    }
}