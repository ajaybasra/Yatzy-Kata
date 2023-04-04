using Yahtzy.Enums;
using Yatzy;

namespace YatzyTests;

public class PlayerCategoriesTests
{
    private readonly CategoryScoreCalculator _categoryScoreCalculator;
    private readonly PlayerCategories _playerCategories;

    public PlayerCategoriesTests()
    {
        _categoryScoreCalculator = new CategoryScoreCalculator();
        _playerCategories = new PlayerCategories(_categoryScoreCalculator);

    }
    
    public static IEnumerable<object[]> GetCategoryAndDiceRolls()
    {
        yield return new object[] { Category.Chance, new[] { 2, 2, 2, 2, 2 }, 10 };
        yield return new object[] { Category.Yatzy, new[] { 6, 6, 6, 6, 6 }, 50 };
        yield return new object[] { Category.Pair, new[] { 2, 2, 4 ,4, 2 }, 8 };
        yield return new object[] { Category.TwoPairs, new[] { 2, 2, 4 ,4, 6  }, 12 };
        yield return new object[] { Category.SmallStraight, new[] { 1, 3, 4, 5, 6 }, 30 };
        yield return new object[] { Category.LargeStraight, new[] { 1, 2, 3, 4, 5 }, 40 };
        yield return new object[] { Category.FullHouse, new[] { 1, 1, 2, 2, 2 }, 8 };
    }
    
    [Theory]
    [MemberData(nameof(GetCategoryAndDiceRolls))]
    public void GetScoreForPlacingRollInCategory_ShouldReturnCorrectScoreForCategoryWhichHasRollPlacedInIt_WhenCalled(Category category, int[] diceRolls, int expected)
    {
       var scoreForCategory = _playerCategories.GetScoreForPlacingRollInCategory(category, diceRolls);
       
       Assert.Equal(expected, scoreForCategory);
    }

    [Fact]
    public void IsCategoriesEmpty_ShouldReturnTrueWhenAllCategoriesPlayedAndReturnFalseOtherwise_WhenCalled()
    {
        Assert.False(_playerCategories.IsCategoriesEmpty());
        
        _playerCategories.ListOfCategories.Clear();
        Assert.True(_playerCategories.IsCategoriesEmpty());
    }
    
    public static IEnumerable<object[]> GetCategoryToRemove()
    {
        yield return new object[] { Category.Chance };
        yield return new object[] { Category.Yatzy };
        yield return new object[] { Category.Pair };
        yield return new object[] { Category.TwoPairs };
        yield return new object[] { Category.SmallStraight };
        yield return new object[] { Category.LargeStraight };
        yield return new object[] { Category.FullHouse };
    }
    [Theory] 
    [MemberData(nameof(GetCategoryToRemove))]
    public void RemoveCategory_ShouldRemoveGivenCategory_WhenCalled(Category category)
    {
        _playerCategories.RemoveCategory(category);
        
        Assert.Equal(14, _playerCategories.GetCategoriesListSize());
        Assert.False(_playerCategories.ListOfCategories.Contains(category));
    }

    public static IEnumerable<object[]> GetDiceRollsAndExpectedCategory()
    {
        yield return new object[] { new[] { 6, 6, 6, 6, 6 }, Category.Yatzy };
        yield return new object[] { new[] { 6, 6, 6, 6, 5 }, Category.Chance };
        yield return new object[] { new[] { 1, 2, 3, 4, 6 }, Category.SmallStraight };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, Category.LargeStraight };

    }
    [Theory]
    [MemberData(nameof(GetDiceRollsAndExpectedCategory))]
    public void GetCategoryWhichReturnsHighestScore_ReturnsCategoryWhichGivesHighestScoreForGivenRoll_WhenCalled(int[] diceRoll, Category expectedCategory)
    {
        Assert.Equal(expectedCategory, _playerCategories.GetCategoryWhichReturnsHighestScore(diceRoll));
    }

    [Fact]
    public void GetCategoriesListSize_ReturnsCorrectValues_WhenCalled()
    {
        Assert.Equal(15, _playerCategories.GetCategoriesListSize());
        
        _playerCategories.RemoveCategory(Category.Chance);
        Assert.Equal(14, _playerCategories.GetCategoriesListSize());
        
        _playerCategories.ListOfCategories.Clear();
        Assert.Equal(0, _playerCategories.GetCategoriesListSize());
    }
}