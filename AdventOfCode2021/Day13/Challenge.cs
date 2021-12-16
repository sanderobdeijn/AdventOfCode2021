namespace AdventOfCode2021.Day13;

using System;
using System.Text;

public class Challenge
{
    public Sheet Sheet { get; }
    public List<string> FoldInstructions { get; }

    public Challenge(string inputFile)
    {
        var input = LoadInputs(inputFile);

        Sheet = input.Sheet;
        FoldInstructions = input.FoldInstructions;
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    private static (Sheet Sheet,List<string> FoldInstructions) LoadInputs(string inputFile)
    {
        var input = ReadFromFile(inputFile).ToList();
        var dotsInput = input.Where(x => x.Contains(','));
        var foldInstructions = input.Where(x => x.Contains('f'));

        return (new Sheet(dotsInput),foldInstructions.ToList());
    }

    public string SolvePart2()
    {
        var foldedSheet = FoldAllInstructions();

        var sb = new StringBuilder();

        for (var i = 0; i < foldedSheet.Dots.GetColumn(0).Count(); i++)
        {
            sb.AppendLine(string.Join(string.Empty, foldedSheet.Dots.GetRow(i).Select(x => x ? "X" : ".")));
        }

        return sb.ToString();
    }

    public int SolvePart1()
    {
        var foldedSheet = FoldSheetAccordingToInstruction(Sheet, FoldInstructions.First());

        return foldedSheet.NumberOfDots;
    }

    private static Sheet FoldSheetAccordingToInstruction(Sheet sheet, string foldingInstruction)
    {
        var direction = foldingInstruction.Split('=').First();
        var position = int.Parse(foldingInstruction.Split('=').Last());

        if(direction.Contains('x'))
        {
            return sheet.FoldHorizontal(position);
        }
        return sheet.FoldVertical(position);
    }

    public Sheet FoldAllInstructions()
    {
        var foldedSheet = Sheet;
        foreach(var foldInstruction in FoldInstructions)
        {
            foldedSheet = FoldSheetAccordingToInstruction(foldedSheet, foldInstruction);
        }

        return foldedSheet;
    }
}
