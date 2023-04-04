using Yatzy;

namespace YatzyTests;

public class PlayerTests
{
    private readonly DiceRoll _diceRoll;
    private readonly HumanPlayer _humanPlayer;
    private readonly CategoryScoreCalculator _categoryScoreCalculator;
    private readonly PlayerCategories _playerCategories;

    public PlayerTests()
    {
        _diceRoll = new DiceRoll(new RNG());
        _categoryScoreCalculator = new CategoryScoreCalculator();
        _playerCategories = new PlayerCategories(_categoryScoreCalculator);
        _humanPlayer = new HumanPlayer(_diceRoll, _playerCategories);
    }

    [Fact]
    public void GivenAPlayer_AtStartOfGame_ScoreShouldBeZero()
    {
        Assert.Equal(0, _humanPlayer.Score);
    }

    [Fact]
    public void StartTurn_ShouldResetIsHeldToFalseAndRolls_WhenNewTurn()
    {
        _humanPlayer.StartPlayerTurn();
        _humanPlayer.DiceRolls.DecrementRollsLeft();
        _humanPlayer.DiceRolls.HoldDice(new int[] {0,1});
        _humanPlayer.StartPlayerTurn();
        
        Assert.Equal(2, _humanPlayer.DiceRolls.NumberOfRollsLeft);
        Assert.False(_humanPlayer.DiceRolls.Dice[0].IsHeld);
        Assert.False(_humanPlayer.DiceRolls.Dice[1].IsHeld);
    }
    
    [Fact]
    public void IsRollsLeft_ShouldReturnTrueIfRollsLeftElseShouldReturnFalse_WhenCalled()
    {
        _humanPlayer.DiceRolls.DecrementRollsLeft();
        _humanPlayer.DiceRolls.DecrementRollsLeft();
        _humanPlayer.DiceRolls.DecrementRollsLeft();
        Assert.False(_humanPlayer.DiceRolls.IsRollsLeft());
        
        _humanPlayer.StartPlayerTurn();
        Assert.True(_humanPlayer.DiceRolls.IsRollsLeft());
    }

    [Fact]
    public void AddToPlayerScore_ShouldIncreasePlayerScore_WhenCalled()
    {
        _humanPlayer.AddToPlayScore(50);
        _humanPlayer.AddToPlayScore(36);
        
        Assert.Equal(86, _humanPlayer.Score);
    }
}