using Yatzy;
using Yatzy.IO;

var reader = new Reader();
var writer = new Writer();
var RNG = new RNG();
var categoryScoreCalculator = new CategoryScoreCalculator();
var playerCategories = new PlayerCategories(categoryScoreCalculator);
var playerCategoriesTwo = new PlayerCategories(categoryScoreCalculator);
var diceRoll = new DiceRoll(RNG);
var diceRollTwo = new DiceRoll(RNG);
var humanPlayer = new HumanPlayer(diceRoll, playerCategories) {Name = "Jeff"};
var bot = new Bot(diceRollTwo, playerCategoriesTwo) {Name = "Arnold"};
var consoleHandler = new ConsoleHandler(reader, writer);
var game = new Game(consoleHandler, humanPlayer, bot);

game.Initialize();