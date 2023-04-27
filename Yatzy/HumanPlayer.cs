using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class HumanPlayer : IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoller DiceRollers { get; set; }
    public PlayerCategories PlayerCategories { get; set; }

    public HumanPlayer(DiceRoller diceRollers, PlayerCategories playerCategories)
    {
        Type = PlayerType.Human;
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
        while (diceRollers.IsRollsLeft())
        {
            consoleHandler.ShowDiceRolls(diceRollers.GetDiceRolls());
            if (!consoleHandler.WantToReRoll(diceRollers.GetNumberOfRollsLeft())) break;
            if (consoleHandler.WantToHold())
            {
                var diceToHold = consoleHandler.GetDiceToHold().Split(",");
                var diceToHoldAsInts = Array.ConvertAll(diceToHold, x => int.Parse(x) - 1);
                diceRollers.HoldDice(diceToHoldAsInts);
            }
            diceRollers.RollDice();
            if (diceRollers.GetNumberOfRollsLeft() == 0) consoleHandler.ShowDiceRolls(diceRollers.GetDiceRolls());
        }
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        consoleHandler.ShowCategories(PlayerCategories.ListOfCategories);
        var chosenCategoryIndex = consoleHandler.GetCategory(PlayerCategories.ListOfCategories);
        var chosenCategory = PlayerCategories.ListOfCategories[chosenCategoryIndex];
        AddToPlayScore(PlayerCategories.GetScoreForPlacingRollInCategory(chosenCategory, DiceRollers.GetDiceRolls()));
        PlayerCategories.RemoveCategory(chosenCategory);
        consoleHandler.ShowScore(Score);
    }
}