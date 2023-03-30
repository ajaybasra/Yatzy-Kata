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
        ListOfPlayers.Add(_humanPlayer);
        ListOfPlayers.Add(_bot);
        Play();
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
        _consoleHandler.Winner(ListOfPlayers);
    }
}