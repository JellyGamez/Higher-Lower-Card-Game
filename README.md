
# Higher/Lower card game
The classic higher/lower card game written in C#.

## Features
- Played in rounds. Each round guess whether the next card will be higher, lower or equal
- Playing against an **AI** opponent

- Betting
  - Set up default betting amount when starting a new game
  - Option to raise the bet when **player** guess differs from the **AI** guess
- Win condition: When **AI** balance reaches 0
- Lose condition: When **player** balance reaches 0
- Option to either quit or start over when current game ends

## Project setup
```sh
dotnet run
```

## Note
This project uses net7.0 by default. If you wish to use other .net versions, update the following in the `demo.csproj` file:

`<TargetFramework>`**your version here**`</TargetFramework>`
