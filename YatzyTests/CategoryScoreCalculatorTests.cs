using Yatzy;

namespace YatzyTests;

public class CategoryScoreCalculatorTests
{
    private readonly CategoryScoreCalculator _categoryScoreCalculator;

    public CategoryScoreCalculatorTests()
    {
        _categoryScoreCalculator = new CategoryScoreCalculator();
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 3, 4, 5 }, 15 )]
    [InlineData( new int[] { 6, 6, 6, 6, 6 }, 30 )]
    public void GetChanceScore_GivenDiceValues_ReturnCorrectSum(int[] diceRolls, int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetChanceScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 1, 1, 1, 1 }, 50 )]
    [InlineData( new int[] { 3, 1, 3, 3, 3 }, 0 )]
    public void GetYatzyScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls, int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetYatzyScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 1, 3, 1 }, 1, 3 )]
    [InlineData( new int[] { 3, 1, 3, 3, 3 }, 3, 12)]
    public void GetXScore_GivenDiceValuesAndSingleDieValue_ReturnCorrectOutput(int[] diceRolls , int dieValue, int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetXScore(diceRolls, dieValue);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 3, 4, 5 }, 0 )]
    [InlineData( new int[] { 2, 2, 2 ,4, 2 }, 4 )]
    [InlineData( new int[] { 2, 2, 4 ,4, 2 }, 8 )]
    public void GetPairScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetPairScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 3, 4, 5 }, 0 )]
    [InlineData( new int[] { 2, 2, 4 ,4, 6 }, 12 )]
    [InlineData( new int[] { 3, 3, 3, 1, 1 }, 8 )]
    public void GetTwoPairScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetTwoPairScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 3, 3, 3, 4, 5 }, 3, 9 )]
    [InlineData( new int[] { 3, 3, 4, 5, 6 }, 3, 0 )]
    [InlineData( new int[] { 3, 3, 3, 3, 1 }, 3, 9 )]
    [InlineData( new int[] { 2, 2, 2, 2, 5 }, 4, 8 )]
    [InlineData( new int[] { 2, 2, 2, 5, 5 }, 4, 0 )]
    [InlineData( new int[] { 2, 2, 2, 2, 2 }, 4, 8 )]
    public void GetXOfAKindScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int xValue, int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetXOfAKindScore(diceRolls, xValue);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 3, 4, 5 }, 30 )]
    [InlineData( new int[] { 2, 3, 4 ,5, 0 }, 30 )]
    [InlineData( new int[] { 1, 3, 4, 5, 6 }, 30 )]
    [InlineData( new int[] { 1, 2, 3, 5, 4 }, 0 )]
    [InlineData( new int[] { 4, 5, 6, 3, 6 }, 0 )]
    public void GetSmallStraightScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetSmallStraightScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);
    }
    
    [Theory]
    [InlineData( new int[] { 1, 2, 3, 4, 5 }, 40 )]
    [InlineData( new int[] { 2, 3, 4, 5, 6 }, 40 )]
    [InlineData( new int[] { 1, 2, 3, 4, 0 }, 0 )]
    [InlineData( new int[] { 5, 1, 2, 3, 4 }, 0 )]
    public void GetLargeStraightScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetLargeStraightScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);

    }
    
    [Theory]
    [InlineData( new int[] { 1, 1, 2, 2, 2 }, 8 )]
    [InlineData( new int[] { 2, 2, 3, 3, 4 }, 0 )]
    [InlineData( new int[] { 4, 4, 4, 4, 4 }, 0 )]
    [InlineData( new int[] { 1, 1, 2, 1, 2 }, 7 )]
    public void GetFullHouseScore_GivenDiceValues_ReturnCorrectOutput(int[] diceRolls , int expectedScore)
    {
        var actualScore = _categoryScoreCalculator.GetFullHouseScore(diceRolls);
        
        Assert.Equal(expectedScore, actualScore);

    }
    
    
}
 