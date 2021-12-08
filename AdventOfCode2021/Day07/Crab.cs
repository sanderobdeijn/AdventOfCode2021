namespace AdventOfCode2021.Day07;

using System;

public record Crab(int Position)
{
    internal int CalculateFuelForPosition(int newPosition)
    {
        return Math.Abs(Position - newPosition);
    }

    internal int CalculateFuelWithExpensiveModeForPosition(int newPosition)
    {
        var distance = (double)Math.Abs(Position - newPosition);
        return (int)((distance + 1) * (distance / 2));
    }
}
