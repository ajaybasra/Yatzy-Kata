using Yahtzy.Enums;

namespace Yatzy;

public abstract class Validator
{
    public static bool ChosenDiceToHoldAreValid(string diceToHold)
    {
        if (string.IsNullOrEmpty(diceToHold)) return false;
        
        var arrayOfDiceToHold = diceToHold.Split(",");
        
        if (arrayOfDiceToHold.All(x => x.All(char.IsDigit)))
        {
            if (arrayOfDiceToHold.All(x => int.Parse(x) is > 1 and <= 6))
            {
                return true;
            }
        }

        return false;
    }
    public static bool ChosenCategoryIsValid(string chosenCategory, List<Category> categories)
    {
        if (int.TryParse(chosenCategory, out var categoryNumber))
        {
            if (categoryNumber > 0 && categoryNumber <= categories.Count) return true;
        }

        return false;
    }
}
