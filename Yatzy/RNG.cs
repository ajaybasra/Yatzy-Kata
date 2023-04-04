using Yatzy.Interfaces;

namespace Yatzy;

public class RNG : IRandomNumberGenerator
{
    public int GetRandomNumber()
    {
        var rnd = new Random();
        return rnd.Next(1, 7);
    }
}