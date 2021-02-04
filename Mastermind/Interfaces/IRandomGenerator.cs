using Mastermind.Enums;

namespace Mastermind.Interfaces
{
    public interface IRandomGenerator
    {
        public Colour[] Generate();
    }
}