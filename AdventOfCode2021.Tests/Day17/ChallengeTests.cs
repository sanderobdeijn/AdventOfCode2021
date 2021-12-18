namespace AdventOfCode2021.Tests.Day17;

using AdventOfCode2021.Day17;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day17\input.txt");

        Assert.Equal((20,-10), challenge.Target.Start);
        Assert.Equal((30, -5), challenge.Target.End);

        var probe = new ProbeLaunch(7, 2, challenge.Target);
        Assert.True(probe.ReachedTarget);

        probe = new ProbeLaunch(6, 3, challenge.Target);
        Assert.True(probe.ReachedTarget);

        Assert.True(new ProbeLaunch(9, 0, challenge.Target).ReachedTarget);
        Assert.False(new ProbeLaunch(17, -4, challenge.Target).ReachedTarget);

        Assert.Equal(45, challenge.SolvePart1());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day17\input.txt");

        Assert.Equal((211, -124), challenge.Target.Start);
        Assert.Equal((232, -69), challenge.Target.End);

        //Assert.Equal(45, challenge.SolvePart1());
    }
}