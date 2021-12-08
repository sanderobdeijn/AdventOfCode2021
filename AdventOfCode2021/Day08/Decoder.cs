namespace AdventOfCode2021.Day08;

using System;
using System.Collections.Generic;

public class Decoder
{
    public Decoder(List<string> signalPatterns, List<string> inputSignals)
    {
        this.signalPatterns = GetSignalPatterns(signalPatterns);
        this.inputSignals = inputSignals;
    }

    private static Dictionary<string, string> GetSignalPatterns(List<string> inputSignalPatterns)
    {
        var signalPatterns = new Dictionary<string, string>
        {
            { SortString(inputSignalPatterns.First(x => x.Length == 2)), "1" },
            { SortString(inputSignalPatterns.First(x => x.Length == 4)), "4" },
            { SortString(inputSignalPatterns.First(x => x.Length == 3)), "7" },
            { SortString(inputSignalPatterns.First(x => x.Length == 7)), "8" }
        };

        signalPatterns.Add(SortString(Get3Signal(inputSignalPatterns, signalPatterns)), "3");
        signalPatterns.Add(SortString(Get9Signal(inputSignalPatterns, signalPatterns)), "9");
        signalPatterns.Add(SortString(Get0Signal(inputSignalPatterns, signalPatterns)), "0");
        signalPatterns.Add(SortString(Get6Signal(inputSignalPatterns, signalPatterns)), "6");
        signalPatterns.Add(SortString(Get2Signal(inputSignalPatterns, signalPatterns)), "2");
        signalPatterns.Add(SortString(Get5Signal(inputSignalPatterns, signalPatterns)), "5");

        return signalPatterns;
    }

    internal int GetOutputValue()
    {
        var outputString = string.Join(string.Empty, GetDecodedSignals());

        return int.Parse(outputString);
    }

    private static string Get3Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        return inputSignalPatterns.Where(x => x.Length == 5).First(x => IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "1").Key, x));
    }

    private static string Get2Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        string differenceBetween1And4 = GetDifferenceBetween1And4(signalPatterns);

        return inputSignalPatterns.Where(x => x.Length == 5).First(x => !IsSignalContainedInSignal(differenceBetween1And4, x) && !IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "1").Key, x));
    }

    private static string Get5Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        string differenceBetween1And4 = GetDifferenceBetween1And4(signalPatterns);

        return inputSignalPatterns.Where(x => x.Length == 5).First(x => IsSignalContainedInSignal(differenceBetween1And4, x));
    }

    private static string GetDifferenceBetween1And4(Dictionary<string, string> signalPatterns)
    {
        var differenceBetween1And4 = signalPatterns.First(x => x.Value == "4").Key;

        foreach (char c in signalPatterns.First(x => x.Value == "1").Key)
        {
            differenceBetween1And4 = differenceBetween1And4.Replace(c.ToString(), string.Empty);
        }

        return differenceBetween1And4;
    }

    private static string Get6Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        return inputSignalPatterns.Where(x => x.Length == 6).First(x => !IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "1").Key, x));
    }

    private static string Get9Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        return inputSignalPatterns.Where(x => x.Length == 6).First(x => IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "3").Key, x));
    }

    private static string Get0Signal(List<string> inputSignalPatterns, Dictionary<string, string> signalPatterns)
    {
        return inputSignalPatterns.Where(x => x.Length == 6).First(x => IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "1").Key, x) && !IsSignalContainedInSignal(signalPatterns.First(x => x.Value == "9").Key, x));
    }

    private static bool IsSignalContainedInSignal(string key, string input)
    {
        return key.All(c => input.Contains(c));
    }

    private static string SortString(string inputString)
    {
        return String.Concat(inputString.OrderBy(c => c));
    }

    private readonly Dictionary<string, string> signalPatterns;
    private readonly List<string> inputSignals;

    public IEnumerable<string> GetDecodedSignals()
    {
        return inputSignals.Select(x => Decode(x)).Where(x => x != null).Cast<string>();
    }

    private string? Decode(string inputSignal)
    {
        return signalPatterns.TryGetValue(SortString(inputSignal), out var decodedSignal) ? decodedSignal : null;
    }
}

