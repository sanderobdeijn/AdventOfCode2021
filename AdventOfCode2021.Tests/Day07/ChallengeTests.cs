namespace AdventOfCode2021.Tests.Day07;

using AdventOfCode2021.Day07;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day07\example.txt");

        Assert.NotEmpty(challenge.Crabs);
        Assert.Equal(10, challenge.Crabs.Count);

        Assert.Equal(0, challenge.MinPosition);
        Assert.Equal(16, challenge.MaxPosition);

        Assert.Equal(49, challenge.CalculateFuelForMoveToPosition(challenge.MinPosition, false));
        Assert.Equal(111, challenge.CalculateFuelForMoveToPosition(challenge.MaxPosition, false));

        var reducedRange = challenge.ReduceRange(challenge.StartingRange, false);
        Assert.Equal(8, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(0, reducedRange.Start.Value);
        Assert.Equal(8, reducedRange.End.Value);

        reducedRange = challenge.ReduceRange(reducedRange, false);
        Assert.Equal(4, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(0, reducedRange.Start.Value);
        Assert.Equal(4, reducedRange.End.Value);

        reducedRange = challenge.ReduceRange(reducedRange, false);
        Assert.Equal(0, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(2, reducedRange.Start.Value);
        Assert.Equal(2, reducedRange.End.Value);

        var optimalPosition = challenge.CalculateOptimalPosition(false);
        Assert.Equal(2, optimalPosition);
        Assert.Equal(37, challenge.CalculateFuelForMoveToPosition(optimalPosition, false));
    }

    [Fact]
    public void TestExampleExpensiveMode()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day07\example.txt");

        Assert.NotEmpty(challenge.Crabs);
        Assert.Equal(10, challenge.Crabs.Count);

        Assert.Equal(0, challenge.MinPosition);
        Assert.Equal(16, challenge.MaxPosition);

        Assert.Equal(290, challenge.CalculateFuelForMoveToPosition(challenge.MinPosition, true));
        Assert.Equal(817, challenge.CalculateFuelForMoveToPosition(challenge.MaxPosition, true));

        var reducedRange = challenge.ReduceRange(challenge.StartingRange, true);
        Assert.Equal(8, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(0, reducedRange.Start.Value);
        Assert.Equal(8, reducedRange.End.Value);

        reducedRange = challenge.ReduceRange(reducedRange, true);
        Assert.Equal(4, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(2, reducedRange.Start.Value);
        Assert.Equal(6, reducedRange.End.Value);

        reducedRange = challenge.ReduceRange(reducedRange, true);
        Assert.Equal(0, reducedRange.End.Value - reducedRange.Start.Value);
        Assert.Equal(5, reducedRange.Start.Value);
        Assert.Equal(5, reducedRange.End.Value);

        var optimalPosition = challenge.CalculateOptimalPosition(true);
        Assert.Equal(5, optimalPosition);
        Assert.Equal(168, challenge.CalculateFuelForMoveToPosition(optimalPosition, true));
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day07\input.txt");

        Assert.NotEmpty(challenge.Crabs);
        Assert.Equal(1000, challenge.Crabs.Count);

        Assert.Equal(0, challenge.MinPosition);
        Assert.Equal(1955, challenge.MaxPosition);

        Assert.Equal(494601, challenge.CalculateFuelForMoveToPosition(challenge.MinPosition, false));
        Assert.Equal(1460399, challenge.CalculateFuelForMoveToPosition(challenge.MaxPosition, false));

        var optimalPosition = challenge.CalculateOptimalPosition(false);
        Assert.Equal(361, optimalPosition);
        Assert.Equal(354129, challenge.CalculateFuelForMoveToPosition(optimalPosition, false));
    }

    [Fact]
    public void TestInputExpensiveMode()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day07\input.txt");

        Assert.NotEmpty(challenge.Crabs);
        Assert.Equal(1000, challenge.Crabs.Count);

        Assert.Equal(0, challenge.MinPosition);
        Assert.Equal(1955, challenge.MaxPosition);

        Assert.Equal(221284603, challenge.CalculateFuelForMoveToPosition(challenge.MinPosition, true));
        Assert.Equal(1165835047, challenge.CalculateFuelForMoveToPosition(challenge.MaxPosition, true));

        var optimalPosition = challenge.CalculateOptimalPosition(true);
        Assert.Equal(494, optimalPosition);
        Assert.Equal(98905973, challenge.CalculateFuelForMoveToPosition(optimalPosition, true));
    }
}
