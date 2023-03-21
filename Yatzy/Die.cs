using Yatzy.Interfaces;

namespace Yatzy;

public class Die : IDie
{
    public bool IsHeld { get; set; }
    public int DieValue { get; set; }
    private readonly IRandomNumberGenerator _rng;

    public Die(IRandomNumberGenerator rng)
    {
        _rng = rng;
        IsHeld = false;
        RollDie();
    }

    public int RollDie()
    {
        DieValue = _rng.GetRandomNumber();
        return DieValue;
    }
}