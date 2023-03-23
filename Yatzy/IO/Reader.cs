using Yatzy.Interfaces;

namespace Yatzy.IO;

public class Reader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey(true); // set to true so that key isn't displayed to console
    }
}