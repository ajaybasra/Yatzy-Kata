using Yahtzy.Enums;

namespace Yatzy;

public static class Validator 
{
    public static bool ChosenDiceToHoldAreValid(string diceToHold)
    {
        if (string.IsNullOrEmpty(diceToHold)) return false;
        
        var arrayOfDiceToHold = diceToHold.Split(",");
        
        return arrayOfDiceToHold.All(x => x.All(char.IsDigit)) && arrayOfDiceToHold.All(x => int.Parse(x) is > 0 and <= 5); //could have methods to deal with conditions, makes more readable
    }
    public static bool ChosenCategoryIsValid(string chosenCategory, List<Category> categories)
    {
        return int.TryParse(chosenCategory, out var categoryNumber) && categoryNumber > 0 && categoryNumber <= categories.Count;
    }

    public static bool NumberOfHumansChosenIsValid(string chosenNumberOfHumans)
    {
        return int.TryParse(chosenNumberOfHumans, out var chosenNumberOfHumansAsInt) && chosenNumberOfHumansAsInt is > 0 and < 5;
    }
    
    public static bool NumberOfBotsChosenIsValid(string chosenNumberOfBots)
    {
        return int.TryParse(chosenNumberOfBots, out var chosenNumberOfBotsAsInt) && chosenNumberOfBotsAsInt is >= 0 and <= 2;
    }
}
