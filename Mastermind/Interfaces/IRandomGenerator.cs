using Mastermind;
using Mastermind.ColoursData;

namespace Mastermind
{
    public interface IRandomGenerator
    {
        public Colours[] Generate();
    }
}