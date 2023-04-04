namespace Yatzy.Interfaces;

public interface IPlayerFactory
{
    public List<IPlayer> CreateHumans(int numberOfHumans);
    public List<IPlayer> CreateBots(int numberOfBots);
}