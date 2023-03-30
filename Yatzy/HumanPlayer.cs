using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class HumanPlayer : IPlayer
{
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public readonly DiceRoll DiceRolls;
    public readonly PlayerCategories PlayerCategories;

    public HumanPlayer(DiceRoll diceRolls, PlayerCategories playerCategories)
    {
        Type = PlayerType.Human;
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
        while (diceRolls.IsRollsLeft())
        {
            consoleHandler.ShowDiceRolls(diceRolls.GetDiceRolls());
            if (!consoleHandler.WantToReRoll(diceRolls.GetNumberOfRollsLeft())) break;
            if (consoleHandler.WantToHold())
            {
                var diceToHold = consoleHandler.GetDiceToHold().Split(",");
                var diceToHoldAsInts = Array.ConvertAll(diceToHold, x => int.Parse(x) - 1);
                diceRolls.HoldDice(diceToHoldAsInts);
            }
            diceRolls.RollDice();
            if (diceRolls.GetNumberOfRollsLeft() == 0) consoleHandler.ShowDiceRolls(diceRolls.GetDiceRolls());
        }
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        consoleHandler.ShowCategories(PlayerCategories.ListOfCategories);
        var chosenCategoryIndex = consoleHandler.GetCategory(PlayerCategories.ListOfCategories);
        var chosenCategory = PlayerCategories.ListOfCategories[chosenCategoryIndex];
        AddToPlayScore(PlayerCategories.PlaceRollsInCategory(chosenCategory, DiceRolls.GetDiceRolls()));
        PlayerCategories.RemoveCategory(chosenCategory);
        consoleHandler.ShowScore(Score);
    }
}