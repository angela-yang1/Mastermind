using BCL;
using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IInputHandler
    {
        public Either<Colour[], UserOption> TakeInput();
    }
}