using Yatzy.Interfaces;

namespace Yatzy;

public class DiceRoll : IDiceRoller
{
    public List<Die> Dice { get; }
    public int NumberOfRollsLeft { get; private set; }

    public DiceRoll()
    {
        DecrementRollsLeft();
        Dice = new List<Die>()
        {
            new (new RNG()),
            new (new RNG()),
            new (new RNG()),
            new (new RNG()),
            new (new RNG())
        };
    }
    
    public void RollDice()
    {
        DecrementRollsLeft();
        foreach (var die in Dice)
        {
            if (!die.IsHeld)
            {
                die.DieValue = die.RollDie();
            }
            else
            {
                die.IsHeld = false;
            }
        }
    }

    public int[] GetDiceRolls()
    {
        var arrayOfDice = new List<int>();
        foreach (var die in Dice) // convert to linq expression
        {
            arrayOfDice.Add(die.DieValue);
        }

        return arrayOfDice.ToArray();
    }
    
    public string GetDiceRollsAsString()
    {
        var diceRolls = GetDiceRolls();
        
        var diceRollsString = "";
        
        for (var i = 0; i < diceRolls.Length; i++)
        {
            diceRollsString += $"Dice {i}: {diceRolls[i]}\n";
        }
        return diceRollsString;
    }
    
    public void HoldDice(int[] diceIndices)
    {
        foreach (var diceIndex in diceIndices)
        {
            Dice[diceIndex].IsHeld = true;
        }
    }
    
    public void DecrementRollsLeft()
    {
        NumberOfRollsLeft--;
    }

    public bool IsRollsLeft()
    {
        return NumberOfRollsLeft > 0;
    }

    public void setNumberOfRolls(int roles)
    {
        NumberOfRollsLeft = roles;
    }
}