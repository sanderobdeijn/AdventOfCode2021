namespace AdventOfCode2021.Tests.Day11;

using AdventOfCode2021.Day11;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day11\example.txt");

        Assert.NotEmpty(challenge.StartCavern.Octopi);
        Assert.Equal(100, challenge.StartCavern.Octopi.Count);

        Assert.Equal(1656, challenge.GetTotalFlashesForSteps(100));
    }

    [Fact]
    public void TestExamplePart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day11\example.txt");

        Assert.NotEmpty(challenge.StartCavern.Octopi);
        Assert.Equal(100, challenge.StartCavern.Octopi.Count);

        Assert.Equal(195, challenge.GetStepWhereAllOctopiAreSynchronized());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day11\input.txt");

        Assert.NotEmpty(challenge.StartCavern.Octopi);
        Assert.Equal(100, challenge.StartCavern.Octopi.Count);

        Assert.Equal(1599, challenge.GetTotalFlashesForSteps(100));
    }

    [Fact]
    public void TestInputPart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day11\input.txt");

        Assert.NotEmpty(challenge.StartCavern.Octopi);
        Assert.Equal(100, challenge.StartCavern.Octopi.Count);

        Assert.Equal(418, challenge.GetStepWhereAllOctopiAreSynchronized());
    }
}