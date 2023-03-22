using Yahtzy.Enums;

namespace Yatzy;

public class PlayerCategories
{
    public readonly List<Category> listOfCategories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
    private readonly CategoryScoreCalculator _categoryScoreCalculator;

    public PlayerCategories(CategoryScoreCalculator categoryScoreCalculator)
    {
        _categoryScoreCalculator = categoryScoreCalculator;
    }
    
    public int? PlaceRollsInCategory(Category category, int[] diceRolls)
    {
        switch (category)
        {
            case Category.Chance:
                listOfCategories.Remove(Category.Chance);
                return _categoryScoreCalculator.GetChanceScore(diceRolls);
            case Category.Yatzy:
                listOfCategories.Remove(Category.Yatzy);
                return _categoryScoreCalculator.GetYatzyScore(diceRolls);
            case Category.Ones:
                listOfCategories.Remove(Category.Ones);
                return _categoryScoreCalculator.GetXScore(diceRolls, 1);
            case Category.Twos:
                listOfCategories.Remove(Category.Twos);
                return _categoryScoreCalculator.GetXScore(diceRolls, 2);
            case Category.Threes:
                listOfCategories.Remove(Category.Threes);
                return _categoryScoreCalculator.GetXScore(diceRolls, 3);
            case Category.Fours:
                listOfCategories.Remove(Category.Fours);
                return _categoryScoreCalculator.GetXScore(diceRolls, 4);
            case Category.Fives:
                listOfCategories.Remove(Category.Fives);
                return _categoryScoreCalculator.GetXScore(diceRolls, 5);
            case Category.Sixes:
                listOfCategories.Remove(Category.Sixes);
                return _categoryScoreCalculator.GetXScore(diceRolls, 6);
            case Category.Pair:
                listOfCategories.Remove(Category.Pair);
                return _categoryScoreCalculator.GetPairScore(diceRolls);
            case Category.TwoPairs:
                listOfCategories.Remove(Category.TwoPairs);
                return _categoryScoreCalculator.GetTwoPairScore(diceRolls);
            case Category.ThreeOfAKind:
                listOfCategories.Remove(Category.ThreeOfAKind);
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3);
            case Category.FourOfAKind:
                listOfCategories.Remove(Category.FourOfAKind);
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4);
            case Category.SmallStraight:
                listOfCategories.Remove(Category.SmallStraight);
                return _categoryScoreCalculator.GetSmallStraightScore(diceRolls);
            case Category.LargeStraight:
                listOfCategories.Remove(Category.LargeStraight);
                return _categoryScoreCalculator.GetLargeStraightScore(diceRolls);
            case Category.FullHouse:
                listOfCategories.Remove(Category.FullHouse);
                return _categoryScoreCalculator.GetFullHouseScore(diceRolls);
            default:
                return null;
        }
    }

    public bool IsCategoriesEmpty()
    {
        return listOfCategories.Count == 0;
    }
}