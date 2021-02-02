namespace Mastermind
{
    public class TurnCount
    {
        private readonly int _maxTries;
        
        public TurnCount()
        {
            _maxTries = Constants.MaxTries;
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