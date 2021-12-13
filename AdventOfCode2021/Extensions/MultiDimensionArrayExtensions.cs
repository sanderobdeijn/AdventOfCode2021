namespace AdventOfCode2021.Extensions;

public static class MultiDimensionArrayExtensions
{
    public static (int, int, bool) First<T>(this T[,] source, Func<T, bool> predicate)
    {
        for (var row = 0; row < source.GetLength(0); row++)
        {
            for (var column = 0; column < source.GetLength(1); column++)
            {
                if (predicate(source[column, row]))
                {
                    return (row, column, true);
                }
            }
        }
        return (-1, -1, false);
    }

    public static bool AnyRow<T>(this T[,] source, Func<IEnumerable<T>, bool> predicate)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Any(row => predicate(source.GetRow(row)));
    }

    public static bool AnyColumn<T>(this T[,] source, Func<IEnumerable<T>, bool> predicate)
    {
        return Enumerable.Range(0, source.GetLength(1))
            .Any(column => predicate(source.GetColumn(column)));
    }

    public static IEnumerable<T> GetColumn<T>(this T[,] source, int column)
    {
        return Enumerable.Range(0, source.GetLength(1))
            .Select(row => source[column, row]);


    }

    public static IEnumerable<T> GetRow<T>(this T[,] source, int row)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(column => source[column, row]);
    }

    public static IEnumerable<T> Where<T>(this T[,] source, Func<int, int, T, bool> predicate)
    {
        for (var row = 0; row < source.GetLength(0); row++)
        {
            for (var column = 0; column < source.GetLength(1); column++)
            {
                if (predicate(row, column, source[row, column]))
                {
                    yield return source[row, column];
                }
            }
        }
    }
}
