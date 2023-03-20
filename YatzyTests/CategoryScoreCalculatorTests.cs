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
}