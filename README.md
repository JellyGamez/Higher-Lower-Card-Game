# Higher Lower Card Game
A terminal-based recreation of the Higher Lower card game written in C#.

## Features
- The game is played in rounds. Each round players guess whether the next card will be higher, lower or equal
- You play against an AI opponent
- Betting:

  - Set up default betting amount at the beginning a new game
  - Option to raise the bet when your guess differs from the AI's

- Option to either quit or start over when current game ends
- Win Condition: The player wins when AI's balance reaches 0
- Lose Condition: The player loses when their balance reaches 0

## Quick Start

### 1. Clone the project

```bash
git clone https://github.com/JellyGamez/Higher-Lower-card-game.git
```

### 2. Go to the project directory

```bash
cd Higher-Lower-card-game
```

### 3. Launch the game

```bash
dotnet run
```

## Note
This project uses net7.0 by default. If you wish to use other .net versions, update the following in the `demo.csproj` file:

`<TargetFramework>` **your version here** `</TargetFramework>`
