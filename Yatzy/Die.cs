using Yatzy.Interfaces;

namespace Yatzy;

public class Die : IDie
{
    public bool IsHeld { get; set; }
    public int DieValue { get; set; }

    public Die(int value)
    {
        DieValue = value;
    }
}