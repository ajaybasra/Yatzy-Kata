namespace Yatzy;

public class CategoryScoreCalculator
{
    public int GetChanceScore(int[] DiceRoll)
    {
        return DiceRoll.Sum();
    }
    
    public int GetYatzyScore(int[] DiceRoll)
    {
        var yatzyValue = DiceRoll.First();
        return DiceRoll.All(dieValue=> dieValue == yatzyValue) ? 50 : 0;
    }

    public int GetXScore(int[] DiceRoll, int number)
    {
        return DiceRoll.Sum(dieValue => dieValue == number ? dieValue : 0);
    }
}