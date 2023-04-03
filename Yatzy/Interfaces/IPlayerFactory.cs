namespace Yatzy.Interfaces;

public interface IPlayerFactory
{
    public IPlayer CreateHuman(int i);
    public IPlayer CreateBot(int i);
}