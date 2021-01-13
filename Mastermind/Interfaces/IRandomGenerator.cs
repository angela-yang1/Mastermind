using Mastermind;
using Mastermind.Data;

namespace Mastermind
{
    public interface IRandomGenerator
    {
        public Colours[] Generate();
    }
}