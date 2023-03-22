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
    public void Intro()
    {
        _writer.WriteLine("🎲 Welcome to Yatzy! 🎲");
        _writer.WriteLine("Press space to play!");
        while (_reader.ReadKey().Key != ConsoleKey.Spacebar){}
    }

    public bool WantToQuit(int completedRounds)
    {
        var currentRound = completedRounds + 1;
        var remainingRounds = 15 - completedRounds;
        _writer.WriteLine($"Your current round is {currentRound}.");
        _writer.WriteLine($"There are {remainingRounds} left before the game finishes.");
        _writer.WriteLine("Press [q] if you want to quit, or any other key to keep playing.");
        return _reader.ReadKey().Key == ConsoleKey.Q;

    }

    public void ShowDiceRolls(int[] diceRolls)
    {
        var diceRollsString = "";
        
        for (var i = 0; i < diceRolls.Length; i++)
        {
            diceRollsString += $"Dice {i}: {diceRolls[i]}\n";
        }
        _writer.WriteLine("Below are the dice which you have rolled:");
        _writer.WriteLine(diceRollsString);
    }

    public bool WantToReroll()
    {
        _writer.WriteLine("If you would like to reroll enter [r], otherwise to continue press any other key.");
        return _reader.ReadKey().Key == ConsoleKey.R;
    }

    public bool AskIfHold()
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
        _writer.WriteLine("Below are the available categories:");
        for (int i = 0; i < categories.Count; i++)
        {
            _writer.WriteLine($"Category {i + 1}: {categories[i].ToString()}");
        }
    }

    public int GetCategory()
    {
        _writer.WriteLine("Enter the corresponding number for the category you would like to play: ");
        var userInput = _reader.ReadLine();
        return int.Parse(userInput);
    }

    public void ShowScore(int score)
    {
        _writer.WriteLine($"Your current score is {score}, keep it up!");
    }
    public void ShowOutro(int score)
    {
        _writer.WriteLine($"GG! Your final score was {score}, hope you had fun!");
    }
};
