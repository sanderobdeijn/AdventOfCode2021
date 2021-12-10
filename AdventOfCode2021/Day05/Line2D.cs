namespace AdventOfCode2021.Day05;

public class Line2D
{
    public Line2D(Point2D point1, Point2D point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    public Point2D Point1 { get; set; }

    public Point2D Point2 { get; set; }

    public IEnumerable<Point2D> GetAllPointsIncludingIntermediates()
    {
        if (IsHorizontal)
        {
            var allXValues = GetLinearValues(Point1.X, Point2.X);
            return allXValues.Select(x => new Point2D(x, Point1.Y));
        }

        if (IsVertical)
        {
            var allXValues = GetLinearValues(Point1.Y, Point2.Y);

            return allXValues.Select(y => new Point2D(Point1.X, y));
        }

        if (IsDiagonal)
        {
            return GetDiagnogalPoints();
        }

        return Enumerable.Empty<Point2D>();
    }

    private IEnumerable<Point2D> GetDiagnogalPoints()
    {
        var allXValues = GetLinearValues(Point1.X, Point2.X).ToArray();
        var allYValues = GetLinearValues(Point1.Y, Point2.Y).ToArray();

        var diagonalPoints = new List<Point2D>();

        for (var i = 0; i < allXValues.Length; i++)
        {
            diagonalPoints.Add(new Point2D(allXValues[i], allYValues[i]));
        }

        return diagonalPoints;
    }

    private static IEnumerable<int> GetLinearValues(int value1, int value2)
    {
        var smallestValue = Math.Min(value1, value2);
        var largestValue = Math.Max(value1, value2);

        var allXValues = Enumerable.Range(smallestValue, largestValue - smallestValue + 1);

        if (value1 < value2)
        {
            return allXValues;
        }

        return allXValues.Reverse();
    }

    public bool IsHorizontal => Point1.Y == Point2.Y;

    public bool IsVertical => Point1.X == Point2.X;

    public bool IsDiagonal => Math.Abs(Point1.X - Point2.X) == Math.Abs(Point1.Y - Point2.Y);
}