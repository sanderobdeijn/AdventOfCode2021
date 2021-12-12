namespace AdventOfCode2021.Day11;

public class Octopus
{
    public Octopus(int x, int y, int energy)
    {
        X = x;
        Y = y;
        Energy = energy;
    }

    public int X { get; init; }

    public int Y { get; init; }

    public int Energy { get; private set; }

    public bool CanFlash => Energy == 10 && HasFlashed == false;

    public bool HasFlashed { get; private set; } = false;

    public void AddEnergy()
    {
        if(Energy != 10)
        {
            Energy++;
        }
    }
    public bool IsAdjacent(Octopus point)
    {
        return Math.Abs(Y - point.Y) <= 1 && Math.Abs(X - point.X) <= 1;
    }

    internal void Flash()
    {
        HasFlashed = true;
    }

    internal void Reset()
    {
        Energy = 0;
        HasFlashed = false;
    }
}
