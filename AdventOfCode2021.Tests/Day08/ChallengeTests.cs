namespace AdventOfCode2021.Tests.Day08;

using AdventOfCode2021.Day08;

public class ChallengeTests
{
    [Fact]
    public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day08\example.txt");

        Assert.NotEmpty(challenge.Decoders);
        Assert.Equal(10, challenge.Decoders.Count);

        var allDecodedSignals = challenge.GetDecodedSignals();
        Assert.NotEmpty(allDecodedSignals);
        Assert.Contains("1", allDecodedSignals);
        Assert.Contains("4", allDecodedSignals);
        Assert.Contains("7", allDecodedSignals);
        Assert.Contains("8", allDecodedSignals);
        Assert.Equal(26, allDecodedSignals.Count(x => x == "1" | x == "4" | x == "7" | x == "8"));

        Assert.Contains("3", allDecodedSignals);
        Assert.Contains("9", allDecodedSignals);
        Assert.Contains("6", allDecodedSignals);
        Assert.Contains("2", allDecodedSignals);
        Assert.Contains("5", allDecodedSignals);
        //Assert.Contains(0, allDecodedSignals);
        Assert.Equal(40, allDecodedSignals.Count);
        Assert.Equal(61229, challenge.GetTotalOutputValue());

    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day08\input.txt");

        Assert.NotEmpty(challenge.Decoders);
        Assert.Equal(200, challenge.Decoders.Count);

        var allDecodedSignals = challenge.GetDecodedSignals();
        Assert.NotEmpty(allDecodedSignals);
        Assert.Contains("1", allDecodedSignals);
        Assert.Contains("4", allDecodedSignals);
        Assert.Contains("7", allDecodedSignals);
        Assert.Contains("8", allDecodedSignals);
        Assert.Equal(274, allDecodedSignals.Count(x => x == "1" | x == "4" | x == "7" | x == "8"));

        Assert.Contains("3", allDecodedSignals);
        Assert.Contains("9", allDecodedSignals);
        Assert.Contains("6", allDecodedSignals);
        Assert.Contains("2", allDecodedSignals);
        Assert.Contains("5", allDecodedSignals);
        Assert.Contains("0", allDecodedSignals);
        Assert.Equal(800, allDecodedSignals.Count);
        Assert.Equal(1012089, challenge.GetTotalOutputValue());


    }
}