namespace AdventOfCode2021.Day15;
public record class Point(int X,int Y)
{
    public bool IsAdjacent(Point point)
    {
        if (X == point.X)
        {
            return Math.Abs(Y - point.Y) == 1;
        }
        if (Y == point.Y)
        {
            return Math.Abs(X - point.X) == 1;
        }

        return false;
    }
}