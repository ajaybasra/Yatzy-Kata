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
    
    public int PlaceRollsInCategory(Category category, int[] diceRolls, Player player) 
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

    // public List<int> GetAllPossibleCategoryScoresForCurrentRoll(int[] diceRolls)
    // {
    //     var jj = new List<int>();
    //     jj.Add();
    // }
}