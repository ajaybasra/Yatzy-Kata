using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class Bot : IPlayer
{
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public readonly DiceRoll DiceRolls;
    public readonly PlayerCategories PlayerCategories;

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
        throw new NotImplementedException();
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        throw new NotImplementedException();
    }
}