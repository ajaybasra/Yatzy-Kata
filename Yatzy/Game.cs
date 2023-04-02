using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly HumanPlayer _humanPlayer;
    private readonly Bot _bot;
    public List<IPlayer> ListOfPlayers { get; set; }
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler, HumanPlayer humanPlayer, Bot bot)
    {
        _consoleHandler = consoleHandler;
        ListOfPlayers = new List<IPlayer>() {};
        _humanPlayer = humanPlayer;
        _bot = bot;
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
        _consoleHandler.ShowOutro(_bot.Score);
        _consoleHandler.FinalScores(ListOfPlayers);
        
    }
}