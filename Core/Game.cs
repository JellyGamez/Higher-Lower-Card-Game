namespace Core {
    class Game
{
        public Card CurrentCard {get; private set;}
        public Card NextCard {get; private set;}
        public int Round {get; private set;}
         
        public Game() 
        {
            CurrentCard = GenerateNewCard();
        }

        public bool CheckGuess(int guess)
        {
            // -1 = lower, 0 = equal, 1 = greater;
            switch (guess)
            {
                case -1:
                    return NextCard < CurrentCard;
                case 0:
                    return NextCard == CurrentCard;
                case 1:
                    return NextCard > CurrentCard;
                default:
                    throw new Exception("Invalid guess");
            }
        }
        public Card GenerateNewCard()
        {
            Random random = new Random();
            return new Card(random.Next(1, 14));
        }
        public void GenerateNextCard()
        {
            NextCard = GenerateNewCard();
        }
        public void Advance()
        {
            CurrentCard = NextCard;
            Round += 1;
        }
}
}