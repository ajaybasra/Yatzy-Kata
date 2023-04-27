using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class BotPlayer : IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoller DiceRollers { get; set; }
    public PlayerCategories PlayerCategories { get; set; }

    public BotPlayer(DiceRoller diceRollers, PlayerCategories playerCategories)
    {
        Type = PlayerType.Bot;
        DiceRollers = diceRollers;
        PlayerCategories = playerCategories;
    }
    public void StartPlayerTurn()
    {
        DiceRollers.SetNumberOfRolls(Constants.StartingNumberOfRolls);
        
        foreach (var die in DiceRollers.Dice)
        {
            die.IsHeld = false;
        }
        
        DiceRollers.RollDice();
    }

    public void AddToPlayScore(int points)
    {
        Score += points;
    }

    public void ChooseWhatToDoWithDice(IConsoleHandler consoleHandler, DiceRoller diceRollers)
    {
        consoleHandler.BotRolledDice();
        consoleHandler.ShowDiceRolls(diceRollers.GetDiceRolls());
        consoleHandler.BotDoesNotReRoll();
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        var chosenCategory = PlayerCategories.GetCategoryWhichReturnsHighestScore(DiceRollers.GetDiceRolls());
        consoleHandler.BotChoosesCategory(chosenCategory.ToString());
        AddToPlayScore(PlayerCategories.GetScoreForPlacingRollInCategory(chosenCategory, DiceRollers.GetDiceRolls()));
        PlayerCategories.RemoveCategory(chosenCategory);
        consoleHandler.BotScore(Score);
    }
}