namespace AdventOfCode2021.Day06;

using System;

public class Challenge
{
    public Day Start { get; set; }

    public Challenge(string inputFile)
    {
        Start = LoadInputs(inputFile);
    }

    private static Day LoadInputs(string inputFile)
    {
        return new Day(ReadFromFile(inputFile).First().Split(',').Select(x => int.Parse(x)));
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public Day SimulateUntilDay(int maxDays)
    {
        var currentDay = Start;

        for (var i = 0; i < maxDays; i++)
        {
            currentDay = currentDay.NextDay();
        }

        return currentDay;
    }
}
