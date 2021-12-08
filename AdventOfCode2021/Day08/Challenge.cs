namespace AdventOfCode2021.Day08;

using System;

public class Challenge
{
    public List<Decoder> Decoders { get; set; }

    public Challenge(string inputFile)
    {
        Decoders = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static IEnumerable<Decoder> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).Select(x => new Decoder(x.Split('|').First().Trim().Split(' ').ToList(), x.Split('|').Last().Trim().Split(' ').ToList()));
    }

    public List<string> GetDecodedSignals()
    {
        return Decoders.SelectMany(x => x.GetDecodedSignals()).ToList();
    }

    public int GetTotalOutputValue()
    {
        return Decoders.Sum(x => x.GetOutputValue());
    }
}
