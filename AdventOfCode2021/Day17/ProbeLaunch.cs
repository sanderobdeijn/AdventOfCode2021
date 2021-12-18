namespace AdventOfCode2021.Day17;


public record ProbeLaunch
{
    public ProbeLaunch(int xVelocity, int yVelocity, ((int X, int Y) Start, (int X, int Y) End) target)
    {
        XVelocity = xVelocity;
        YVelocity = yVelocity;
        Target = target;
        
        (bool ReachedTarget, int MaxHeight) result = GetProbeSteps();

        ReachedTarget = result.ReachedTarget;
        MaxHeight = result.MaxHeight;
    }

    private (bool ReachedTarget, int MaxHeight) GetProbeSteps()
    {
        var xVelocityWithDrag = XVelocity;
        var yVelocityWithGravity = YVelocity;

        var xPosition = 0;
        var yPosition = 0;
        var maxHeight = 0;

        for (; xPosition > Target.End.X || yPosition > Target.End.Y;)
        {
            xPosition += xVelocityWithDrag;
            yPosition += yVelocityWithGravity;
            maxHeight = Math.Max(maxHeight, yPosition);

            if (Target.Start.X <= xPosition && xPosition <= Target.End.X && Target.Start.Y <= yPosition && yPosition <= Target.End.Y)
            {
                return (true, maxHeight);
            }

            if (xVelocityWithDrag > 0)
            {
                xVelocityWithDrag--;
            }

            yVelocityWithGravity--;
        }

        return (false, maxHeight);
    }

    public bool ReachedTarget { get; }

    public int MaxHeight { get; }

    public int XVelocity { get; init; }

    public int YVelocity { get; init; }

    public ((int X, int Y) Start, (int X, int Y) End) Target { get; init; }
}
