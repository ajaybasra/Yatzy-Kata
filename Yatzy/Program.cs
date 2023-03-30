using Yatzy;
using Yatzy.IO;

var reader = new Reader();
var writer = new Writer();
var RNG = new RNG();
var categoryScoreCalculator = new CategoryScoreCalculator();
var playerCategories = new PlayerCategories(categoryScoreCalculator);
var diceRoll = new DiceRoll(RNG);
var player = new HumanPlayer(diceRoll, playerCategories);
var consoleHandler = new ConsoleHandler(reader, writer);
var game = new Game(consoleHandler, player);

game.Initialize();