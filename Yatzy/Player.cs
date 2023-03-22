namespace Yatzy;

public class Player
{
    public int Score { get; set; }
    public readonly DiceRoll DiceRolls;

    public Player(DiceRoll diceRolls )
    {
        DiceRolls = diceRolls;
    }

    public void StartTurn()
    {
        DiceRolls.setNumberOfRolls(3);
        
        foreach (var die in DiceRolls.Dice)
        {
            die.IsHeld = false;
        }
        
        DiceRolls.RollDice();
    }

    public void AddToPlayScore(int points)
    {
        Score += points;
    }
}