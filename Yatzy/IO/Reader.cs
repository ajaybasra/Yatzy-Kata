using Yatzy.Interfaces;

namespace Yatzy.IO;

public class Reader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}