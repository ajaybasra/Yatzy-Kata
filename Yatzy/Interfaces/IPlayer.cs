using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IPlayer
{
    public string Name { get; set; }
    public PlayerType Type { get; set; }
    public int Score { get; set; }
    public DiceRoll DiceRolls { get; set; }
    public PlayerCategories PlayerCategories { get; set; }
    
    public void StartPlayerTurn();
    public void AddToPlayScore(int points);
    public void ChooseWhatToDoWithDice(IConsoleHandler consoleHandler, DiceRoll diceRolls);
    public void ChooseCategoryToPlay(IConsoleHandler consoleHandler);

}