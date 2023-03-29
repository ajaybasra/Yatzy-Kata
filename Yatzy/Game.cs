using Yatzy.Interfaces;

namespace Yatzy;

public class Game
{
    private readonly IConsoleHandler _consoleHandler;
    private readonly Player _player;

    public Game(IConsoleHandler consoleHandler, Player player)
    {
        _consoleHandler = consoleHandler;
        _player = player;
    }

    public void Initialize()
    {
        _consoleHandler.ShowIntro();
        Play();
    }

    private void Play()
    {
        while (!_player.PlayerCategories.IsCategoriesEmpty())
        {
            _player.StartPlayerTurn();
            
            if (_consoleHandler.WantToQuit(_player.PlayerCategories.GetCategoriesListSize())) break;
            
            while (_player.DiceRolls.IsRollsLeft())
            {
                _consoleHandler.ShowDiceRolls(_player.DiceRolls.GetDiceRolls());
                if (!_consoleHandler.WantToReRoll(_player.DiceRolls.GetNumberOfRollsLeft())) break;
                if (_consoleHandler.WantToHold())
                {
                    var diceToHold = _consoleHandler.GetDiceToHold().Split(",");
                    var diceToHoldAsInts = Array.ConvertAll(diceToHold, x => int.Parse(x) - 1);
                    _player.DiceRolls.HoldDice(diceToHoldAsInts);
                    if (_player.DiceRolls.NumberOfRollsLeft == 1) _consoleHandler.ShowDiceRolls(_player.DiceRolls.GetDiceRolls());
                }
                _player.DiceRolls.RollDice();
            }
            _consoleHandler.ShowCategories(_player.PlayerCategories.ListOfCategories);
            var chosenCategoryIndex = _consoleHandler.GetCategory(_player.PlayerCategories.ListOfCategories);
            var chosenCategory = _player.PlayerCategories.ListOfCategories[chosenCategoryIndex];
            _player.AddToPlayScore(_player.PlayerCategories.PlaceRollsInCategory(chosenCategory, _player.DiceRolls.GetDiceRolls()));
            _player.PlayerCategories.RemoveCategory(chosenCategory);
            _consoleHandler.ShowScore(_player.Score);
        }
        _consoleHandler.ShowOutro(_player.Score);
    }
}