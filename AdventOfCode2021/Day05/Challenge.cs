namespace AdventOfCode2021.Day05;

public class Challenge
{
    public List<Line2D> Clouds { get; set; }

    public Challenge(string inputFile)
    {
        Clouds = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<Line2D> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).Select(x => ParseStringToLine(x));
    }

    private static Line2D ParseStringToLine(string lineCoordidateString)
    {
        var points = lineCoordidateString.Split(" -> ").Select(x => PointFromString(x));

        return new Line2D(points.First(), points.Last());
    }

    private static Point2D PointFromString(string point)
    {
        var coordinates = point.Split(',').Select(x => int.Parse(x));

        return new Point2D(coordinates.First(), coordinates.Last());
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public static IEnumerable<Point2D> GetAllPointsIncludingIntermediateForClouds(IEnumerable<Line2D> clouds)
    {
        return clouds.SelectMany(x => x.GetAllPointsIncludingIntermediates());
    }

    public IEnumerable<Line2D> GetOrthogonalClouds()
    {
        return Clouds.Where(x => x.IsHorizontal || x.IsVertical);
    }

    public IEnumerable<Line2D> GetDiagonalLines()
    {
        return Clouds.Where(x => x.IsDiagonal);
    }

    public static int GetNumberOfOverlappingPoints(IEnumerable<Point2D> points)
    {
        var groupedPoints = points.GroupBy(x => x);
        var overlappingPoints = groupedPoints.Where(x => x.Count() > 1);

        return overlappingPoints.Count();
    }
}
