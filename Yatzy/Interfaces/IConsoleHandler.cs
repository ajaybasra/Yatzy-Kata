using Yahtzy.Enums;

namespace Yatzy.Interfaces;

public interface IConsoleHandler
{
    public void ShowIntro();

    public bool WantToQuit(int completedRounds);

    public void ShowDiceRolls(int[] diceRolls);
    public bool WantToReRoll(int rollsLeft);

    public bool WantToHold();

    public string GetDiceToHold();

    public void ShowCategories(List<Category> categories);

    public int GetCategory(List<Category> categories);

    public void ShowScore(int score);
    public void ShowOutro();
    public void BotRolledDice();
    public void BotDoesNotReRoll();
    public void BotChoosesCategory(string chosenCategory);
    public void BotScore(int score);
    public void FinalScores(List<IPlayer> playerList);

    public (int, int) GetNumberOfHumansAndBots();

}