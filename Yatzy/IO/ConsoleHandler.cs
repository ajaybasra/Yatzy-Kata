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
    public System.ConsoleKey ShowIntro()
    {
        _writer.WriteLine("🎲 Welcome to Yatzy! 🎲");
        _writer.Write("Press any key to play!");
        return _reader.ReadKey().Key;
    }

    public bool WantToQuit(int remainingRounds)
    {
        var currentRound = 15 - remainingRounds + 1;
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine($"Your current round is {currentRound}.");
        _writer.WriteLine($"There are {remainingRounds - 1} rounds left before the game finishes.");
        _writer.Write("Press [q] if you want to quit, or any other key to keep playing.");
        return _reader.ReadKey().Key == ConsoleKey.Q;

    }

    public void ShowDiceRolls(int[] diceRolls)
    {
        var diceRollsString = "";
        
        for (var i = 0; i < diceRolls.Length; i++)
        {
            diceRollsString += $"Dice {i}: {diceRolls[i]}\n";
        }
        _writer.WriteLine("");
        _writer.WriteLine("");
        _writer.WriteLine("Below are the dice which you have rolled:");
        _writer.WriteLine(diceRollsString);
    }

    public bool WantToReroll()
    {
        _writer.Write("If you would like to reroll enter [r], otherwise to continue press any other key.");
        return _reader.ReadKey().Key == ConsoleKey.R;
    }

    public bool WantToHold()
    {
        _writer.WriteLine("Would you like to hold any dice? Press [y] to hold or any other key to continue");
        return _reader.ReadKey().Key == ConsoleKey.Y;
    }

    public string GetDiceToHold()
    {
        _writer.WriteLine("Enter the dice you would like to hold in the following format: x,y,z");
        var userInput = _reader.ReadLine();
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

    public int GetCategory()
    {
        _writer.Write("Enter the corresponding number for the category you would like to play: ");
        var userInput = _reader.ReadLine();
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
