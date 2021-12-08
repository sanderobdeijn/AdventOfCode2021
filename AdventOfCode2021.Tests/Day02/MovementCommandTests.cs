namespace AdventOfCode2021.Tests.Day02;

using AdventOfCode2021.Day02;
using Xunit;

public class MovementCommandTests
{
    [Theory]
    [InlineData("forward 4", MovementDirection.Forward, 4)]
    [InlineData("up 6", MovementDirection.Up, 6)]
    [InlineData("down 10", MovementDirection.Down, 10)]
    public void ParseMovement(string movementString, MovementDirection expectedDirection, int expectedDistance)
    {
        var movement = MovementCommand.FromString(movementString);

        Assert.NotNull(movement);
        Assert.Equal(expectedDirection, movement.Direction);
        Assert.Equal(expectedDistance, movement.Distance);
    }
}
