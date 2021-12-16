namespace AdventOfCode2021.Tests.Day14;

using AdventOfCode2021.Day14;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day14\example.txt");

        Assert.NotEmpty(challenge.PolymerPairs);
        Assert.Equal(16, challenge.PolymerPairs.Count);

        Assert.Equal(1588, challenge.SolvePart1());
    }

    [Fact]
    public void TestExamplePart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day14\example.txt");

        Assert.Equal(2188189693529, challenge.SolvePart2());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day14\input.txt");

        Assert.Equal(2745, challenge.SolvePart1());
    }

    [Fact]
    public void TestInputPart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day14\input.txt");

        Assert.Equal(3420801168962, challenge.SolvePart2());
    }
}