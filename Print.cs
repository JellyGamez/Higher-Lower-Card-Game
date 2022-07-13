using Core;

class Print
{
    public void PrintCurrentCard(Card card)
    {
        Console.WriteLine("Current card is " + card);
       
    }
    public int GetInput()
    {
        var number = Console.ReadLine();
        return number == null ? 0 : Int32.Parse(number);
    }
    public void PrintMenu()
    {
        Console.WriteLine("1 - Guess");
        Console.WriteLine("2 - Bet");
        Console.WriteLine("3 - Check balance");
    }
    public void GuessInstructions()
    {
        Console.WriteLine("-1 = lower, 0 = equal, 1 = greater");
    }

}