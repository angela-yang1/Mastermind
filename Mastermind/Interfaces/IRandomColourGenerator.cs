using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IRandomColourGenerator
    {
        public Colour[] Generate();
    }
}