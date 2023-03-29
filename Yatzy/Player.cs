using Yahtzy.Enums;
using Yatzy.Interfaces;

namespace Yatzy;

public class Player : IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public readonly DiceRoll DiceRolls;
    public readonly PlayerCategories PlayerCategories;

    public Player(DiceRoll diceRolls, PlayerCategories playerCategories )
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

    public void ChooseToHoldDie(IConsoleHandler consoleHandler, DiceRoll diceRoll)
    {
        throw new NotImplementedException();
    }

    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler)
    {
        throw new NotImplementedException();
    }
}