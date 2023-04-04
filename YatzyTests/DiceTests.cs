using Moq;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class DiceTests
{

    private readonly Mock<IRandomNumberGenerator> _mockRNG;
    private readonly DiceRoll _diceRoll;
    private readonly Die _die;
    private readonly Die _dieNonMock;

    public DiceTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _diceRoll = new DiceRoll(new RNG());
        _die = new Die(_mockRNG.Object);
        _dieNonMock = new Die(new RNG());
    }
    
    [Fact]
    public void Die_RollDie_ShouldReturnWhatRNGSpitsOut() 
    {
        
        _mockRNG.Setup(x => x.GetRandomNumber()).Returns(1);

        var actualRoll = _die.RollDie();
        
        Assert.Equal(1, actualRoll);
    }
   [Fact] 
    public void Die_WhenCreated_ShouldReturnNumberBetweenOneAndSixInclusive() 
    {
        
        var outputValue = _dieNonMock.DieValue;
        
        Assert.InRange(outputValue, 1, 6);
    }
    
    [Fact]
    public void DiceRoll_GetDiceRolls_ShouldReturnFiveDiceValues()
    {

        var arrayOfDiceRolls = _diceRoll.GetDiceRolls();
        
        Assert.Equal(5, arrayOfDiceRolls.Length);

    }
    
    [Fact]
    public void DiceRoll_RollDice_ShouldReturnNewValues()
    {

        var oldArrayOfDiceRolls = _diceRoll.GetDiceRolls();
        _diceRoll.RollDice();
        var newArrayOfDiceRolls = _diceRoll.GetDiceRolls();
        
        Assert.NotEqual(oldArrayOfDiceRolls, newArrayOfDiceRolls);

    }

    [Fact]
    public void DiceRoll_RollDice_ShouldNotRollDieWhichAreHeld()
    {
        var arrayOfDiceRolls = _diceRoll.GetDiceRolls();
        var originalFirstValue = arrayOfDiceRolls[0];
        var originalLastValue = arrayOfDiceRolls[4];
        
        _diceRoll.HoldDice(new[] {0, 4});
        _diceRoll.RollDice();
        var actualFirstValue = _diceRoll.GetDiceRolls()[0];
        var actualLastValue = _diceRoll.GetDiceRolls()[4];
        
        Assert.Equal(originalFirstValue, actualFirstValue);
        Assert.Equal(originalLastValue, actualLastValue);
    }

    [Fact]
    public void DiceRoll_SetNumberOfRolls_ShouldUpdateValue()
    {
        _diceRoll.SetNumberOfRolls(1);
        Assert.Equal(1, _diceRoll.NumberOfRollsLeft);
        
        _diceRoll.SetNumberOfRolls(3);
        Assert.Equal(3, _diceRoll.NumberOfRollsLeft);
    }
    
    [Fact]
    public void DiceRoll_DecrementRollsLeft_ShouldSubtractFromPlayerRolls()
    {
        _diceRoll.SetNumberOfRolls(3);
        _diceRoll.DecrementRollsLeft();
        Assert.Equal(2, _diceRoll.NumberOfRollsLeft);
        
        _diceRoll.SetNumberOfRolls(1);
        _diceRoll.DecrementRollsLeft();
        Assert.Equal(0, _diceRoll.NumberOfRollsLeft);
    }

    [Fact]
    public void DiceRoll_IsRollsLeft_ShouldReturnCorrectBool()
    {
        _diceRoll.SetNumberOfRolls(1);
        Assert.True(_diceRoll.IsRollsLeft());
        
        _diceRoll.SetNumberOfRolls(0);
        Assert.False(_diceRoll.IsRollsLeft());
    }
}