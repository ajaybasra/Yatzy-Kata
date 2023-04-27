using Moq;
using Yahtzy.Enums;
using Yatzy;
using Yatzy.Interfaces;
using Yatzy.IO;

namespace YatzyTests;

public class BotTests
{
    [Fact]
    public void ChooseCategoryToPlay_WhenPlayerChoosesCategory_ThatCategoryIsRemoved()
    {
        
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var diceRoll = new DiceRoller(new RNG());
        var consoleHandler = new ConsoleHandler(new Reader(), new Writer());
        var botPlayer = new BotPlayer(diceRoll, playerCategories);

        void BotPlaysXTurns(int x)
        {
            for (var i = 0; i < x; i++)
            {
                botPlayer.ChooseCategoryToPlay(consoleHandler);
            }
        }

        BotPlaysXTurns(5);
        Assert.Equal(10, botPlayer.PlayerCategories.GetCategoriesListSize());
    }
    
    [Fact]
    public void ChooseCategoryToPlay_WhenPlayerChoosesCategory_TheirScoreUpdates()
    {
        var mockRng = new Mock<IRandomNumberGenerator>();
        mockRng.Setup(x => x.GetRandomNumber()).Returns(1);
        
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var diceRoll = new DiceRoller(mockRng.Object);
        var consoleHandler = new ConsoleHandler(new Reader(), new Writer());
        var botPlayer = new BotPlayer(diceRoll, playerCategories);

        void BotPlaysXTurns(int x)
        {
            for (var i = 0; i < x; i++)
            {
                botPlayer.ChooseCategoryToPlay(consoleHandler);
            }
        }

        BotPlaysXTurns(5);
        Assert.Equal(67, botPlayer.Score);
    }

    [Fact]
    public void ChooseWhatToDoWithDice_ShouldCallConsoleMethodsAppropriateAmountOfTimes_WhenCalled()
    {
        var playerCategories = new PlayerCategories(new CategoryScoreCalculator());
        var diceRoll = new DiceRoller(new RNG());
        var mockConsoleHandler = new Mock<IConsoleHandler>();
        var botPlayer = new BotPlayer(diceRoll, playerCategories);
        
        botPlayer.ChooseWhatToDoWithDice(mockConsoleHandler.Object, diceRoll);
        
        mockConsoleHandler.Verify(console => console.BotRolledDice(), Times.Once);
        mockConsoleHandler.Verify(console => console.BotRolledDice(), Times.Once);
        mockConsoleHandler.Verify(console => console.BotRolledDice(), Times.Once);
    }
}