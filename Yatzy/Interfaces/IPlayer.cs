using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IPlayer
{
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    
    public void StartPlayerTurn();
    public void AddToPlayScore(int points);
    public void ChooseToHoldDie(IConsoleHandler consoleHandler, DiceRoll diceRoll);
    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler);

}