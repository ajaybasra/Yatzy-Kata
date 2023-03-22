namespace Yatzy.Interfaces;

public interface IReader
{
    string ReadLine();

    ConsoleKeyInfo ReadKey();
}