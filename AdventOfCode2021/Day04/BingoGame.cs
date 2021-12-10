namespace AdventOfCode2021.Day04;

using System;

public class BingoGame
{
    public List<int> Draws { get; set; }

    public List<BingoCard> Cards { get; set; }

    public BingoGame(string drawsFile, string cardsFile)
    {
        Draws = LoadDraws(drawsFile);
        Cards = LoadCards(cardsFile);
    }

    private static List<BingoCard> LoadCards(string cardsFile)
    {
        return SplitCardStrings(ReadFromFile(cardsFile)).Select(x => new BingoCard(x)).ToList();
    }

    private static IEnumerable<IEnumerable<string>> SplitCardStrings(IEnumerable<string> cardStrings)
    {
        return cardStrings.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()).Chunk(5);
    }

    private static List<int> LoadDraws(string inputFile)
    {
        return ReadFromFile(inputFile).First().Split(",").Select(x => int.Parse(x)).ToList();
    }

    public BingoCard GetLastWinCard()
    {
        var cardsToCalculate = Cards;

        for (var i = 0; i < Draws.Count; i++)
        {
            AddDrawToCards(Draws.ElementAt(i));
            var winningGames = Cards.Where(x => x.IsGameWinning()).ToList();

            if (cardsToCalculate.Count == 1 && cardsToCalculate.First().IsGameWinning())
            {
                return cardsToCalculate.First();
            }

            if (cardsToCalculate.Count > 1 && winningGames.Count > 0)
            {
                for (var y = 0; y < winningGames.Count; y++)
                {
                    cardsToCalculate.Remove(winningGames.ElementAt(y));
                }
            }
        }

        throw new InvalidOperationException("No winner");
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public BingoCard GetFirstWinCard()
    {
        var cardsToCalculate = Cards;

        for (var i = 0; i < Draws.Count; i++)
        {
            AddDrawToCards(Draws.ElementAt(i));
            var winningGame = cardsToCalculate.Where(x => x.IsGameWinning());

            if (winningGame.Count() == 1)
            {
                return winningGame.First();
            }

            if(winningGame.Count() > 1)
            {
                throw new InvalidOperationException("Dual winner");
            }

        }

        throw new InvalidOperationException("No winner");
    }

    private void AddDrawToCards(int draw)
    {
        foreach (var card in Cards)
        {
            card.AddDraw(draw);
        }
    }
}