namespace AdventOfCode2021.Tests.Day09;

using AdventOfCode2021.Day09;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day09\example.txt");

        Assert.NotEmpty(challenge.Points);
        Assert.Equal(50, challenge.Points.Count);

        Assert.Equal(15, challenge.CalculateResultPart1());

        var basins = challenge.GetBasins();
        Assert.Equal(4, basins.Count);
        Assert.Equal(3, basins.First().Count);
        Assert.Equal(9, basins.ElementAt(1).Count);

        Assert.Equal(1134, challenge.CalculateResultPart2());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day09\input.txt");

        Assert.NotEmpty(challenge.Points);
        Assert.Equal(10000, challenge.Points.Count);

        Assert.Equal(486, challenge.CalculateResultPart1());

        Assert.Equal(1059300, challenge.CalculateResultPart2());
    }
}