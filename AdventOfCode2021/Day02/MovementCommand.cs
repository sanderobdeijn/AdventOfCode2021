namespace AdventOfCode2021.Day02;

using System;

public record MovementCommand
{
    public static MovementCommand FromString(string movementString)
    {
        return new MovementCommand
        {
            Distance = ParseDistance(movementString),
            Direction = ParseDirection(movementString),
        };
    }

    private static int ParseDistance(string movementString)
    {
        var distanceString = GetParts(movementString).ElementAt(1);

        return int.Parse(distanceString);
    }

    private static string[] GetParts(string movementString)
    {
        return movementString.Split(' ');
    }

    private static MovementDirection ParseDirection(string movementString)
    {
        var directionString = GetParts(movementString).ElementAt(0);

        return (MovementDirection) Enum.Parse(typeof(MovementDirection), directionString, true);
    }

    public int Distance { get; init; }

    public MovementDirection Direction { get; init; }
}
