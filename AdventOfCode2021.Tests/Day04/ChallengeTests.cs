namespace AdventOfCode2021.Tests.Day04;

using AdventOfCode2021.Day04;

public class ChallengeTests
{
    [Fact]
     public void TestExampleFirstWin()
    {
        var bingoGame = new BingoGame(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\example-draws.txt", @"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\example-cards.txt");

        Assert.NotEmpty(bingoGame.Draws);
        Assert.Equal(27, bingoGame.Draws.Count);

        Assert.NotEmpty(bingoGame.Cards);
        Assert.Equal(3, bingoGame.Cards.Count);

        var firstWinCard = bingoGame.GetFirstWinCard();
        Assert.Equal(12, firstWinCard.Round);
        Assert.Equal(188, firstWinCard.GetSumOfNotFoundNumbers());
        Assert.Equal(4512, firstWinCard.GetResult());
    }

    [Fact]
    public void TestExampleLastWin()
    {
        var bingoGame = new BingoGame(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\example-draws.txt", @"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\example-cards.txt");

        Assert.NotEmpty(bingoGame.Draws);
        Assert.Equal(27, bingoGame.Draws.Count);

        Assert.NotEmpty(bingoGame.Cards);
        Assert.Equal(3, bingoGame.Cards.Count);

        var lastWinCard = bingoGame.GetLastWinCard();
        Assert.Equal(15, lastWinCard.Round);
        Assert.Equal(148, lastWinCard.GetSumOfNotFoundNumbers());
        Assert.Equal(1924, lastWinCard.GetResult());
    }

    [Fact]
    public void TestInput()
    {
        var bingoGame = new BingoGame(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\input-draws.txt", @"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\input-cards.txt");

        Assert.NotEmpty(bingoGame.Draws);
        Assert.Equal(100, bingoGame.Draws.Count);

        Assert.NotEmpty(bingoGame.Cards);
        Assert.Equal(100, bingoGame.Cards.Count);

        var firstWinCard = bingoGame.GetFirstWinCard();
        Assert.Equal(29, firstWinCard.Round);
        Assert.Equal(726, firstWinCard.GetSumOfNotFoundNumbers());
        Assert.Equal(25410, firstWinCard.GetResult());
    }

    [Fact]
    public void TestInputLastWin()
    {
        var bingoGame = new BingoGame(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\input-draws.txt", @"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day04\input-cards.txt");

        Assert.NotEmpty(bingoGame.Draws);
        Assert.Equal(100, bingoGame.Draws.Count);

        Assert.NotEmpty(bingoGame.Cards);
        Assert.Equal(100, bingoGame.Cards.Count);

        var lastWinCard = bingoGame.GetLastWinCard();
        Assert.Equal(83, lastWinCard.Round);
        Assert.Equal(195, lastWinCard.GetSumOfNotFoundNumbers());
        Assert.Equal(2730, lastWinCard.GetResult());
    }
}
