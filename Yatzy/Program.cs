using Yatzy;
using Yatzy.IO;

var reader = new Reader();
var writer = new Writer();
var diceRoll = new DiceRoll();
var player = new Player(diceRoll);
var categoryScoreCalculator = new CategoryScoreCalculator();
var playerCategories = new PlayerCategories(categoryScoreCalculator);
var consoleHandler = new ConsoleHandler(reader, writer);
var game = new Game(consoleHandler, player, playerCategories);

game.Initialize();