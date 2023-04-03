using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private IPlayerFactory _playerFactory;
    private List<IPlayer> ListOfPlayers { get; set; }
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler, IPlayerFactory playerFactory)
    {
        _consoleHandler = consoleHandler;
        _playerFactory = playerFactory;
        ListOfPlayers = new List<IPlayer>() {};
        TurnsRemaining = 15; // numb of categories
    }
    
    public void Initialize()
    {
        _consoleHandler.ShowIntro();
        var (numberOfHumans, numberOfBots) = _consoleHandler.GetNumberOfHumansAndBots();
        AddPlayersToGame(numberOfHumans, numberOfBots);
        Play();
    }

    private void AddPlayersToGame(int numberOfHumans, int numberOfBots)
    {
        for (var i = 0; i < numberOfHumans; i++)
        {
            ListOfPlayers.Add(_playerFactory.CreateHuman(i));
        }
        
        for (var i = 0; i < numberOfBots; i++)
        {
            ListOfPlayers.Add(_playerFactory.CreateBot(i));
        }
    }

    private void Play()
    {
        while (TurnsRemaining > 0)
        {
            if (_consoleHandler.WantToQuit(TurnsRemaining)) break;
            
            foreach (var player in ListOfPlayers)
            {
                player.StartPlayerTurn();
                
                player.ChooseWhatToDoWithDice(_consoleHandler, player.DiceRolls);
            
                player.ChooseCategoryToPlay(_consoleHandler);
            }

            TurnsRemaining--;
        }
        _consoleHandler.ShowOutro();
        _consoleHandler.FinalScores(ListOfPlayers);
        
    }
}