using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly HumanPlayer _humanPlayer;
    private int TurnsRemaining { get; set; }

    public Game(IConsoleHandler consoleHandler, HumanPlayer humanPlayer)
    {
        _consoleHandler = consoleHandler;
        _humanPlayer = humanPlayer;
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
            _humanPlayer.StartPlayerTurn();
            
            if (_consoleHandler.WantToQuit(TurnsRemaining)) break;
            
            _humanPlayer.ChooseWhatToDoWithDice(_consoleHandler, _humanPlayer.DiceRolls);
            
            _humanPlayer.ChooseCategoryToPlay(_consoleHandler);

            TurnsRemaining--;
        }
        _consoleHandler.ShowOutro(_humanPlayer.Score);
    }
}