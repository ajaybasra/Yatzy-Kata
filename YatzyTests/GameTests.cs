using Moq;
using Yahtzy.Enums;
using Yatzy;
using Yatzy.Interfaces;
using Yatzy.IO;

namespace YatzyTests;

public class GameTests
{

    [Fact]
    public void Initialize_ShouldPrintIntroAndStartNewGame()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.GetNumberOfHumansAndBots()).Returns((1, 0));

        var playerFactory = new PlayerFactory();
        var game = new Game(mockConsoleHandler.Object, playerFactory);
        
        game.Initialize();
        
        mockConsoleHandler.Verify(console => console.ShowIntro(), Times.Once);
        mockConsoleHandler.Verify(console => console.WantToQuit(It.IsAny<int>()), Times.Exactly(15)); 
    }
    
    [Fact]
    public void AddPlayersToGame_ShouldAddGivenPlayersToGame()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.GetNumberOfHumansAndBots()).Returns((3, 2));

        var playerFactory = new PlayerFactory();
        var game = new Game(mockConsoleHandler.Object, playerFactory);
        
        game.Initialize();
        
        Assert.Equal(5, game.ListOfPlayers.Count);
        
    }
    
    [Fact]
    public void Play_GivenAGameScenario_ShouldReturnCorrectScore() // this messy mock was done so we can simulate a dice roll of 1 everytime
    {
        var mockRng = new Mock<IRandomNumberGenerator>();
        mockRng.Setup(x => x.GetRandomNumber()).Returns(1);
        var diceRoll = new DiceRoll(mockRng.Object);
        
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.GetNumberOfHumansAndBots()).Returns((1,0));

        var mockPlayerFactory = new Mock<IPlayerFactory>();
        var listOfHumans = new List<IPlayer> { new HumanPlayer(diceRoll, new PlayerCategories(new CategoryScoreCalculator())) };
        mockPlayerFactory.SetupSequence(x => x.CreateHumanPlayers(It.IsAny<int>()))
            .Returns(listOfHumans);
        mockPlayerFactory.SetupSequence(x => x.CreateBotPlayers(It.IsAny<int>()))
            .Returns(new List<IPlayer>());
    
        var game = new Game(mockConsoleHandler.Object, mockPlayerFactory.Object);
        
        game.Initialize();
        
        Assert.Equal(69, game.ListOfPlayers[0].Score);
    }
    
    [Fact]
    public void Play_WhenAllCategoriesPlayed_ShouldEndGame()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        var playerFactory = new PlayerFactory();
        var game = new Game(mockConsoleHandler.Object, playerFactory);
        
        game.Initialize();
        
        mockConsoleHandler.Verify(console => console.ShowOutro(), Times.Once);
    }
    
    [Fact]
    public void Play_GivenFirstRound_PlayerShouldBeAbleToQuitWithoutPlaying()
    {
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        mockConsoleHandler.SetupSequence(console => console.ShowIntro());
        mockConsoleHandler.SetupSequence(console => console.GetNumberOfHumansAndBots()).Returns((1,0));
        mockConsoleHandler.SetupSequence(console => console.WantToQuit(It.IsAny<int>())).Returns(true);
        var playerFactory = new PlayerFactory();
        var game = new Game(mockConsoleHandler.Object, playerFactory);
        
        game.Initialize();
        
        Assert.Equal(15, game.ListOfPlayers[0].PlayerCategories.GetCategoriesListSize()); // 0 categories played
    }
    
}
