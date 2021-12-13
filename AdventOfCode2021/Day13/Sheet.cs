namespace AdventOfCode2021.Day13;

public class Sheet
{
    public bool[,] Dots { get; }

    public int NumberOfDots => Dots.Where((x,y,value) => value == true).Count();

    public Sheet(IEnumerable<string> dotStrings)
    {
        var dotsInput = dotStrings.Select(x => x.Split(',').Select(y => int.Parse(y)));

        var maxX = dotsInput.Max(x => x.First());
        var maxY = dotsInput.Max(x => x.Last());

        var dots = new bool[maxX + 1, maxY + 1];

        foreach (var dotInput in dotsInput)
        {
            dots[dotInput.First(), dotInput.Last()] = true;
        }

        Dots = dots;
    }

    private Sheet(bool[,] Dots)
    {
        this.Dots = Dots;
    }

    public Sheet FoldVertical(int y)
    {
        var lenghtBeforeFold = y;
        var lenghtAfterFold = Dots.GetColumn(0).Count() - y -1;

        var newHeight = Math.Max(lenghtAfterFold, lenghtBeforeFold);

        var newDots = new bool[Dots.GetRow(0).Count(), newHeight];

        for (var i = 1; i <= newHeight; i++)
        {
            var rowAboveFold = Dots.GetRow(y - i).ToList();
            var rowBelowFold = Dots.GetRow(y + i).ToList();
            var insertionRow = y - i;

            var mergedRow = rowAboveFold.Zip(rowBelowFold).Select(x => x.First || x.Second).ToList();
            for (var x = 0; x < mergedRow.Count; x++)
            {
                newDots[x,insertionRow] = mergedRow.ElementAt(x);
            }
        }

        return new Sheet(newDots);
    }

    public Sheet FoldHorizontal(int x)
    {
        var lenghtBeforeFold = x;
        var lenghtAfterFold = Dots.GetRow(0).Count() - x - 1;

        var newWidth = Math.Max(lenghtAfterFold, lenghtBeforeFold);

        var newDots = new bool[newWidth, Dots.GetColumn(0).Count()];

        for (var i = 1; i <= newWidth; i++)
        {
            var columnBeforeFold = Dots.GetColumn(x - i).ToList();
            var columnAfterFold = Dots.GetColumn(x + i).ToList();
            var insertionColumn = x - i;

            var mergedColumn = columnBeforeFold.Zip(columnAfterFold).Select(x => x.First || x.Second).ToList();
            for (var y = 0; y < mergedColumn.Count; y++)
            {
                newDots[insertionColumn, y] = mergedColumn.ElementAt(y);
            }
        }

        return new Sheet(newDots);
    }
}
