using Yatzy.Interfaces;

namespace Yatzy;

public class DiceRoller : IDiceRoller
{
    public List<Die> Dice { get; }
    public int NumberOfRollsLeft { get; private set; }

    public DiceRoller(IRandomNumberGenerator rng)
    {
        DecrementRollsLeft();
        Dice = new List<Die>()
        {
            new (rng),
            new (rng),
            new (rng),
            new (rng),
            new (rng)
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
        return Dice.Select(die => die.DieValue).ToArray();
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

    public void SetNumberOfRolls(int rolls)
    {
        NumberOfRollsLeft = rolls;
    }

    public int GetNumberOfRollsLeft()
    {
        return NumberOfRollsLeft;
    }
}