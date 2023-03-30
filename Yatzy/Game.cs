using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly HumanPlayer _humanPlayer;

    public Game(IConsoleHandler consoleHandler, HumanPlayer humanPlayer)
    {
        _consoleHandler = consoleHandler;
        _humanPlayer = humanPlayer;
    }

    public void Initialize()
    {
        _consoleHandler.ShowIntro();
        Play();
    }

    private void Play()
    {
        while (!_humanPlayer.PlayerCategories.IsCategoriesEmpty())
        {
            _humanPlayer.StartPlayerTurn();
            
            if (_consoleHandler.WantToQuit(_humanPlayer.PlayerCategories.GetCategoriesListSize())) break;
            
            _humanPlayer.ChooseWhatToDoToDice(_consoleHandler, _humanPlayer.DiceRolls);
            
            _humanPlayer.ChooseCategoryToPlay(_consoleHandler);
        }
        _consoleHandler.ShowOutro(_humanPlayer.Score);
    }
}