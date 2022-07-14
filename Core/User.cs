namespace Core 
{
    class User
    {
        public string Name {get; private set;}
        public Wallet Wallet {get; private set;}

        public User(string name, Wallet wallet)
        {
            Name = name;
            Wallet = wallet;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}