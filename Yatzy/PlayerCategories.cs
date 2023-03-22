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
    
    public int? PlaceRollsInCategory(Category category, int[] diceRolls) 
    {
        switch (category)
        {
            case Category.Chance:
                ListOfCategories.Remove(Category.Chance);
                return _categoryScoreCalculator.GetChanceScore(diceRolls);
            case Category.Yatzy:
                ListOfCategories.Remove(Category.Yatzy);
                return _categoryScoreCalculator.GetYatzyScore(diceRolls);
            case Category.Ones:
                ListOfCategories.Remove(Category.Ones);
                return _categoryScoreCalculator.GetXScore(diceRolls, 1);
            case Category.Twos:
                ListOfCategories.Remove(Category.Twos);
                return _categoryScoreCalculator.GetXScore(diceRolls, 2);
            case Category.Threes:
                ListOfCategories.Remove(Category.Threes);
                return _categoryScoreCalculator.GetXScore(diceRolls, 3);
            case Category.Fours:
                ListOfCategories.Remove(Category.Fours);
                return _categoryScoreCalculator.GetXScore(diceRolls, 4);
            case Category.Fives:
                ListOfCategories.Remove(Category.Fives);
                return _categoryScoreCalculator.GetXScore(diceRolls, 5);
            case Category.Sixes:
                ListOfCategories.Remove(Category.Sixes);
                return _categoryScoreCalculator.GetXScore(diceRolls, 6);
            case Category.Pair:
                ListOfCategories.Remove(Category.Pair);
                return _categoryScoreCalculator.GetPairScore(diceRolls);
            case Category.TwoPairs:
                ListOfCategories.Remove(Category.TwoPairs);
                return _categoryScoreCalculator.GetTwoPairScore(diceRolls);
            case Category.ThreeOfAKind:
                ListOfCategories.Remove(Category.ThreeOfAKind);
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3);
            case Category.FourOfAKind:
                ListOfCategories.Remove(Category.FourOfAKind);
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4);
            case Category.SmallStraight:
                ListOfCategories.Remove(Category.SmallStraight);
                return _categoryScoreCalculator.GetSmallStraightScore(diceRolls);
            case Category.LargeStraight:
                ListOfCategories.Remove(Category.LargeStraight);
                return _categoryScoreCalculator.GetLargeStraightScore(diceRolls);
            case Category.FullHouse:
                ListOfCategories.Remove(Category.FullHouse);
                return _categoryScoreCalculator.GetFullHouseScore(diceRolls);
            default:
                return null;
        }
    }

    public bool IsCategoriesEmpty()
    {
        return ListOfCategories.Count == 0;
    }
}