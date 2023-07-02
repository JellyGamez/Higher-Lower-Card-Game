namespace Core
{
    class UI
    {
        public static void PrintCurrentCard(Card card)
        {
            Console.WriteLine($"Current card is {card}");
        }
        public static void PrintCurrentRound(int round)
        {
            Console.WriteLine($"Round #{round}\n");
        }
        public static int GetInteger(string message)
        {
            Console.Write(message);
            var number = Console.ReadLine();
            if (number == null || Int32.Parse(number) == 0)
            {
                throw new Exception("Invalid amount");
            }
            return Int32.Parse(number);
        }
    }
}