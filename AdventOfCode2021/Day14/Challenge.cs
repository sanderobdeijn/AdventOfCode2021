namespace AdventOfCode2021.Day14;

using System;

public class Challenge
{
    public Inserter Inserter { get; }
    public Dictionary<(char, char), char> PolymerPairs { get; }
    public string Template { get; }

    public Challenge(string inputFile)
    {
        var (inserter, polymerPairs, template) = LoadInputs(inputFile);

        Inserter = inserter;
        PolymerPairs = polymerPairs;
        Template = template;
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static (Inserter inserter, Dictionary<(char, char), char> polymerPairs, string template) LoadInputs(string inputFile)
    {
        var input = ReadFromFile(inputFile).ToList();

        var polymerPairsMap = input.Where(x => x.Contains('-')).Select(x => x.Split(" -> ")).Select(y => ((y[0].First(), y[0].Last()), y[1].First())).ToDictionary(t => t.Item1, t => t.Item2); ;

        return (new Inserter(GetPolymerPairsToExpand(polymerPairsMap.Select(x => x.Key).ToList(), input.First().Select(x => x).ToList())), polymerPairsMap, input.First());
    }

    private static Dictionary<(char, char), long> GetPolymerPairsToExpand(List<(char, char)> polymerPairs, List<char> template)
    {
        var polymerPairsCounter = polymerPairs.ToDictionary(x => x, x => (long)0);

        for (var i = 0; i < template.Count -1; i++)
        {
            var key = (template.ElementAt(i), template.ElementAt(i + 1));

            polymerPairsCounter[key]++;
        }

        return polymerPairsCounter;
    }

    public long SolvePart1()
    {
        var polymerPairsWithCount = GetSteps(10, PolymerPairs).PolymerPairsWithCount;
        var charCount = GetCharCount(polymerPairsWithCount);

        return charCount.Max(x => x.Value) - charCount.Min(x => x.Value);
    }

    public long SolvePart2()
    {
        var polymerPairsWithCount = GetSteps(40, PolymerPairs).PolymerPairsWithCount;
        var charCount = GetCharCount(polymerPairsWithCount);

        return charCount.Max(x => x.Value) - charCount.Min(x => x.Value);
    }

    public Inserter GetSteps(int steps, Dictionary<(char, char), char> polymerPairs)
    {
        var inserter = Inserter;

        for (var i = 0; i < steps; i++)
        {
            inserter = inserter.NextStep(polymerPairs);
        }

        return inserter;
    }

    public Dictionary<char, long> GetCharCount(Dictionary<(char, char), long> PolymerPairsWithCount)
    {
        var charCounts = PolymerPairsWithCount.GroupBy(x => x.Key.Item1).Select(x => (x.Key, x.Sum(y=> y.Value))).ToDictionary(x=> x.Key,x=>x.Item2);

        charCounts[Template.Last()]++;
        return charCounts;
    }
}
