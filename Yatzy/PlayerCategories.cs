using Yahtzy.Enums;

namespace Yatzy;

public class PlayerCategories
{
    public readonly List<Category> ListOfCategories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
    public readonly CategoryScoreCalculator _categoryScoreCalculator;

    public PlayerCategories(CategoryScoreCalculator categoryScoreCalculator)
    {
        _categoryScoreCalculator = categoryScoreCalculator;
    }

    public int GetScoreForPlacingRollInCategory(Category category, int[] diceRolls)
    {
        var CategoriesToScoreCalculatorDictionary = new Dictionary<Category, int>()
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

        return CategoriesToScoreCalculatorDictionary[category];
    }

    public int PlaceRollsInCategory(Category category, int[] diceRolls) 
    {
        switch (category)
        {
            case Category.Chance:
                return _categoryScoreCalculator.GetChanceScore(diceRolls);
            case Category.Yatzy:
                return _categoryScoreCalculator.GetYatzyScore(diceRolls);
            case Category.Ones:
                return _categoryScoreCalculator.GetXScore(diceRolls, 1);
            case Category.Twos:
                return _categoryScoreCalculator.GetXScore(diceRolls, 2);
            case Category.Threes:
                return _categoryScoreCalculator.GetXScore(diceRolls, 3);
            case Category.Fours:
                return _categoryScoreCalculator.GetXScore(diceRolls, 4);
            case Category.Fives:
                return _categoryScoreCalculator.GetXScore(diceRolls, 5);
            case Category.Sixes:
                return _categoryScoreCalculator.GetXScore(diceRolls, 6);
            case Category.Pair:
                return _categoryScoreCalculator.GetPairScore(diceRolls);
            case Category.TwoPairs:
                return _categoryScoreCalculator.GetTwoPairScore(diceRolls);
            case Category.ThreeOfAKind:
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3);
            case Category.FourOfAKind:
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4);
            case Category.SmallStraight:
                return _categoryScoreCalculator.GetSmallStraightScore(diceRolls);
            case Category.LargeStraight:
                return _categoryScoreCalculator.GetLargeStraightScore(diceRolls);
            case Category.FullHouse:
                return _categoryScoreCalculator.GetFullHouseScore(diceRolls);
            default:
                return 0;
        }
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
        var listOfScores = ListOfCategories.Select(category => PlaceRollsInCategory(category, diceRolls)).ToList();

        var maxCategoryIndex = listOfScores.IndexOf(listOfScores.Max());
        
        return ListOfCategories[maxCategoryIndex];
    }
}