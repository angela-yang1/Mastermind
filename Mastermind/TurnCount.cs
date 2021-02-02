namespace Mastermind
{
    public class TurnCount
    {
        private readonly int _maxTries;
        
        public TurnCount(int maxTries)
        {
            _maxTries = maxTries;
            Counter = 1;
        }
        
        public int Counter { get; private set; }

        
        public void NextTurn()
        {
            Counter += 1;
        }

        public bool HasMaxTriesBeenReached()
        {
            return Counter == _maxTries;
        }
    }
}