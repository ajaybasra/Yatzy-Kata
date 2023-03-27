namespace Yatzy;

public class Player
{
    public int Score { get; set; }
    public readonly DiceRoll DiceRolls;
    public readonly PlayerCategories _playerCategories;

    public Player(DiceRoll diceRolls, PlayerCategories playerCategories )
    {
        DiceRolls = diceRolls;
        _playerCategories = playerCategories;
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