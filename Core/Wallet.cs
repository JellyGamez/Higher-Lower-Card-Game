namespace Core 
{
    class Wallet 
    {
        public int Balance {get; private set;}
        public int DefaultBet {get; private set;}
        public int CurrentBet {get; set;}
        
        public Wallet(int balance, int defaultbet) 
        {
            Balance = balance;
            DefaultBet = CurrentBet = defaultbet;
        }

        public Wallet()
        {
            Balance = 0;
            DefaultBet = 0;
        }

        public void add()
        {
            Balance += CurrentBet;
            CurrentBet = DefaultBet;
        }

        public void subtract()
        {
            Balance -= CurrentBet;
            CurrentBet = DefaultBet;
        }
        
        public void raise(int raise)
        {
            CurrentBet += raise;
        }

        public override string ToString()
        {
            return Balance.ToString();
        }
    }
}