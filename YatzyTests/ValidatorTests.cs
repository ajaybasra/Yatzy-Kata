using Yahtzy.Enums;
using Yatzy;

namespace YatzyTests;

public class ValidatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData("one")]
    [InlineData("1,2,3,4,6")]
    [InlineData("-1")]
    [InlineData("0")] 
    public void ChosenDiceToHoldAreValid_ReturnsFalse_WhenGivenIncorrectInput(string input)
    {
        Assert.False(Validator.ChosenDiceToHoldAreValid(input));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("one")]
    [InlineData("Chance")]
    [InlineData("-1")]
    [InlineData("0")]
    [InlineData("16")]
    public void ChosenCategoryIsValid_ReturnsFalse_WhenGivenIncorrectInput(string input)
    {
        Assert.False(Validator.ChosenCategoryIsValid(input, new List<Category>()));
    }

    [Theory]
    [InlineData("")]
    [InlineData("one")]
    [InlineData("0")]
    [InlineData("5")]
    [InlineData("-1")]
    public void NumberOfHumansChosenIsValid_ReturnsFalse_WhenGivenIncorrectInput(string input)
    {
        Assert.False(Validator.NumberOfHumansChosenIsValid(input));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("one")]
    [InlineData("3")]
    [InlineData("-1")]
    public void NumberOfBotsChosenIsValid_ReturnsFalse_WhenGivenIncorrectInput(string input)
    {
        Assert.False(Validator.NumberOfBotsChosenIsValid(input));
    }
}