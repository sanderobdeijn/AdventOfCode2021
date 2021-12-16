namespace AdventOfCode2021.Day14;

using System;
using System.Collections.Generic;

public class Inserter
{
    public Inserter(Dictionary<(char, char), long> polymerPairsWithCount)
    {
        PolymerPairsWithCount = polymerPairsWithCount;
    }

    public Dictionary<(char, char), long> PolymerPairsWithCount { get; }

    public Inserter NextStep(Dictionary<(char, char), char> polymerPairsMap)
    {
        var newPolymerPairsWithCount = polymerPairsMap.ToDictionary(x => x.Key, x => (long)0);

        foreach (var PolymerPairWithCount in PolymerPairsWithCount)
        {
            var intermediate = polymerPairsMap[PolymerPairWithCount.Key];

            newPolymerPairsWithCount[(PolymerPairWithCount.Key.Item1, intermediate)] += PolymerPairWithCount.Value;
            newPolymerPairsWithCount[(intermediate, PolymerPairWithCount.Key.Item2)] += PolymerPairWithCount.Value;
        }

        return new Inserter(newPolymerPairsWithCount);
    }
}
