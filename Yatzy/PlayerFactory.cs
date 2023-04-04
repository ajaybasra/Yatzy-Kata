using Yatzy.Interfaces;

namespace Yatzy;

public class PlayerFactory : IPlayerFactory
{
    public List<IPlayer> CreateHumanPlayers(int numberOfHumans)
    {
        var listOfHumans = new List<IPlayer>();
        for (var i = 0; i < numberOfHumans; i++)
        {
            listOfHumans.Add(new HumanPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()))
                { Name = $"Player {i + 1}" });
        }

        return listOfHumans;
    }

    public List<IPlayer> CreateBotPlayers(int numberOfBots)
    {
        var listOfBots = new List<IPlayer>();
        for (var i = 0; i < numberOfBots; i++)
        {
            listOfBots.Add(new BotPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()))
                { Name = $"Computer {i + 1}" });
        }

        return listOfBots;
    }
}