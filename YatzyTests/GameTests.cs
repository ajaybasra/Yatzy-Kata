using Moq;
using Yahtzy.Enums;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class GameTests
{
    [Fact]
    public void Play_GivenAGameScenario_ShouldReturnCorrectScore()
    {
        var mockRng = new Mock<IRandomNumberGenerator>();
        mockRng.Setup(x => x.GetRandomNumber()).Returns(1);

        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.WantToQuit(It.IsAny<int>())).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.WantToReRoll()).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.GetCategory(It.IsAny<List<Category>>())).Returns(0);
        
        var categoryScoreCalculator = new CategoryScoreCalculator();
        var playerCategories = new PlayerCategories(categoryScoreCalculator);
        var diceRoll = new DiceRoll(mockRng.Object);
        var player = new Player(diceRoll, playerCategories);
        var game = new Game(mockConsoleHandler.Object, player);
        
        game.Initialize();
        
        Assert.Equal(69, player.Score);
    }

    [Fact]
    public void Play_WhenAllCategoriesPlayed_ShouldEndGame()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.WantToQuit(15)).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.WantToReRoll()).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.GetCategory(It.IsAny<List<Category>>())).Returns(0);
        
        
        var mockRng = new Mock<IRandomNumberGenerator>();
        mockRng.Setup(x => x.GetRandomNumber()).Returns(1);
        
        var categoryScoreCalculator = new CategoryScoreCalculator();
        var playerCategories = new PlayerCategories(categoryScoreCalculator);
        var diceRoll = new DiceRoll(mockRng.Object);
        var player = new Player(diceRoll, playerCategories);
        var game = new Game(mockConsoleHandler.Object, player);
        
        game.Initialize();
        
        mockConsoleHandler.Verify(console => console.ShowOutro(player.Score), Times.Once);
    }
}
