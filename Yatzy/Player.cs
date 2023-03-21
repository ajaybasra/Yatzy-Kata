namespace Yatzy;

public class Player
{
    public int Score { get; set; }
    public int NumberOfRollsLeft { get; private set; }
    public readonly DiceRoll DiceRolls;

    public Player(DiceRoll diceRolls )
    {
        DiceRolls = diceRolls;
    }

    public void StartTurn()
    {
        NumberOfRollsLeft = 3;
        
        foreach (var die in DiceRolls.Dice)
        {
            die.IsHeld = false;
        }
        
        DiceRolls.RollDice();
    }
    public void DecrementRollsLeft()
    {
        NumberOfRollsLeft--;
    }

    public bool IsRollsLeft()
    {
        return NumberOfRollsLeft > 0;
    }

    public void AddToPlayScore(int points)
    {
        Score += points;
    }
}