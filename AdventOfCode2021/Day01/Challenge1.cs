namespace AdventOfCode2021.Day01;

public class Challenge1
{
    public List<int> Depths { get; set; }

    public Challenge1(string inputFile)
    {
        Depths = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<int> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile).Select(x => int.Parse(x));
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public int GetNumberOfIncreasedDepths()
    {
        var numberOfIncreasedDepths = 0;

        for (var i = 0; i < Depths.Count-1; i++)
        {
            var comparisonA = Depths.ElementAt(i);
            var comparisonB = Depths.ElementAt(i+1);

            if (IsDepthIncreasing(comparisonA, comparisonB))
            {
                numberOfIncreasedDepths++;
            }
        }

        return numberOfIncreasedDepths;
    }

    private static bool IsDepthIncreasing(int comparisonA, int comparisonB)
    {
        return comparisonA < comparisonB;
    }
}
