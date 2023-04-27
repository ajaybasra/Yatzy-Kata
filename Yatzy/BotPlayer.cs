using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class BotPlayer : IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoll DiceRolls { get; set; }
    public PlayerCategories PlayerCategories { get; set; }

    public BotPlayer(DiceRoll diceRolls, PlayerCategories playerCategories)
    {
        Type = PlayerType.Bot;
        DiceRolls = diceRolls;
        PlayerCategories = playerCategories;
    }
    public void StartPlayerTurn()
    {
        DiceRolls.SetNumberOfRolls(Constants.StartingNumberOfRolls);
        
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
        AddToPlayScore(PlayerCategories.GetScoreForPlacingRollInCategory(chosenCategory, DiceRolls.GetDiceRolls()));
        PlayerCategories.RemoveCategory(chosenCategory);
        consoleHandler.BotScore(Score);
    }
}