namespace AdventOfCode2021.Day02;

using System;

public class Challenge
{
    public List<MovementCommand> Movements { get; set; }

    public Challenge(string inputFile)
    {
        Movements = LoadInputs(inputFile);
    }

    private static List<MovementCommand> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).Select(x => MovementCommand.FromString(x)).ToList();
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public int GetTotalDistanceForDirection(MovementDirection movementDirection)
    {
        return Movements.Where(x => x.Direction == movementDirection).Sum(x => x.Distance);
    }

    public int GetDepthWithAimCalculation()
    {
        var depth = 0;
        var aim = 0;

        foreach (var movement in Movements)
        {
            _ = movement.Direction switch
            {
                MovementDirection.Forward => depth += CalculateDepthMutation(movement.Distance, aim),
                MovementDirection.Down => aim += movement.Distance,
                MovementDirection.Up => aim -= movement.Distance,
                _ => throw new InvalidOperationException()
            };
        }

        return depth;
    }

    public static int CalculateDepthMutation(int distance, int aim)
    {
        return distance * aim;
    }
}
