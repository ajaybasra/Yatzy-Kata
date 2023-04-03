using Yatzy.Interfaces;

namespace Yatzy;

public class PlayerFactory : IPlayerFactory
{
    public IPlayer CreateHuman(int i)
    {
        return new HumanPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()))
            { Name = $"Player {i + 1}" };
    }

    public IPlayer CreateBot(int i)
    {
        return new Bot(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator()))
            { Name = $"Bot {i + 1}" };
    }
}