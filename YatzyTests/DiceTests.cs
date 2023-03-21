using Moq;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class DiceTests
{
    private readonly Mock<IDiceRoller> _mockDiceRoller;
    private readonly Mock<IDie> _mockDie;

    public DiceTests()
    {
        _mockDiceRoller = new Mock<IDiceRoller>();
        _mockDie = new Mock<IDie>();
    }
    
    [Fact]
    public void Die_RollDice_ShouldReturnNumberBetweenOneAndSixInclusive()
    {
        
        //Arrange
        _mockDie.Setup(die => die.RollDie()).Returns(1);

        //Act
        var actualRoll = _mockDie.Object.RollDie();
        
        Assert.Equal(1, actualRoll);

    }
    
    [Fact]
    public void DiceRoller_GetDiceRolls_ShouldReturnFiveDiceValues()
    {
        
        //Arrange
        var expectedDiceRolls = new int[] { 1, 2, 3, 4, 5 };
        _mockDiceRoller.Setup(die => die.GetDiceRolls()).Returns(new int[] {1, 2, 3, 4, 5});

        //Act
        var actualDiceRolls = _mockDiceRoller.Object.GetDiceRolls();
        
        Assert.Equal(expectedDiceRolls, actualDiceRolls);

    }
    
    [Fact]
    public void DiceRoller_RollDice_ShouldRollAllFiveDie()
    {
        
        _mockDiceRoller.Setup(die => die.RollDice());

        _mockDiceRoller.Object.RollDice();
        
        _mockDiceRoller.Verify(diceRoller => diceRoller.RollDice(), Times.Once);

    }
}