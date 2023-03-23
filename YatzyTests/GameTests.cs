using Moq;
using Yatzy.Interfaces;

namespace YatzyTests;

public class GameTests
{
    [Fact]
    public void Play_GivenAGameScenario_ShouldReturnCorrectScore()
    {
        var _mockRNG = new Mock<IRandomNumberGenerator>();
        _mockRNG.Setup(x => x.GetRandomNumber()).Returns(1);

        var _mockConsoleHandler = new Mock<IConsoleHandler>();
        _mockConsoleHandler.SetupSequence(console => console.ShowIntro()).Returns(ConsoleKey.Spacebar);
        _mockConsoleHandler.SetupSequence(console => console.WantToQuit(15)).Returns(false);
        
    }

    [Fact]
    public void Play_WhenAllCategoriesPlayed_ShouldEndGame()
    {
        
    }
}
