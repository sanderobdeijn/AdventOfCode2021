namespace AdventOfCode2021.Day09;

using System;

public class Challenge
{
    public List<Point> Points { get; set; }

    public Challenge(string inputFile)
    {
        Points = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static List<Point> LoadInputs(string inputFile)
    {
        var values = ReadFromFile(inputFile).Select(x => x.Chunk(1).Select(y => int.Parse(y)).ToList()).ToList();

        var points = new List<Point>();

        for (int y = 0; y < values.Count; y++)
        {
            var row = values.ElementAt(y);
            for (int x = 0; x < row.Count; x++)
            {
                points.Add(new Point(x,y,row[x]));
            }
        }

        return points;
    }

    public int CalculateResultPart2()
    {
        var basins = GetBasins();

        var largest3Basins = basins.Select(x => x.Count).OrderByDescending(x => x).Take(3);

        return largest3Basins.Aggregate((a, b) => a * b);
    }

    public List<List<Point>> GetBasins()
    {
        var basins = GetLowPoints().Select(x => new List<Point>() { x }).ToList();

        var basinNumbers = Points.Where(x => x.Value != 9).ToList();

        for (int y = 0; y < basins.Count; y++)
        {
            var basin = basins.ElementAt(y);
            for (int i = 0; i < basin.Count; i++)
            {
                var adjacentPoints = basinNumbers.Where(x => basin.ElementAt(i).IsAdjacent(x));
                basin.AddRange(adjacentPoints);

                for (int x = 0; x < adjacentPoints.Count(); x++)
                {
                    var adjacentPoint = adjacentPoints.ElementAt(x);
                    basinNumbers.Remove(adjacentPoint);
                }
            }

        }

        return basins.Select(x => x.Distinct().ToList()).ToList();
    }

    public int CalculateResultPart1()
    {
        List<Point> lowPoints = GetLowPoints();

        return lowPoints.Select(x => x.Value + 1).Sum();
    }

    private List<Point> GetLowPoints()
    {
        var lowPoints = new List<Point>();

        foreach (var point in Points)
        {
            var adjacentPoints = Points.Where(x => x.IsAdjacent(point));
            if(point.IsPointLowerThanAdjacentPoints(adjacentPoints))
            {
                lowPoints.Add(point);
            }
        }

        return lowPoints;
    }
}
