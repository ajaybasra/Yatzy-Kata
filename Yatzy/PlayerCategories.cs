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
                player.AddToPlayScore(_categoryScoreCalculator.GetChanceScore(diceRolls));
                return _categoryScoreCalculator.GetChanceScore(diceRolls);
            case Category.Yatzy:
                player.AddToPlayScore(_categoryScoreCalculator.GetYatzyScore(diceRolls));
                return _categoryScoreCalculator.GetYatzyScore(diceRolls);
            case Category.Ones:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 1));
                return _categoryScoreCalculator.GetXScore(diceRolls, 1);
            case Category.Twos:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 2));
                return _categoryScoreCalculator.GetXScore(diceRolls, 2);
            case Category.Threes:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 3));
                return _categoryScoreCalculator.GetXScore(diceRolls, 3);
            case Category.Fours:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 4));
                return _categoryScoreCalculator.GetXScore(diceRolls, 4);
            case Category.Fives:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 5));
                return _categoryScoreCalculator.GetXScore(diceRolls, 5);
            case Category.Sixes:
                player.AddToPlayScore(_categoryScoreCalculator.GetXScore(diceRolls, 6));
                return _categoryScoreCalculator.GetXScore(diceRolls, 6);
            case Category.Pair:
                player.AddToPlayScore(_categoryScoreCalculator.GetPairScore(diceRolls));
                return _categoryScoreCalculator.GetPairScore(diceRolls);
            case Category.TwoPairs:
                player.AddToPlayScore(_categoryScoreCalculator.GetTwoPairScore(diceRolls));
                return _categoryScoreCalculator.GetTwoPairScore(diceRolls);
            case Category.ThreeOfAKind:
                player.AddToPlayScore(_categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3));
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 3);
            case Category.FourOfAKind:
                player.AddToPlayScore(_categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4));
                return _categoryScoreCalculator.GetXOfAKindScore(diceRolls, 4);
            case Category.SmallStraight:
                player.AddToPlayScore(_categoryScoreCalculator.GetSmallStraightScore(diceRolls));
                return _categoryScoreCalculator.GetSmallStraightScore(diceRolls);
            case Category.LargeStraight:
                player.AddToPlayScore(_categoryScoreCalculator.GetLargeStraightScore(diceRolls));
                return _categoryScoreCalculator.GetLargeStraightScore(diceRolls);
            case Category.FullHouse:
                player.AddToPlayScore(_categoryScoreCalculator.GetFullHouseScore(diceRolls));
                return _categoryScoreCalculator.GetFullHouseScore(diceRolls);
            default:
                return 0;
        }
    }

    public bool IsCategoriesEmpty()
    {
        return ListOfCategories.Count == 0;
    }

    public int getCategoriesListSize()
    {
        return ListOfCategories.Count;
    }

    // public List<int> GetAllPossibleCategoryScoresForCurrentRoll(int[] diceRolls)
    // {
    //     var jj = new List<int>();
    //     jj.Add();
    // }
}