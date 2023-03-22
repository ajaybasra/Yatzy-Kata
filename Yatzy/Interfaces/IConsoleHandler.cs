using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IConsoleHandler
{
    public void Intro();

    public bool WantToQuit(int completedRounds);

    public void ShowDiceRolls(int[] diceRolls);
    public bool WantToReroll();

    public bool AskIfHold();

    public string GetDiceToHold();

    public void ShowCategories(List<Category> categories);

    public int GetCategory();

    public void ShowScore(int score);
    public void ShowOutro(int score);
}