using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly IPlayerFactory _playerFactory;
    public List<IPlayer> ListOfPlayers { get; }
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler, IPlayerFactory playerFactory) //ask
    {
        _consoleHandler = consoleHandler;
        _playerFactory = playerFactory;
        ListOfPlayers = new List<IPlayer>() {};
        TurnsRemaining = Constants.TotalNumberOfRounds; // numb of categories
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
        ListOfPlayers.AddRange(_playerFactory.CreateHumanPlayers(numberOfHumans));
        ListOfPlayers.AddRange(_playerFactory.CreateBotPlayers(numberOfBots));
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