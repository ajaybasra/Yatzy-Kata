using Moq;
using Yatzy;
using Yatzy.Interfaces;

namespace YatzyTests;

public class GameTests
{
    [Fact]
    public void Play_GivenAGameScenario_ShouldReturnCorrectScore()
    {
        var mockRng = new Mock<IRandomNumberGenerator>();
        if (mockRng == null) throw new ArgumentNullException(nameof(mockRng));
        mockRng.Setup(x => x.GetRandomNumber()).Returns(1);

        var _mockDiceRoll = new Mock<IDiceRoller>();
        var fixedArrayOfDice = new int[] { 1, 1, 1, 1, 1 };
        _mockDiceRoll.Setup(x => x.GetDiceRolls()).Returns(fixedArrayOfDice);

        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro()).Returns(ConsoleKey.Spacebar);
        mockConsoleHandler.SetupSequence(console => console.WantToQuit(15)).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.WantToReroll()).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.GetCategory()).Returns(0);
        
        var die = new Die(mockRng.Object);
        var diceRoll = new DiceRoll();
        var player = new Player(diceRoll);
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var game = new Game(mockConsoleHandler.Object, player, playerCategories);
        
        game.Initialize();
        
        Assert.Equal(99, player.Score);
    }

    [Fact]
    public void Play_WhenAllCategoriesPlayed_ShouldEndGame()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro()).Returns(ConsoleKey.Spacebar);
        mockConsoleHandler.SetupSequence(console => console.WantToQuit(15)).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.WantToReroll()).Returns(false);
        mockConsoleHandler.SetupSequence(console => console.GetCategory()).Returns(0);
        
        var diceRoll = new DiceRoll();
        var player = new Player(diceRoll);
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var game = new Game(mockConsoleHandler.Object, player, playerCategories);
        
        game.Initialize();
        
        mockConsoleHandler.Verify(console => console.ShowOutro(player.Score), Times.Once);
    }
}
