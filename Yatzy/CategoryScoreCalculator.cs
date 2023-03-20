namespace Yatzy;

public class CategoryScoreCalculator
{
    public int GetChanceScore(int[] diceRoll)
    {
        return diceRoll.Sum();
    }
    
    public int GetYatzyScore(int[] diceRoll)
    {
        var yatzyValue = diceRoll.First();
        return diceRoll.All(dieValue=> dieValue == yatzyValue) ? 50 : 0;
    }

    public int GetXScore(int[] diceRoll, int number)
    {
        return diceRoll.Sum(dieValue => dieValue == number ? dieValue : 0);
    }

    public int GetPairScore(int[] diceRoll)
    {
        var duplicateDiceValues = GetDuplicateDiceValues(diceRoll);
        return duplicateDiceValues.Length > 0 ? duplicateDiceValues.Max() * 2 : 0;
    }

    public int GetTwoPairScore(int[] diceRoll)
    {
        var duplicateDiceValues = GetDuplicateDiceValues(diceRoll);
        return duplicateDiceValues.Length > 1 ? duplicateDiceValues[^1] * 2 + duplicateDiceValues[^2] * 2 : 0;
    }

    private int[] GetDuplicateDiceValues(IEnumerable<int> diceRoll)
    {
        IEnumerable<int> checkDuplicates = diceRoll.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(x => x.Key);
        
        return (checkDuplicates.ToArray());
    }

    public int GetXOfAKindScore(int[] diceRoll, int xValue)
    {
        if (xValue != 3 && xValue != 4)
        {
            return 0;
        }
        
        var numberCount = diceRoll.GroupBy(g => g).Where(x => x.Count() >= xValue).Select(g => g.Key).ToList();
        return numberCount.Any() ? numberCount[0] * xValue : 0;
    }
    
    public int GetSmallStraightScore(int[] diceRoll)
    {
        var startFromZero = diceRoll[..4];
        var startFromOne = diceRoll[1..];

        if (startFromZero.SequenceEqual(new[] { 1, 2, 3, 4 }) || startFromZero.SequenceEqual(new[] { 2, 3, 4, 5 }) ||
            startFromZero.SequenceEqual(new[] { 3, 4, 5, 6 }))
        {
            return 30;
        }
        
        if (startFromOne.SequenceEqual(new[] { 1, 2, 3, 4 }) || startFromOne.SequenceEqual(new[] { 2, 3, 4, 5 }) ||
            startFromOne.SequenceEqual(new[] { 3, 4, 5, 6 }))
        {
            return 30;
        }

        return 0;
    }
    
    public int GetLargeStraightScore(int[] diceRoll)
    {
        if (diceRoll.SequenceEqual(new[] {1, 2, 3, 4, 5}) || diceRoll.SequenceEqual(new[] {2, 3, 4, 5 ,6}))
        {
            return 40;
        } else
        {
            return 0;
        }
    }
    
    public int GetFullHouseScore(int[] diceRoll)
    {
        var fullHousePairs = diceRoll.GroupBy(g => g).Where(x => x.Count() == 2).Select(g => g.Key);
        var fullHouseThrees = diceRoll.GroupBy(g => g).Where(x => x.Count() == 3).Select(g => g.Key);

        return fullHousePairs.Any() && fullHouseThrees.Any() ? diceRoll.Sum() : 0;
    }
}