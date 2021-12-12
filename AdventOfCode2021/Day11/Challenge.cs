namespace AdventOfCode2021.Day11;

using System;

public class Challenge
{
    public Cavern StartCavern { get; set; }

    public Challenge(string inputFile)
    {
        StartCavern = LoadInputs(inputFile);
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static Cavern LoadInputs(string inputFile)
    {
        var values = ReadFromFile(inputFile).Select(x => x.Chunk(1).Select(y => int.Parse(y)).ToList()).ToList();

        var octipi = new List<Octopus>();

        for (var y = 0; y < values.Count; y++)
        {
            var row = values.ElementAt(y);
            for (var x = 0; x < row.Count; x++)
            {
                octipi.Add(new Octopus(x, y, row[x]));
            }
        }

        return new Cavern(octipi);
    }

    public int GetStepWhereAllOctopiAreSynchronized()
    {
        var cavern = StartCavern;

        var previousFlashes = 0;

        var step = 0;

        for (; true; step++)
        {
            cavern.NextStep();

            if(cavern.TotalFlashes - previousFlashes == 100)
            {
                step++;
                break;
            }

            previousFlashes = cavern.TotalFlashes;
        }

        return step;
    }

    public int GetTotalFlashesForSteps(int steps)
    {
        var cavern = StartCavern;

        for (var i = 0; i < steps; i++)
        {
            cavern.NextStep();
        }

        return cavern.TotalFlashes;
    }
}
