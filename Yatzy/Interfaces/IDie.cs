namespace Yatzy.Interfaces;

public interface IDie
{
    bool IsHeld { get; set; }
    int DieValue { get; set; }
}