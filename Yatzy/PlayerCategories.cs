using Yahtzy.Enums;

namespace Yatzy;

public class PlayerCategories
{
    public readonly List<Category> ListOfCategories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
    private readonly CategoryScoreCalculator _categoryScoreCalculator;

    public PlayerCategories(CategoryScoreCalculator categoryScoreCalculator)
    {
        _categoryScoreCalculator = categoryScoreCalculator;
    }

    public int GetScoreForPlacingRollInCategory(Category category, int[] diceRolls)
    {
        var categoriesToScoreCalculatorDictionary = new Dictionary<Category, int>()
        {
            {Category.Chance, _categoryScoreCalculator.GetChanceScore(diceRolls)},
            {Category.Yatzy, _categoryScoreCalculator.GetYatzyScore(diceRolls)},
            {Category.Ones, _categoryScoreCalculator.GetXScore(diceRolls, 1)},
            {Category.Twos, _categoryScoreCalculator.GetXScore(diceRolls, 2)},
            {Category.Threes, _categoryScoreCalculator.GetXScore(diceRolls, 3)},
            {Category.Fours, _categoryScoreCalculator.GetXScore(diceRolls, 4)},
            {Category.Fives, _categoryScoreCalculator.GetXScore(diceRolls, 5)},
            {Category.Sixes, _categoryScoreCalculator.GetXScore(diceRolls, 6)},
            {Category.Pair, _categoryScoreCalculator.GetPairScore(diceRolls)},
            {Category.TwoPairs, _categoryScoreCalculator.GetTwoPairScore(diceRolls)},
            {Category.ThreeOfAKind, _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3)},
            {Category.FourOfAKind, _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4)},
            {Category.SmallStraight, _categoryScoreCalculator.GetSmallStraightScore(diceRolls)},
            {Category.LargeStraight, _categoryScoreCalculator.GetLargeStraightScore(diceRolls)},
            {Category.FullHouse, _categoryScoreCalculator.GetFullHouseScore(diceRolls)}
        };

        return categoriesToScoreCalculatorDictionary[category];
    }

    public bool IsCategoriesEmpty()
    {
        return ListOfCategories.Count == 0;
    }

    public int GetCategoriesListSize()
    {
        return ListOfCategories.Count;
    }

    public void RemoveCategory(Category categoryToRemove)
    {
        ListOfCategories.Remove(categoryToRemove);
    } 

    public Category GetCategoryWhichReturnsHighestScore(int[] diceRolls)
    {
        var listOfScores = ListOfCategories.Select(category => GetScoreForPlacingRollInCategory(category, diceRolls)).ToList();

        var maxCategoryIndex = listOfScores.IndexOf(listOfScores.Max());
        
        return ListOfCategories[maxCategoryIndex];
    }
}