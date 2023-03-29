using Yatzy;

namespace YatzyTests;

public class PlayerTests
{
    private readonly DiceRoll _diceRoll;
    private readonly Player _player;
    private readonly CategoryScoreCalculator _categoryScoreCalculator;
    private readonly PlayerCategories _playerCategories;

    public PlayerTests()
    {
        _diceRoll = new DiceRoll(new RNG());
        _categoryScoreCalculator = new CategoryScoreCalculator();
        _playerCategories = new PlayerCategories(_categoryScoreCalculator);
        _player = new Player(_diceRoll, _playerCategories);
    }

    [Fact]
    public void GivenAPlayer_AtStartOfGame_ScoreShouldBeZero()
    {
        Assert.Equal(0, _player.Score);
    }

    [Fact]
    public void StartTurn_ShouldResetIsHeldToFalseAndRolls_WhenNewTurn()
    {
        _player.StartPlayerTurn();
        _player.DiceRolls.DecrementRollsLeft();
        _player.DiceRolls.HoldDice(new int[] {0,1});
        _player.StartPlayerTurn();
        
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
        
        _player.StartPlayerTurn();
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