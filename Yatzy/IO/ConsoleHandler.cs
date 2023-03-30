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
        var currentRound = 15 - remainingRounds + 1;
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine($"Your current round is {currentRound}.");
        _writer.WriteLine($"There {(remainingRounds - 1 != 1? "are" : "is")} {remainingRounds - 1} {(remainingRounds - 1  != 1? "rounds" : "round")} left before the game finishes.");
        _writer.WriteLine("Press [q] if you want to quit, or any other key to keep playing.");
        return _reader.ReadKey().Key == ConsoleKey.Q;

    }

    public void ShowDiceRolls(int[] diceRolls)
    {
        var diceRollsString = "";
        
        for (var i = 0; i < diceRolls.Length; i++)
        {
            diceRollsString += $"Dice {i + 1}: {diceRolls[i]}\n";
        }
        _writer.WriteLine("");
        _writer.WriteLine("Below are the dice which you have rolled:");
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
    public void ShowOutro(int score)
    {
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine($"GG! Your final score was {score}, hope you had fun!");
    }
};
