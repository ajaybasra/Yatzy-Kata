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

    [Fact]
    public void PlaceRollsInCategory_ShouldRemoveCategoryFromList_WhenCalled()
    {
        _playerCategories.PlaceRollsInCategory(Category.Chance, new int[] { 1, 2, 3, 4, 5 });
        
        Assert.Equal(14, _playerCategories.ListOfCategories.Count());
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
    public void PlaceRollsInCategory_ShouldReturnCorrectScoreForCategoryWhichHasRollPlacedInIt_WhenCalled(Category category, int[] diceRolls, int expected)
    {
       var scoreForCategory = _playerCategories.PlaceRollsInCategory(category, diceRolls);
       
       Assert.Equal(expected, scoreForCategory);
    }

    [Fact]
    public void IsCategoriesEmpty_ShouldReturnTrueWhenAllCategoriesPlayedAndReturnFalseOtherwise_WhenCalled()
    {
        Assert.False(_playerCategories.IsCategoriesEmpty());
        
        _playerCategories.ListOfCategories.Clear();
        Assert.True(_playerCategories.IsCategoriesEmpty());
    }
}