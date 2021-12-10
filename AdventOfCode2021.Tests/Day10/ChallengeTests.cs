namespace AdventOfCode2021.Tests.Day10;

using AdventOfCode2021.Day10;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day10\example.txt");

        Assert.NotEmpty(challenge.NavigationLines);
        Assert.Equal(10, challenge.NavigationLines.Count);

        Assert.Equal(Status.Incomplete, challenge.NavigationLines.ElementAt(0).DeterimineStatus().status);
        Assert.Equal(Status.Incomplete, challenge.NavigationLines.ElementAt(1).DeterimineStatus().status);
        Assert.Equal(Status.Corrupt, challenge.NavigationLines.ElementAt(2).DeterimineStatus().status);

        Assert.Equal(26397, challenge.CalculateErrorScore());

        var completionScores = challenge.CalculateCompletionScores();
        Assert.NotEmpty(completionScores);
        Assert.Equal(5, completionScores.Count);

        Assert.Equal(288957, challenge.CalculateCompletionScore());

    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day10\input.txt");

        Assert.NotEmpty(challenge.NavigationLines);
        Assert.Equal(90, challenge.NavigationLines.Count);

        Assert.Equal(265527, challenge.CalculateErrorScore());

        var completionScores = challenge.CalculateCompletionScores().OrderBy(x => x);

        Assert.DoesNotContain(completionScores, x => x < 0);

        Assert.Equal(3969823589, challenge.CalculateCompletionScore());
    }
}