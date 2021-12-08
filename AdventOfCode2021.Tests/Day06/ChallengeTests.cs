namespace AdventOfCode2021.Tests.Day06;

using AdventOfCode2021.Day06;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day06\example.txt");
        var startDay = challenge.Start;

        Assert.Equal(4, startDay.LanternfishColonies.Count);
        Assert.Equal(5, startDay.LanternfishCount);

        var secondDay = challenge.Start.NextDay().NextDay();
        Assert.Equal(5, secondDay.LanternfishColonies.Count);
        Assert.Equal(6, secondDay.LanternfishCount);

        var endDay18 = challenge.SimulateUntilDay(18);
        Assert.Equal(9, endDay18.LanternfishColonies.Count);
        Assert.Equal(26, endDay18.LanternfishCount);

        var endDay80 = challenge.SimulateUntilDay(80);
        Assert.Equal(9, endDay80.LanternfishColonies.Count);
        Assert.Equal(5934, endDay80.LanternfishCount);

        var endDay256 = challenge.SimulateUntilDay(256);
        Assert.Equal(9, endDay256.LanternfishColonies.Count);
        Assert.Equal(26984457539, endDay256.LanternfishCount);

    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day06\input.txt");

        Assert.Equal(5, challenge.Start.LanternfishColonies.Count);
        Assert.Equal(300, challenge.Start.LanternfishCount);

        var endDay80 = challenge.SimulateUntilDay(80);
        Assert.Equal(9, endDay80.LanternfishColonies.Count);
        Assert.Equal(390923, endDay80.LanternfishCount);

        var endDay256 = challenge.SimulateUntilDay(256);
        Assert.Equal(9, endDay256.LanternfishColonies.Count);
        Assert.Equal(1749945484935, endDay256.LanternfishCount);
    }
}
