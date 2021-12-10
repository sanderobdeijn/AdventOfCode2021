namespace AdventOfCode2021.Day09;
public record class Point(int X,int Y, int Value)
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

    public bool IsPointLowerThanAdjacentPoints(IEnumerable<Point> AdjacentPoints)
    {
        return Value < AdjacentPoints.Min(p => p.Value);
    }
}