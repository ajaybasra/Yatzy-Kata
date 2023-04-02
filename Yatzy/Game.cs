using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    public List<IPlayer> ListOfPlayers { get; set; }
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler)
    {
        _consoleHandler = consoleHandler;
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
            ListOfPlayers.Add(new HumanPlayer(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator())) {Name = $"Player {i + 1}"});
        }
        
        for (var i = 0; i < numberOfBots; i++)
        {
            ListOfPlayers.Add(new Bot(new DiceRoll(new RNG()), new PlayerCategories(new CategoryScoreCalculator())) {Name = $"Bot {i + 1}"});
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