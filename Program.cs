
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
// - Corelate menu options with UI
// - Return user option with generic types
// - Introduce MenuItem
// - Improve UI - Show menu inline, stacked, etc/

using Core;

Console.Write("Enter your player name: ");
var name = Console.ReadLine();
Console.WriteLine($"Welcome, {name}!\n");
if (name == null)
    return;
Console.Write("Default betting amount: ");
var DefaultBet = Int32.Parse(Console.ReadLine());

Game game = new Game();
User user = new User(name, new Wallet(500, DefaultBet));
User AI = new User("AI", new Wallet(500, DefaultBet));
Print print = new Print();
Random rnd = new Random();
Menu UserGuessMenu = new Menu("UserGuess", new List<string>{"-1", "0", "1"});

var options = new List<int>{-1, 0, 1};

bool isrunning = true;

void NextRound(){
    AI.Wallet.ResetBet();
    user.Wallet.ResetBet();
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
                    user.Wallet.add(raise);
                } else {
                    Console.WriteLine("Insufficent funds.");
                }
                    
            } catch(Exception error){
                Console.WriteLine(error.Message);
            }

        } while(invalidAmount);
    }
}

int GetUserGuess(){
    int UserGuess;
    bool invalidOption = false;

    do {
        UserGuess = print.GetInput($"{user.Name}'s guess: ");
        invalidOption = !options.Contains(UserGuess);
        Console.WriteLine();
    
        if (invalidOption) 
        {
            Console.WriteLine("Invalid guess");
        }

    } while(invalidOption);


    return UserGuess;
}

int GetAIGuess() {
    var AIGuess = rnd.Next(-1, 2);
    Console.WriteLine($"AI's Guess: {AIGuess}");

    return AIGuess;
}

while (isrunning)
{
    
    print.PrintCurrentRound(game.CurrentRound);
    print.PrintCurrentCard(game.CurrentCard);
    Console.WriteLine(user);
    Console.WriteLine(AI);
    print.GuessInstructions();

    game.GenerateNextCard();

    int AIGuess = GetAIGuess();
    // TODO: Better approach
    int UserGuess = Int32.Parse(UserGuessMenu.Choose());

    if (AIGuess != UserGuess)
    {
      Raise();
    }

    // TODO: Suggestion - another approach
    if (game.CheckGuess(UserGuess))
    {
        Console.WriteLine("You were correct!\n");
        user.Wallet.add(user.Wallet.CurrentBet);
        user.Correct++;
    }
    else
    {
        Console.WriteLine("You were wrong!\n");
        user.Wallet.subtract(user.Wallet.CurrentBet);
        user.Wrong++;
    }

    if (game.CheckGuess(AIGuess))
        AI.Wallet.add(AI.Wallet.CurrentBet);
    else
        AI.Wallet.subtract(AI.Wallet.CurrentBet);

  
    if(user.LoseCondition() || AI.LoseCondition()){
        Console.WriteLine(user.LoseCondition() ? "You lost!\n" : "You won!\n");
        Console.WriteLine($"You survived {game.CurrentRound - 1} rounds");
        Console.WriteLine($"You guessed {user.Correct} correct and {user.Wrong} wrong\n");
        isrunning = false;
    } else {
        // TODO: Suggestion - another approach
        NextRound();
    }
}