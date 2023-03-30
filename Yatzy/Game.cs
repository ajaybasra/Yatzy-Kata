using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly HumanPlayer _humanPlayer;
    private readonly Bot _bot;
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler, HumanPlayer humanPlayer, Bot bot)
    {
        _consoleHandler = consoleHandler;
        _humanPlayer = humanPlayer;
        _bot = bot;
        TurnsRemaining = 15; // numb of categories
    }

    public void Initialize()
    {
        _consoleHandler.ShowIntro();
        Play();
    }

    private void Play()
    {
        while (TurnsRemaining > 0)
        {
            _bot.StartPlayerTurn();
            
            if (_consoleHandler.WantToQuit(TurnsRemaining)) break;
            
            _bot.ChooseWhatToDoWithDice(_consoleHandler, _bot.DiceRolls);
            
            _bot.ChooseCategoryToPlay(_consoleHandler);

            TurnsRemaining--;
        }
        _consoleHandler.ShowOutro(_bot.Score);
    }
}