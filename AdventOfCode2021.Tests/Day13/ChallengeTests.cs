namespace AdventOfCode2021.Tests.Day13;

using AdventOfCode2021.Day13;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day13\example.txt");

        Assert.NotEmpty(challenge.Sheet.Dots);
        Assert.Equal(165, challenge.Sheet.Dots.Length);
        Assert.Equal(18, challenge.Sheet.NumberOfDots);

        Assert.NotEmpty(challenge.FoldInstructions);
        Assert.Equal(2, challenge.FoldInstructions.Count);

        Assert.Equal(17, challenge.SolvePart1());

        Assert.Equal(16, challenge.FoldAllInstructions().NumberOfDots);

        var result = challenge.SolvePart2();
        Assert.NotNull(result);
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day13\input.txt");

        Assert.NotEmpty(challenge.Sheet.Dots);
        Assert.Equal(1173345, challenge.Sheet.Dots.Length);
        Assert.Equal(953, challenge.Sheet.NumberOfDots);

        Assert.NotEmpty(challenge.FoldInstructions);
        Assert.Equal(12, challenge.FoldInstructions.Count);

        Assert.Equal(802, challenge.SolvePart1());

        Assert.Equal(103, challenge.FoldAllInstructions().NumberOfDots);

        var result = challenge.SolvePart2();
        Assert.NotNull(result);
    }
}