using Moq;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class DiceTests
{

    private readonly Mock<IRandomNumberGenerator> _mockRNG;
    private readonly DiceRoll _diceRoller;
    private readonly Die _die;
    private readonly Die _dieNonMock;

    public DiceTests()
    {
        _mockRNG = new Mock<IRandomNumberGenerator>();
        _diceRoller = new DiceRoll(new RNG());
        _die = new Die(_mockRNG.Object);
        _dieNonMock = new Die(new RNG());
    }
    
    [Fact]
    public void Die_RollDice_ShouldReturnWhatRNGSpitsOut() 
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
        var actualFirstValue = _diceRoller.Dice[0].DieValue;
        var actualLastValue = _diceRoller.Dice[4].DieValue;
        
        Assert.Equal(originalFirstValue, actualFirstValue);
        Assert.Equal(originalLastValue, actualLastValue);
    }
    
    [Fact]
    public void DecrementRollsLeft_ShouldSubtractFromPlayerRolls_WhenCalled()
    {
        _diceRoller.SetNumberOfRolls(3);
        _diceRoller.DecrementRollsLeft();
        
        Assert.Equal(2, _diceRoller.NumberOfRollsLeft);
    }
 
}