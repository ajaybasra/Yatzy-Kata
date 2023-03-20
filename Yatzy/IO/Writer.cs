using Yatzy.Interfaces;

namespace Yatzy.IO;

public class Writer : IWriter
{
    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public void Write(string output)
    {
        Console.Write(output);
    }
}