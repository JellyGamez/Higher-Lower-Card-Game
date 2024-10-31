# Higher Lower Card Game
A terminal-based implementation of the well-known higher lower card game, developed in C#. This was my first hands-on experience with Object Oriented Programming and SOLID principles, providing a valuable learning opportunity.

## Features
- The game is played in rounds. Each round players guess whether the next card will be higher, lower or equal

- You play against an AI opponent

- Option to set a default betting amount at the beginning a new game

- Option to raise the bet when your guess differs from the AI's

- Option to either quit or start over when current game ends

- Win Condition: You bring the AI's balance down to 0

- Lose Condition: The AI brings your balance down to 0

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
This project uses .NET 8.0 by default. If you wish to use other .net versions, update the following in the `demo.csproj` file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>

    // Your version here
    <TargetFramework>net8.0</TargetFramework>

    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```
