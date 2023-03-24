using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IConsoleHandler
{
    public void ShowIntro();

    public bool WantToQuit(int completedRounds);

    public void ShowDiceRolls(int[] diceRolls);
    public bool WantToReRoll();

    public bool WantToHold();

    public string GetDiceToHold();

    public void ShowCategories(List<Category> categories);

    public int GetCategory(List<Category> categories);

    public void ShowScore(int score);
    public void ShowOutro(int score);
}