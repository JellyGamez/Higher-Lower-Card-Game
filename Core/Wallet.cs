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

        public void add(int amount)
        {
            Balance += amount;
        }

        public void subtract(int amount)
        {
            Balance -= amount;
        }
        
        public void ResetBet()
        {
            CurrentBet = DefaultBet;
        }

        public bool raise(int amount)
        {
            if (CurrentBet + amount <= Balance)
            {
                CurrentBet += amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Balance.ToString();
        }
    }
}