using Yatzy;

namespace YatzyTests;

public class PlayerTests
{
    private readonly DiceRoll _diceRoll;
    private readonly Player _player;

    public PlayerTests()
    {
        _diceRoll = new DiceRoll();
        _player = new Player(_diceRoll);
    }

    [Fact]
    public void GivenAPlayer_AtStartOfGame_ScoreShouldBeZero()
    {
        Assert.Equal(0, _player.Score);
    }

    [Fact]
    public void DecrementRollsLeft_ShouldSubtractFromPlayerRolls_WhenCalled()
    {
        _player.StartTurn();
        _player.DecrementRollsLeft();
        
        Assert.Equal(2, _player.NumberOfRollsLeft);
    }

    [Fact]
    public void StartTurn_ShouldResetIsHeldToFalseAndRollsToThree_WhenNewTurn()
    {
        _player.StartTurn();
        _player.DecrementRollsLeft();
        _player.DiceRolls.HoldDice(new int[] {0,1});
        _player.StartTurn();
        
        Assert.Equal(3, _player.NumberOfRollsLeft);
        Assert.False(_player.DiceRolls.Dice[0].IsHeld);
        Assert.False(_player.DiceRolls.Dice[1].IsHeld);
    }
    
    [Fact]
    public void IsRollsLeft_ShouldReturnTrueIfRollsLeftElseShouldReturnFalse_WhenCalled()
    {
        _player.DecrementRollsLeft();
        _player.DecrementRollsLeft();
        _player.DecrementRollsLeft();
        Assert.False(_player.IsRollsLeft());
        
        _player.StartTurn();
        Assert.True(_player.IsRollsLeft());
    }

    [Fact]
    public void AddToPlayerScore_ShouldIncreasePlayerScore_WhenCalled()
    {
        _player.AddToPlayScore(50);
        _player.AddToPlayScore(36);
        
        Assert.Equal(86, _player.Score);
    }
}