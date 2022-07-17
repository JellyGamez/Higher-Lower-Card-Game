
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
Console.Write("Enter your player name: ");
var name = Console.ReadLine();
var InitAmount = 500;
Console.WriteLine($"Welcome, {name}!\n");
if (name == null)
    return;
Console.Write("Default betting amount: ");

var DefaultBet = Int32.Parse(Console.ReadLine());
var CurrentBet = 0;

Game game = new Game();
User user = new User(name, new Wallet(InitAmount));
User AI = new User("AI", new Wallet(InitAmount));
Print print = new Print();
Random rnd = new Random();

Menu UserGuessMenu = new Menu("UserGuess", new List<MenuItem>{
    new MenuItem("l", "lower"),
    new MenuItem("e", "equal"),
    new MenuItem("h", "higher")
});
Menu LoseMenu = new Menu("Lose", new List<MenuItem>{
    new MenuItem("y", "yes"),
    new MenuItem("n", "no")
});

bool isrunning = true;

void NextRound(){
    game.NextRound();
}

void Raise(){
Console.Write("Do you want to raise? (y/n):");
    if (Console.ReadLine() == "y") // TODO: better validation 
    {       
        bool invalidAmount = true;
        int raise = 0;
        do
        {
            try {
                raise = print.GetInput("Enter amount: ");
                if (user.Wallet.Greater(raise)){
                    invalidAmount = false;
                    user.Wallet.subtract(raise);
                    if (AI.Wallet.Greater(raise))
                    {
                        AI.Wallet.subtract(raise); // Check if has money, if not go all in
                        CurrentBet += 2 * raise;
                    }
                    else
                    {
                        CurrentBet += raise + AI.Wallet.Balance;
                        AI.Wallet.subtract(AI.Wallet.Balance);
                    }
                } 
                else 
                {
                    Console.WriteLine("Insufficent funds.");
                }
                    
            } catch(Exception error){
                Console.WriteLine(error.Message);
            }

        } while(invalidAmount);
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
while (isrunning)
{
    CurrentBet += 2 * DefaultBet;
    user.Wallet.subtract(DefaultBet);
    AI.Wallet.subtract(DefaultBet);

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
        user.Correct++;
        user.Wallet.add(CurrentBet/2);
        AI.Wallet.add(CurrentBet/2);
        CurrentBet = 0;
    } 
    else 
    {
        if (playerIsRight) 
        {
            Console.WriteLine("You were correct!\n");
            user.Correct++;
            user.Wallet.add(CurrentBet);
        } 
        else 
        {
            Console.WriteLine("You were wrong!\n");
            user.Wrong++;
            AI.Wallet.add(CurrentBet);
        }
        CurrentBet = 0;
    }

    if (user.LoseCondition() || AI.LoseCondition())
    {
        Console.WriteLine(user.LoseCondition() ? "You lost!\n" : "You won!\n");
        Console.WriteLine($"You survived {game.CurrentRound - 1} rounds");
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
