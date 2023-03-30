using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class Bot : IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoll DiceRolls { get; set; }
    public PlayerCategories PlayerCategories { get; set; }

    public Bot(DiceRoll diceRolls, PlayerCategories playerCategories)
    {
        Type = PlayerType.Bot;
        DiceRolls = diceRolls;
        PlayerCategories = playerCategories;
    }
    public void StartPlayerTurn()
    {
        DiceRolls.SetNumberOfRolls(3);
        
        foreach (var die in DiceRolls.Dice)
        {
            die.IsHeld = false;
        }
        
        DiceRolls.RollDice();
    }

    public void AddToPlayScore(int points)
    {
        Score += points;
    }

    public void ChooseWhatToDoWithDice(IConsoleHandler consoleHandler, DiceRoll diceRolls)
    {
        consoleHandler.BotRolledDice();
        consoleHandler.ShowDiceRolls(diceRolls.GetDiceRolls());
        consoleHandler.BotDoesNotReRoll();
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        var chosenCategory = PlayerCategories.GetCategoryWhichReturnsHighestScore(DiceRolls.GetDiceRolls());
        consoleHandler.BotChoosesCategory(chosenCategory.ToString());
        AddToPlayScore(PlayerCategories.PlaceRollsInCategory(chosenCategory, DiceRolls.GetDiceRolls()));
        PlayerCategories.RemoveCategory(chosenCategory);
        consoleHandler.BotScore(Score);
    }
}