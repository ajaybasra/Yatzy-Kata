using Moq;
using Yahtzy.Enums;
using Yatzy;
using Yatzy.Interfaces;

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
    public void GivenAHumanPlayer_AtStartOfGame_ScoreShouldBeZero()
    {
        Assert.Equal(0, _humanPlayer.Score);
    }

    [Fact]
    public void GivenAPlayer_AtStartOfGame_ShouldBeAssignedFiveDice()
    {
        var humanPlayer = new HumanPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()));
        Assert.Equal(5, humanPlayer.DiceRolls.Dice.Count);
    }
    
    [Fact]
    public void GivenAPlayer_AtStartOfGame_ShouldBeAssignedFifteenCategories()
    {
        var humanPlayer = new HumanPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()));
        Assert.Equal(15, humanPlayer.PlayerCategories.GetCategoriesListSize());
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
    public void AddToPlayerScore_ShouldIncreasePlayerScore_WhenCalled()
    {
        _humanPlayer.AddToPlayScore(50);
        _humanPlayer.AddToPlayScore(36);
        
        Assert.Equal(86, _humanPlayer.Score);
    }

    [Fact]
    public void ChooseWhatToDoWithDice_WhenPlayerHoldsDice_ThoseDiceValueDoesNotChange()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.WantToReRoll(It.IsAny<int>())).Returns(true);
        mockConsoleHandler.SetupSequence(console => console.WantToHold()).Returns(true);
        mockConsoleHandler.SetupSequence(console => console.GetDiceToHold()).Returns("1,5");
        
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var diceRoll = new DiceRoll(new RNG());
        var humanPlayer = new HumanPlayer(diceRoll, playerCategories);
        
        var arrayOfDiceRolls = humanPlayer.DiceRolls.GetDiceRolls();
        var originalFirstValue = arrayOfDiceRolls[0];
        var originalLastValue = arrayOfDiceRolls[4];
        
        humanPlayer.ChooseWhatToDoWithDice(mockConsoleHandler.Object, diceRoll);
        
        var actualFirstValue = humanPlayer.DiceRolls.GetDiceRolls()[0];
        var actualLastValue = humanPlayer.DiceRolls.GetDiceRolls()[4];
        
        Assert.Equal(originalFirstValue, actualFirstValue);
        Assert.Equal(originalLastValue, actualLastValue);
    }

    [Fact]
    public void ChooseCategoryToPlay_WhenPlayerChoosesCategory_ThatCategoryIsRemoved()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.GetCategory(It.IsAny<List<Category>>())).Returns(0);

        
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var diceRoll = new DiceRoll(new RNG());
        var humanPlayer = new HumanPlayer(diceRoll, playerCategories);
        
        humanPlayer.ChooseCategoryToPlay(mockConsoleHandler.Object);
        
        Assert.Equal(14, humanPlayer.PlayerCategories.GetCategoriesListSize());
        Assert.False(humanPlayer.PlayerCategories.ListOfCategories[0] is Category.Chance);
    }
}