namespace AdventOfCode2021.Day17;

public class Challenge
{
    public ((int X, int Y) Start, (int X, int Y) End) Target { get; set; }

    public Challenge(string inputFile)
    {
        Target = LoadInputs(inputFile);
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static ((int X, int Y) Start, (int X, int Y) End) LoadInputs(string inputFile)
    {
        var values = ReadFromFile(inputFile).First()[15..].Split(", y=").Select(x => x.Split("..").Select(y => int.Parse(y)));

        return ((values.First().First(), values.Last().First()), (values.First().Last(), values.Last().Last()));
    }

    public long SolvePart1()
    {
        var minXVelocity = 1;
        var maxXVelocity = Target.End.X;
        var minYVelocity = 1;
        var maxYVelocity = 250;

        var highestPoint = 0;

        foreach (var y in Enumerable.Range(minYVelocity, maxYVelocity))
        {
            foreach (var x in Enumerable.Range(minXVelocity, maxXVelocity))
            {
                (int X, int Y) position = (0, 0);
                (int X, int Y) velocity = (x, y);
                var maxY = 0;

                do
                {
                    position = (position.X + velocity.X, position.Y + velocity.Y);

                    maxY = Math.Max(maxY, position.Y);

                    if (Target.Start.X <= position.X && position.X <= Target.End.X && Target.Start.Y <= position.Y && position.Y <= Target.End.Y)
                    {
                        highestPoint = Math.Max(highestPoint, maxY);
                        break;
                    }

                    velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                } while (position.X <= Target.End.X && position.Y >= Target.Start.Y);
            }
        }

        return highestPoint;
    }

    public long SolvePart2()
    {
        var minXVelocity = 1;
        var maxXVelocity = Target.End.X;
        var minYVelocity = -1000;
        var maxYVelocity = 1000;

        var succesfulLaunches = 0;

        foreach (var y in Enumerable.Range(minYVelocity, maxYVelocity * 2))
        {
            foreach (var x in Enumerable.Range(minXVelocity, maxXVelocity * 2))
            {
                (int X, int Y) position = (0, 0);
                (int X, int Y) velocity = (x, y);
                var maxY = 0;

                do
                {
                    position = (position.X + velocity.X, position.Y + velocity.Y);

                    maxY = Math.Max(maxY, position.Y);

                    if (Target.Start.X <= position.X && position.X <= Target.End.X && Target.Start.Y <= position.Y && position.Y <= Target.End.Y)
                    {
                        succesfulLaunches++;
                        break;
                    }

                    velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                } while (position.X <= Target.End.X && position.Y >= Target.Start.Y);
            }
        }

        return succesfulLaunches;
    }
}
