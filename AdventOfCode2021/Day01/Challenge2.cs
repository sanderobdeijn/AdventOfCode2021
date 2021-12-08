namespace AdventOfCode2021.Day01;

public class Challenge2
{
    public List<int> Depths { get; set; }

    public Challenge2(string inputFile)
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

        for (int i = 0; i < Depths.Count-3; i++)
        {
            var comparisonA = Depths.GetRange(i, 3).Sum();
            var comparisonB = Depths.GetRange(i+1, 3).Sum();

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
