using Yatzy.Interfaces;

namespace Yatzy.IO;

public class ConsoleHandler
{
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public ConsoleHandler(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }
}