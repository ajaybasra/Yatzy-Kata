using Yatzy.Interfaces;

namespace Yatzy;

public class DiceRoll : IDiceRoller
{
    public List<Die> Dice { get; }

    public DiceRoll()
    {
    }
    
    public void RollDice()
    {
        throw new NotImplementedException();
    }

    public int[] GetDiceRolls()
    {
        throw new NotImplementedException();
    }
}