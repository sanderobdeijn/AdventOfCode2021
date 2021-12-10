namespace AdventOfCode2021.Day07;

using System;

public class Challenge
{
    public List<Crab> Crabs { get; set; }

    public Range StartingRange => MinPosition..MaxPosition;

    public int MinPosition => Crabs.Min(x => x.Position);
    public int MaxPosition => Crabs.Max(x => x.Position);

    public Challenge(string inputFile)
    {
        Crabs = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<Crab> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).First().Split(',').Select(x => int.Parse(x)).Select(x => new Crab(x)).OrderBy(x => x.Position);
    }

    public int CalculateFuelForMoveToPosition(int newPosition, bool expensiveMode)
    {
        if (expensiveMode)
        {
            return Crabs.Select(x => x.CalculateFuelWithExpensiveModeForPosition(newPosition)).Sum();
        }

        return Crabs.Select(x => x.CalculateFuelForPosition(newPosition)).Sum();
    }

    public int CalculateOptimalPosition(bool expensiveMode)
    {
        var range = StartingRange;
        while (range.Start.Value != range.End.Value)
        {
            range = ReduceRange(range, expensiveMode);
        }

        return range.Start.Value;
    }

    public Range ReduceRange(Range range, bool expensiveMode)
    {
        var measumentPoints = GetMeasurementPoints(range);

        var measurements = measumentPoints.Select(x => (position: x, fuelConsuption: CalculateFuelForMoveToPosition(x, expensiveMode)));

        if(range.End.Value - range.Start.Value <= 5)
        {
            var lowestFuelConsumptionPosition = measurements.OrderBy(x => x.fuelConsuption).First().position;

            return lowestFuelConsumptionPosition..lowestFuelConsumptionPosition;
        }

        var positionsWithLowestFuelConsumption = measurements.OrderBy(x => x.fuelConsuption).Take(3).Select(x => x.position);

        return positionsWithLowestFuelConsumption.Min()..positionsWithLowestFuelConsumption.Max();
    }

    private static IEnumerable<int> GetMeasurementPoints(Range range)
    {
        var measurementPoints = new List<int>();

        var minRange = range.Start.Value;
        var maxRange = range.End.Value;
        var length = maxRange - minRange;

        var measurementInterval = length / 4;
        if( measurementInterval == 0)
        {
            measurementInterval = 1;
        }

        for (var i = 0; true; i++)
        {
            var newMeasurementPoint = minRange + (i * measurementInterval);

            if (newMeasurementPoint >= maxRange)
            {
                measurementPoints.Add(maxRange);
                break;
            }

            measurementPoints.Add(newMeasurementPoint);
        }

        return measurementPoints.Distinct();
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }
}
