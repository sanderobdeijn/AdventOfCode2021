namespace AdventOfCode2021.Tests.Day02;

using AdventOfCode2021.Day02;

public class ChallengeTests
{
    [Theory]
    [InlineData(MovementDirection.Forward, 1845)]
    [InlineData(MovementDirection.Down, 2053)]
    [InlineData(MovementDirection.Up, 1137)]
    public void GetTotalDistance(MovementDirection movementDirection, int totalDisance)
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day02\Input.txt");

        var totalDistance = challenge.GetTotalDistanceForDirection(movementDirection);

        Assert.Equal(totalDisance, totalDistance);
    }

    [Fact]
    public void GetResult()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day02\Input.txt");

        var totalForwardDistance = challenge.GetTotalDistanceForDirection(MovementDirection.Forward);
        var totalDownDistance = challenge.GetTotalDistanceForDirection(MovementDirection.Down);
        var totalUpDistance = challenge.GetTotalDistanceForDirection(MovementDirection.Up);

        var totalDepth = totalDownDistance - totalUpDistance;

        Assert.Equal(916, totalDepth);

        var movementMultiplication = totalForwardDistance * totalDepth;

        Assert.Equal(1690020, movementMultiplication);
    }

    [Fact]
    public void GetDepthWithAimCalculationForExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day02\example.txt");

        var totalForwardDistance = challenge.GetTotalDistanceForDirection(MovementDirection.Forward);

        var totalDepth = challenge.GetDepthWithAimCalculation();

        Assert.Equal(60, totalDepth);

        var movementMultiplication = totalForwardDistance * totalDepth;

        Assert.Equal(900, movementMultiplication);
    }

    [Fact]
    public void GetDepthWithAimCalculationForInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day02\input.txt");

        var totalForwardDistance = challenge.GetTotalDistanceForDirection(MovementDirection.Forward);

        var totalDepth = challenge.GetDepthWithAimCalculation();

        Assert.Equal(763408, totalDepth);

        var movementMultiplication = totalForwardDistance * totalDepth;

        Assert.Equal(1408487760, movementMultiplication);
    }
}
