namespace AdventOfCode2021.Day16;

using System;

public class Challenge
{
    public string Hexadecimal { get; set; }

    public Packet Packet { get; }


    public Challenge(string inputFile)
    {
        Hexadecimal = LoadInputs(inputFile);
        Packet = new Packet(ConvertToBinary(Hexadecimal));
    }

    public static string ConvertToBinary(string hexadecimal)
    {
        return string.Join(string.Empty, hexadecimal.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static string LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).First();
    }



    public int SolvePart1()
    {

        throw new NotImplementedException();
    }

    //public int SolvePart2()
    //{
    //    var graph = LoadDijkstraGraph(RiskLevels, 5);

    //    var result = graph.Dijkstra(1, (uint)RiskLevels.Length * 5);

    //    return result.Distance;
    //}


}
