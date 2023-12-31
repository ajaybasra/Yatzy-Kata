using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy.IO;

public class ConsoleHandler : IConsoleHandler
{
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public ConsoleHandler(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }
    public void ShowIntro()
    {
        _writer.WriteLine("🎲 Welcome to Yatzy! 🎲");
        _writer.Write("Press any key to play!");
        _reader.ReadKey();
    }

    public bool WantToQuit(int remainingRounds)
    {
        var currentRound = Constants.TotalNumberOfRounds - remainingRounds + 1;
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine($"It is currently  round {currentRound}.");
        _writer.WriteLine(RoundInfoHandler(remainingRounds));
        _writer.WriteLine("Press [q] if you want to quit, or any other key to keep playing.");
        return _reader.ReadKey().Key == ConsoleKey.Q;

    }

    private string RoundInfoHandler(int remainingRounds)
    {
        var roundInfo =
            $"There {(remainingRounds - 1 != 1 ? "are" : "is")} {remainingRounds - 1} {(remainingRounds - 1 != 1 ? "rounds" : "round")} left before the game finishes.";
        return roundInfo;
    }
    public void ShowDiceRolls(int[] diceRolls)
    {
        var diceRollsString = "";
        
        for (var i = 0; i < diceRolls.Length; i++)
        {
            diceRollsString += $"Dice {i + 1}: {diceRolls[i]}\n";
        }
        _writer.WriteLine("");
        _writer.WriteLine("Rolled Dice:");
        _writer.WriteLine(diceRollsString);
    }

    public bool WantToReRoll(int rollsLeft)
    {
        _writer.WriteLine($"You have {rollsLeft} {(rollsLeft > 1? "rolls" : "roll")} left.");
        _writer.Write("If you would like to reroll enter [r], otherwise to continue press any other key.");
        return _reader.ReadKey().Key == ConsoleKey.R;
    }

    public bool WantToHold()
    {
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine("Would you like to hold any dice? Press [y] to hold or any other key to continue");
        return _reader.ReadKey().Key == ConsoleKey.Y;
    }

    public string GetDiceToHold()
    {
        _writer.WriteLine("");
        _writer.Write("Enter the dice you would like to hold in the following format: x,y,z: ");
        var userInput = _reader.ReadLine().Trim();
        
        while (!Validator.ChosenDiceToHoldAreValid(userInput))
        {
            _writer.Write("Invalid! Enter comma seperated integers between 1 and 5 (inclusive): ");
            userInput = _reader.ReadLine().Trim();
        }
        
        _writer.WriteLine("");
        return userInput;
    }

    public void ShowCategories(List<Category> categories)
    {
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine("Below are the available categories:");
        for (int i = 0; i < categories.Count; i++)
        {
            _writer.WriteLine($"Category {i + 1}: {categories[i].ToString()}");
        }
        _writer.WriteLine("");
    }

    public int GetCategory(List<Category> categories)
    {
        _writer.Write("Enter the corresponding number for the category you would like to play: ");
        var userInput = _reader.ReadLine().Trim();
        
        while (!Validator.ChosenCategoryIsValid(userInput, categories))
        {
            _writer.Write("Enter a valid category number: ");
            userInput = _reader.ReadLine().Trim();
        }
        
        var chosenCategory = int.Parse(userInput) - 1;
        return chosenCategory;
    }

    public void ShowScore(int score)
    {
        _writer.WriteLine("");
        _writer.Write($"Your current score is {score}, keep it up!");
    }
    public void ShowOutro()
    {
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine($"GG! Hope you had fun, check below to see the final scores!");
    }

    public void BotRolledDice()
    {
        _writer.WriteLine("");
        _writer.WriteLine("The bot has rolled the following dice:");
    }

    public void BotDoesNotReRoll()
    {
        _writer.WriteLine("🤖Beep boop! The bot does not re-roll the dice as it is superior, instead it goes directly to the category stage!");
    }

    public void BotChoosesCategory(string chosenCategory)
    {
        _writer.WriteLine($"The bot has chosen to play the {chosenCategory} category.");
    }

    public void BotScore(int score)
    {
        _writer.WriteLine($"The bots current score is {score}! Not too shabby.");
    }

    public void FinalScores(List<IPlayer> playerList)
    {
        foreach (var player in playerList)
        {
            _writer.WriteLine($"{player.Name} ({player.Type.ToString()}) scored {player.Score} 👏 ");
        }
        _writer.WriteLine($"The winner is {playerList.MaxBy(player => player.Score).Name} 🥳");
    }

    public (int, int) GetNumberOfHumansAndBots()
    {
        _writer.WriteLine("");
        _writer.Write("How many human players would like to play? ");
        var numberOfHumansInput = _reader.ReadLine().Trim();
        while (!Validator.NumberOfHumansChosenIsValid(numberOfHumansInput))
        {
            _writer.Write("Enter an integer that is in the range 1-4 (inclusive)!: ");
            numberOfHumansInput = _reader.ReadLine().Trim();
        }

        _writer.Write("How many bots would you like to add to the game? ");
        var numberOfBotsInput = _reader.ReadLine().Trim();
        while (!Validator.NumberOfBotsChosenIsValid(numberOfBotsInput))
        {
            _writer.Write("Enter an integer that is in the range 0-2 (inclusive)!: ");
            numberOfBotsInput = _reader.ReadLine().Trim();
        }
        return (int.Parse(numberOfHumansInput), int.Parse(numberOfBotsInput));
    }
    


};
