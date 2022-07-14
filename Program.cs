
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

// TODO;
// - Improve UI
// - Validate Bet amount
// - Bonus; Try implement basic AI

using Core;

Console.Write("Enter your player name: ");
var name = Console.ReadLine();
Console.WriteLine($"Welcome, {name}!");
if (name == null)
    return;

Game game = new Game();
Wallet wallet = new Wallet(500);

User user = new User(name, wallet);
Print print = new Print();
bool isrunning = true;
while (isrunning)
{
    print.PrintMenu();
    print.PrintCurrentCard(game.CurrentCard);
    Console.WriteLine($"Your current balance is {user.Wallet.ToString()}");
    var command = user.GetInput();

    switch (command)
    {
        case 1:
            
            print.GuessInstructions();
            var guess = print.GetInput();
            game.GenerateNextCard();

            try {
                if (game.CheckGuess(guess))
                    {
                        Console.WriteLine("Correct!");
                        user.Wallet.add();
                    }
                else
                    {
                        Console.WriteLine("Wrong!");
                        user.Wallet.subtract();
                    }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            game.Advance();
            break;
        case 2:
            user.Wallet.CurrentBet = print.GetInput();
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

    
