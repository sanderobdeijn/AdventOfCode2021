namespace AdventOfCode2021.Day06;

using System.Numerics;

public class Day
{
    public List<LanternfishColony> LanternfishColonies { get; init; }

    public BigInteger LanternfishCount => LanternfishColonies.Select(x => x.Count).Aggregate(BigInteger.Add);

    public Day(IEnumerable<int> startingDayValues)
    {
        LanternfishColonies = ParseToLanternfishColonies(startingDayValues).ToList();
    }

    public Day(IEnumerable<LanternfishColony> newColonies)
    {
        this.LanternfishColonies = newColonies.ToList();
    }

    private static IEnumerable<LanternfishColony> ParseToLanternfishColonies(IEnumerable<int> startingDay)
    {
        return startingDay.GroupBy(x => x).Select(x => new LanternfishColony(x.Key, (long)x.Count()));
    }

    public Day NextDay()
    {
        var groupedNewColonies = LanternfishColonies.SelectMany(x => x.NextDay()).GroupBy(x => x.DaysUntilReproduction);

        var mergedColonies = groupedNewColonies.Where(x => x.Count() > 1).Select(x => new LanternfishColony(x.Key, x.Select(x => x.Count).Aggregate(BigInteger.Add)));

        var newColonies = groupedNewColonies.Where(x => x.Count() == 1).Select(x => x.First()).Concat(mergedColonies);

        return new Day(newColonies);
    }
}
