namespace AdventOfCode2021.Tests.Day05;

using AdventOfCode2021.Day05;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day05\example.txt");

        Assert.NotEmpty(challenge.Clouds);
        Assert.Equal(10, challenge.Clouds.Count);

        var orthogonalClouds = challenge.GetOrthogonalClouds();

        Assert.Equal(6, orthogonalClouds.Count());

        var orthogonalPoints = Challenge.GetAllPointsIncludingIntermediateForClouds(orthogonalClouds);

        Assert.NotEmpty(orthogonalPoints);
        Assert.Equal(26, orthogonalPoints.Count());

        Assert.Equal(5, Challenge.GetNumberOfOverlappingPoints(orthogonalPoints));

        var allPoints = Challenge.GetAllPointsIncludingIntermediateForClouds(challenge.Clouds);

        Assert.NotEmpty(allPoints);
        Assert.Equal(53, allPoints.Count());

        Assert.Equal(12, Challenge.GetNumberOfOverlappingPoints(allPoints));
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day05\input.txt");

        Assert.NotEmpty(challenge.Clouds);
        Assert.Equal(500, challenge.Clouds.Count);

        var orthogonalClouds = challenge.GetOrthogonalClouds();

        Assert.Equal(341, orthogonalClouds.Count());

        var orthogonalPoints = Challenge.GetAllPointsIncludingIntermediateForClouds(orthogonalClouds);

        Assert.NotEmpty(orthogonalPoints);
        Assert.Equal(121384, orthogonalPoints.Count());

        Assert.Equal(7674, Challenge.GetNumberOfOverlappingPoints(orthogonalPoints));

        var allPoints = Challenge.GetAllPointsIncludingIntermediateForClouds(challenge.Clouds);

        Assert.NotEmpty(allPoints);
        Assert.Equal(201106, allPoints.Count());

        Assert.Equal(20898, Challenge.GetNumberOfOverlappingPoints(allPoints));
    }

    [Fact]
    public void ReverseDiagonal()
    {
        var line = new Line2D(new Point2D(8, 0), new Point2D(0, 8));

        var points = line.GetAllPointsIncludingIntermediates();

        Assert.DoesNotContain(points, x => x == new Point2D(0, 0));
        Assert.DoesNotContain(points, x => x == new Point2D(8, 8));

        Assert.Equal(9, points.Count());
    }
}
