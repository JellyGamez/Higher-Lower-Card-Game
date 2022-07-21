
// Notes
// - Cards: Ace = 1, J = 11, Q = 12, K = 13
// 52 total cards
// Options: Higher, Lower, Equal

// System picks first card
// User inputs option
// System picks second card
// If user is right then rewatd, otherwise penalize

// SOLID Principles = S.O.L.I.D.

// S - Single Responsability
// O - Open-Closed 
// L - Liskov Substition
// I - Interface Segration
// D - Dependency Inversion

// Next Time:
// - Return user option with generic types
// - Improve UI - Show menu inline, stacked, etc/
// - Resolve warnings - homework
// - Bet class - Homework

using Core;

Game game = new Game();
Print print = new Print();
Random rnd = new Random();

string? name;
do 
{
    Console.Write("Enter your player name: ");
    name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
        Console.WriteLine("Invalid name");
} while (string.IsNullOrEmpty(name));

Console.WriteLine($"Welcome, {name}!\n");

var defaultbet = 0;

bool invalidAmount = true;
do
{
    try 
    {
        defaultbet = print.GetInput("Enter default betting amount: ");
        invalidAmount = false;
    } 
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }

} while (invalidAmount);

var InitAmount = 500;

Betting betting = new Betting(defaultbet);
User user = new User(name, new Wallet(InitAmount));
User AI = new User("AI", new Wallet(InitAmount));

Menu UserGuessMenu = new Menu("UserGuess", new List<MenuItem>{
    new MenuItem("l", "lower"),
    new MenuItem("e", "equal"),
    new MenuItem("h", "higher")
});
Menu LoseMenu = new Menu("Lose", new List<MenuItem>{
    new MenuItem("y", "yes"),
    new MenuItem("n", "no")
});

void NextRound()
{
    game.NextRound();
}

void Raise()
{
    Console.Write("Do you want to raise? (y/n):");
    if (Console.ReadLine() == "y")
    {       
        bool invalidAmount = true;
        int raise = 0;
        do
        {
            try 
            {
                raise = print.GetInput("Enter amount: ");
                if (user.Wallet.Has(raise))
                {
                    invalidAmount = false;
                    
                    betting.Raise(user, raise);
                    if (AI.Wallet.Has(raise))
                        betting.Raise(AI, raise);
                    else
                        betting.Raise(AI, AI.Wallet.Balance);
                } 
                else 
                    Console.WriteLine("Insufficent funds.");
            } 
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        } while (invalidAmount);
    }
}

string GetAIGuess() 
{
    var AIGuess = rnd.Next(0, UserGuessMenu.Items.Count());
    return UserGuessMenu.Items[AIGuess].Id;
}

void Reset()
{
    game = new Game();
    user = new User(user.Name, new Wallet(InitAmount));
    AI = new User(AI.Name, new Wallet(InitAmount));
}

bool isrunning = true;

while (isrunning)
{
    betting.Bet(new List<User> {user, AI});

    print.PrintCurrentRound(game.CurrentRound);
    print.PrintCurrentCard(game.CurrentCard);
    Console.WriteLine(user);
    Console.WriteLine(AI);

    game.GenerateNextCard();

    string AIGuess = GetAIGuess();

    UserGuessMenu.Show("Press the following based on your guess: ");
    string UserGuess = UserGuessMenu.Choose();

    if (AIGuess != UserGuess)
        Raise();
   
    bool playerIsRight = game.CheckGuess(UserGuess);
    bool aiIsRight = game.CheckGuess(AIGuess);
   
    if (playerIsRight && aiIsRight)
    {
        Console.WriteLine("You were correct!\n");
        betting.Split(new List<User> {user, AI});
        betting.ResetBet();
    } 
    else  
    {
        if (playerIsRight) 
        {
            Console.WriteLine("You were correct!\n");
            betting.Won(user);
            betting.Lost(AI);
        } 
        else 
        {
            Console.WriteLine("You were wrong!\n");
            betting.Lost(user);
            betting.Won(AI);
        }
        betting.ResetBet();
    }

    if (user.LoseCondition() || AI.LoseCondition())
    {
        Console.WriteLine(user.LoseCondition() ? "You lost!\n" : "You won!\n");
        Console.WriteLine($"You survived {game.CurrentRound} rounds");
        Console.WriteLine($"You guessed {user.Correct} correct and {user.Wrong} wrong\n");

        LoseMenu.Show("Begin a new game?");
        string option = LoseMenu.Choose();
        if (option == "y")
            Reset();
        else
            isrunning = false;
    } 
    else 
        NextRound();
}
