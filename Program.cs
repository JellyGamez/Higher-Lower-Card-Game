
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
using System;

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

bool isrunning = true;
while (isrunning)
{
    if (user.LoseCondition())
    {
        Console.WriteLine("You lost!\n");
        Console.WriteLine($"You survived {game.CurrentRound - 1} rounds");
        Console.WriteLine($"You guessed {user.Correct} correct and {user.Wrong} wrong\n");
        break;
    }
    else if (AI.LoseCondition())
    {
        Console.WriteLine("You won!");
        Console.WriteLine($"You survived {game.CurrentRound - 1} rounds");
        Console.WriteLine($"You guessed correct {user.Correct} times and wrong {user.Wrong} times");
        break;
    }
    print.PrintCurrentRound(game.CurrentRound);
    print.PrintCurrentCard(game.CurrentCard);
    print.PrintCurrentBalance(user.Wallet, user.ToString());
    print.PrintCurrentBalance(AI.Wallet, AI.ToString());
    print.GuessInstructions();

    game.GenerateNextCard();

    var AIGuess = rnd.Next(-1, 2);
    Console.WriteLine($"AI's Guess: {AIGuess}");

    var UserGuess = print.GetInput($"{user.Name}'s guess: ");
    Console.WriteLine();

    if (UserGuess != -1 && UserGuess != 0 && UserGuess != 1)
    {
        Console.WriteLine("Invalid guess");
        continue;
    }

    if (AIGuess != UserGuess)
    {
        Console.Write("Do you want to raise? (y/n):");
        if (Console.ReadLine() == "y")
        {
            Console.WriteLine("Enter amount: ");
            if(!user.Wallet.raise(print.GetInput("")))
                Console.WriteLine("You don't have enough funds!");
        }
    }

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

    AI.Wallet.ResetBet();
    user.Wallet.ResetBet();

    game.NextRound();
}