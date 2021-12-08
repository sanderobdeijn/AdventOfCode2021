namespace AdventOfCode2021.Tests.Day03;

using AdventOfCode2021.Day03;

public class ChallengeTests
{
    [Fact]
    public void TestMostCommonBit()
    {
        Assert.Equal("1", Challenge.GetMostCommonBit(new List<char> { '1' }));
        Assert.Equal("0", Challenge.GetMostCommonBit(new List<char> { '0' }));
        Assert.Equal("1", Challenge.GetMostCommonBit(new List<char> { '1', '0', '1' }));
    }


    [Fact]
     public void TestExample()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day03\example.txt");

        Assert.NotEmpty(challenge.DiagnosticReports);
        Assert.Equal(12, challenge.DiagnosticReports.Count);

        var bitsGroupedByPosition = Challenge.GetBitsGroupedByPosition(challenge.DiagnosticReports);

        Assert.Equal("011110011100", bitsGroupedByPosition.First());
        Assert.Equal(5, bitsGroupedByPosition.Count());

        Assert.Equal("10110", Challenge.GetMostCommonBits(bitsGroupedByPosition));

        Assert.Equal(22, challenge.GetGammaRate());
        Assert.Equal(9, challenge.GetEpsilonRate());
        Assert.Equal(198, challenge.GetPowerConsumption());
        Assert.Equal(23, challenge.GetOxygenRating());
        Assert.Equal(10, challenge.GetCO2ScrubberRating());
        Assert.Equal(230, challenge.GetLifeSupportRating());
    }

    [Fact]
    public void TestInput()
    {
        var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day03\input.txt");

        Assert.NotEmpty(challenge.DiagnosticReports);
        Assert.Equal(1000, challenge.DiagnosticReports.Count);

        var bitsGroupedByPosition = Challenge.GetBitsGroupedByPosition(challenge.DiagnosticReports);

        Assert.Equal(12, bitsGroupedByPosition.Count());

        Assert.Equal("000100011100", Challenge.GetMostCommonBits(bitsGroupedByPosition));

        Assert.Equal(284, challenge.GetGammaRate());
        Assert.Equal(3811, challenge.GetEpsilonRate());
        Assert.Equal(1082324, challenge.GetPowerConsumption());
        Assert.Equal(486, challenge.GetOxygenRating());
        Assert.Equal(2784, challenge.GetCO2ScrubberRating());
        Assert.Equal(1353024, challenge.GetLifeSupportRating());
    }
}
