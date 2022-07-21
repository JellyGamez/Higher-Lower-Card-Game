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
        
        public void PrintCurrentRound(int round)
        {
            Console.WriteLine($"Round #{round}\n");
        }
    }
}