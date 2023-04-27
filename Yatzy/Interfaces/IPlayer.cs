using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoller DiceRollers { get; set; }
    public PlayerCategories PlayerCategories { get; set; }
    
    public void StartPlayerTurn();
    public void AddToPlayScore(int points);
    public void ChooseWhatToDoWithDice(IConsoleHandler consoleHandler, DiceRoller diceRollers);
    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler);

}