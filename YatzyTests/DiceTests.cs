using Moq;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class DiceTests
{

    private readonly Mock<IRandomNumberGenerator> _mockRNG;
    private readonly DiceRoller _diceRoller;
    private readonly Die _die;
    private readonly Die _dieNonMock;

    public DiceTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _diceRoller = new DiceRoller(new RNG());
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

        var arrayOfDiceRolls = _diceRoller.GetDiceRolls();
        
        Assert.Equal(5, arrayOfDiceRolls.Length);

    }
    
    [Fact]
    public void DiceRoll_RollDice_ShouldReturnNewValues()
    {

        var oldArrayOfDiceRolls = _diceRoller.GetDiceRolls();
        _diceRoller.RollDice();
        var newArrayOfDiceRolls = _diceRoller.GetDiceRolls();
        
        Assert.NotEqual(oldArrayOfDiceRolls, newArrayOfDiceRolls);

    }

    [Fact]
    public void DiceRoll_RollDice_ShouldNotRollDieWhichAreHeld()
    {
        var arrayOfDiceRolls = _diceRoller.GetDiceRolls();
        var originalFirstValue = arrayOfDiceRolls[0];
        var originalLastValue = arrayOfDiceRolls[4];
        
        _diceRoller.HoldDice(new[] {0, 4});
        _diceRoller.RollDice();
        var actualFirstValue = _diceRoller.GetDiceRolls()[0];
        var actualLastValue = _diceRoller.GetDiceRolls()[4];
        
        Assert.Equal(originalFirstValue, actualFirstValue);
        Assert.Equal(originalLastValue, actualLastValue);
    }

    [Fact]
    public void DiceRoll_SetNumberOfRolls_ShouldUpdateValue()
    {
        _diceRoller.SetNumberOfRolls(1);
        Assert.Equal(1, _diceRoller.NumberOfRollsLeft);
        
        _diceRoller.SetNumberOfRolls(3);
        Assert.Equal(3, _diceRoller.NumberOfRollsLeft);
    }
    
    [Fact]
    public void DiceRoll_DecrementRollsLeft_ShouldSubtractFromPlayerRolls()
    {
        _diceRoller.SetNumberOfRolls(3);
        _diceRoller.DecrementRollsLeft();
        Assert.Equal(2, _diceRoller.NumberOfRollsLeft);
        
        _diceRoller.SetNumberOfRolls(1);
        _diceRoller.DecrementRollsLeft();
        Assert.Equal(0, _diceRoller.NumberOfRollsLeft);
    }

    [Fact]
    public void DiceRoll_IsRollsLeft_ShouldReturnCorrectBool()
    {
        _diceRoller.SetNumberOfRolls(1);
        Assert.True(_diceRoller.IsRollsLeft());
        
        _diceRoller.SetNumberOfRolls(0);
        Assert.False(_diceRoller.IsRollsLeft());
    }
}