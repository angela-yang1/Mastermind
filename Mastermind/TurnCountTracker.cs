namespace Mastermind
{
    public class TurnCountTracker
    {
        private readonly int _maxTries;
        
        public TurnCountTracker(int maxTries)
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
            return Counter == _maxTries + 1;
        }
    }
}