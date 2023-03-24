using Yatzy;

namespace YatzyTests;

public class PlayerTests
{
    private readonly DiceRoll _diceRoll;
    private readonly Player _player;

    public PlayerTests()
    {
        _diceRoll = new DiceRoll(new RNG());
        _player = new Player(_diceRoll);
    }

    [Fact]
    public void GivenAPlayer_AtStartOfGame_ScoreShouldBeZero()
    {
        Assert.Equal(0, _player.Score);
    }

    [Fact]
    public void StartTurn_ShouldResetIsHeldToFalseAndRolls_WhenNewTurn()
    {
        _player.StartTurn();
        _player.DiceRolls.DecrementRollsLeft();
        _player.DiceRolls.HoldDice(new int[] {0,1});
        _player.StartTurn();
        
        Assert.Equal(2, _player.DiceRolls.NumberOfRollsLeft);
        Assert.False(_player.DiceRolls.Dice[0].IsHeld);
        Assert.False(_player.DiceRolls.Dice[1].IsHeld);
    }
    
    [Fact]
    public void IsRollsLeft_ShouldReturnTrueIfRollsLeftElseShouldReturnFalse_WhenCalled()
    {
        _player.DiceRolls.DecrementRollsLeft();
        _player.DiceRolls.DecrementRollsLeft();
        _player.DiceRolls.DecrementRollsLeft();
        Assert.False(_player.DiceRolls.IsRollsLeft());
        
        _player.StartTurn();
        Assert.True(_player.DiceRolls.IsRollsLeft());
    }

    [Fact]
    public void AddToPlayerScore_ShouldIncreasePlayerScore_WhenCalled()
    {
        _player.AddToPlayScore(50);
        _player.AddToPlayScore(36);
        
        Assert.Equal(86, _player.Score);
    }
}