using Yatzy.Interfaces;

namespace Yatzy;

public class RNG : IRandomNumberGenerator
{
    public int GetRandomNumber()
    {
        Random rnd = new Random();
        return rnd.Next(1, 7);
    }
}