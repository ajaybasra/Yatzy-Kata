using Yatzy;
using Yatzy.IO;

var reader = new Reader();
var writer = new Writer();
var consoleHandler = new ConsoleHandler(reader, writer);
var game = new Game(consoleHandler);

game.Initialize();