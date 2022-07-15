namespace Core
{
    class Print
    {
        public void PrintCurrentCard(Card card)
        {
            Console.WriteLine($"Current card is {card}");
        }

        public int GetInput(string message)
        {
            Console.Write(message);
            var number = Console.ReadLine();
            return number == null ? 0 : Int32.Parse(number);
        }

        public void PrintMenu()
        {
            Console.Write("1 - Guess\n2 - Bet\n\n");
        }

        public void GuessInstructions()
        {
            Console.WriteLine("Press the following based on your guess: -1 = lower, 0 = equal, 1 = greater\n");
        }
        
        public void PrintCurrentRound(int round)
        {
            Console.WriteLine($"Round #{round}\n");
        }
    }
}