namespace AdventOfCode2021.Tests.Day12;

using AdventOfCode2021.Day12;

public class ChallengeTests
{
    [Fact]
    public void TestExampleSmall()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day12\small-example.txt");

        Assert.Equal(10, challenge.FindRoutes().Count);

        Assert.Equal(36, challenge.FindRoutesWhileVisitingASingleSmallCaveTwice());
    }

    [Fact]
    public void TestExampleLarger()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day12\larger-example.txt");

        Assert.Equal(19, challenge.FindRoutes().Count);

        Assert.Equal(103, challenge.FindRoutesWhileVisitingASingleSmallCaveTwice());
    }

    [Fact]
    public void TestExampleBig()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day12\big-example.txt");

        Assert.Equal(226, challenge.FindRoutes().Count);

        Assert.Equal(3509, challenge.FindRoutesWhileVisitingASingleSmallCaveTwice());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day12\input.txt");

        Assert.Equal(3679, challenge.FindRoutes().Count);

        Assert.Equal(107395, challenge.FindRoutesWhileVisitingASingleSmallCaveTwice());
    }
}