
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
    print.PrintCurrentRound(game.CurrentRound);
    print.PrintCurrentCard(game.CurrentCard);
    print.PrintCurrentBalance(user.Wallet);
    print.GuessInstructions();

    game.GenerateNextCard();

    Random rnd = new Random();
    var AIGuess = rnd.Next(-1, 2);
    Console.WriteLine($"AI's Guess: {AIGuess}");

    var UserGuess = print.GetInput($"{user.Name}'s guess: ");
    Console.WriteLine();
    try 
    {
        if (game.CheckGuess(UserGuess))
            {
                Console.WriteLine("You were correct!\n");
                user.Wallet.add();
            }
        else
            {
                Console.WriteLine("You were wrong!\n");
                user.Wallet.subtract();
            }
        game.NextRound();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}