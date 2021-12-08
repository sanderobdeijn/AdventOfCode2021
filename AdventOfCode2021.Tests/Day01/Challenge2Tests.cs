namespace AdventOfCode2021.Tests.Day01;

using AdventOfCode2021.Day01;

public class Challenge2Tests
{
    [Fact]
    public void GetNumberOfIncreasedDepths()
    {
        var challenge = new Challenge2(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day01\Input1.txt");

        Assert.Equal(1858, challenge.GetNumberOfIncreasedDepths());
    }
}