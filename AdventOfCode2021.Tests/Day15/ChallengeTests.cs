namespace AdventOfCode2021.Tests.Day15;

using System.Text;
using AdventOfCode2021.Day15;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day15\example.txt");

        Assert.NotEmpty(challenge.RiskLevels);
        Assert.Equal(10, challenge.RiskLevels.Length);

        Assert.Equal(40, challenge.SolvePart1());
    }

    [Fact]
    public void TestExamplePart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day15\example.txt");

        var expandedRiskLevels = Challenge.GetExpandedRiskLevels(challenge.RiskLevels);

        var sb = new StringBuilder();
        foreach (var expandedRiskLevel in expandedRiskLevels)
        {
            sb.AppendLine(string.Join(string.Empty,expandedRiskLevel.Select(x => x.ToString())));
        }

        Assert.Equal(2500, expandedRiskLevels.Sum(x=>x.Length));

        Assert.Equal(315, challenge.SolvePart2());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day15\input.txt");

        Assert.NotEmpty(challenge.RiskLevels);
        Assert.Equal(100, challenge.RiskLevels.Length);

        Assert.Equal(583, challenge.SolvePart1());
    }

    [Fact]
    public void TestInputPart2()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day15\input.txt");
          
        Assert.Equal(2927, challenge.SolvePart2());
    }
}