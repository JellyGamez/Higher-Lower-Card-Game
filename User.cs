class User
{
    public string Name {get; private set;}
    public Wallet Wallet {get; private set;}
    public User(string name, Wallet wallet)
    {
        Name = name;
        Wallet = wallet;
    }
    public int GetInput()
    {
        Console.WriteLine("Your option: ");
        var number = Console.ReadLine();
        return number == null ? 0 : Int32.Parse(number);
    }
    public override string ToString()
    {
        return Name;
    }
    
}