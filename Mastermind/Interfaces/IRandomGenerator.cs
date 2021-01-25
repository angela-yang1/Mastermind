using Mastermind;
using Mastermind.Enums;

namespace Mastermind
{
    public interface IRandomGenerator
    {
        public Colours[] Generate();
    }
}