class Wallet {


    public int Balance {get; private set;}
    public int CurrentBet {get; set;}

    public Wallet(int balance) {
        Balance = balance;
    }

    public Wallet(){
        Balance = 0;
    }

    public void add()
    {
        Balance += CurrentBet;
        CurrentBet = 0;
    }
    public void subtract()
    {
        Balance -= CurrentBet;
        CurrentBet = 0;
    }
    public override string ToString()
    {
        return Balance.ToString();
    }
}