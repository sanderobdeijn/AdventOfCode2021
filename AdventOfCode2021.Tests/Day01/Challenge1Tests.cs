namespace AdventOfCode2021.Tests.Day01;

using AdventOfCode2021.Day01;

public class Challenge1Tests
{
    [Fact]
    public void GetNumberOfIncreasedDepths()
    {
        var challenge1 = new Challenge1(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day01\Input1.txt");

        Assert.Equal(1832, challenge1.GetNumberOfIncreasedDepths());
    }
}

