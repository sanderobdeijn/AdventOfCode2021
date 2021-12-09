namespace AdventOfCode2021.Day09;
public record class Point(int X,int Y, int Value)
{
    public bool IsAdjacent(Point point)
    {
        if (this.X == point.X)
        {
            return Math.Abs(this.Y - point.Y) == 1;
        }
        if (this.Y == point.Y)
        {
            return Math.Abs(this.X - point.X) == 1;
        }

        return false;
    }

    public bool IsPointLowerThanAdjacentPoints(IEnumerable<Point> AdjacentPoints)
    {
        return this.Value < AdjacentPoints.Min(p => p.Value);
    }
}