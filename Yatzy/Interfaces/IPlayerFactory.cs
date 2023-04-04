namespace Yatzy.Interfaces;

public interface IPlayerFactory
{
    public List<IPlayer> CreateHumanPlayers(int numberOfHumans);
    public List<IPlayer> CreateBotPlayers(int numberOfBots);
}