namespace AdventOfCode2021.Day10;

using System;

public class Challenge
{
    public List<NavigationLine> NavigationLines { get; set; }

    public Challenge(string inputFile)
    {
        NavigationLines = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static List<NavigationLine> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).Select(x=> new NavigationLine(x)).ToList();
    }

    public int CalculateErrorScore()
    {
        return NavigationLines.Select(x => x.DeterimineStatus().IllegalValue).Sum();
    }

    public List<long> CalculateCompletionScores()
    {
        return NavigationLines.Where(x => x.DeterimineStatus().status == Status.Incomplete).Select(x => x.CalculateCompletionScore()).ToList();
    }

    public long CalculateCompletionScore()
    {
        var orderedscores = CalculateCompletionScores().OrderBy(x => x);

        return orderedscores.ElementAt(orderedscores.Count() / 2);

    }
}
