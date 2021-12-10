namespace AdventOfCode2021.Day04
{
    using System;
    using System.Collections.Generic;

    public class BingoCard
    {
        public List<List<int>> NumbersByColumn { get; set; }
        public List<List<int>> NumbersByRow { get; set; }

        public int Round { get; set; } = 0;

        private List<int> Draws { get; set; }

        public BingoCard(IEnumerable<string> cardStrings)
        {
            NumbersByRow = LoadNumbersByRow(cardStrings); 
            NumbersByColumn = LoadNumbersByColumn(NumbersByRow);

            Draws = new List<int>();
        }

        private static List<List<int>> LoadNumbersByColumn(List<List<int>> numbersByRow)
        {
            var numbersByColumn = new List<List<int>>();

            for (var i = 0; i < 5; i++)
            {
                numbersByColumn.Add(numbersByRow.Select(x => x.ElementAt(i)).ToList());
            }

            return numbersByColumn;
        }

        public int GetSumOfNotFoundNumbers()
        {
            var unFoundNumbers = NumbersByColumn.SelectMany(x => x).Where(x => !Draws.Contains(x));

            return unFoundNumbers.Sum();
        }

        public int GetResult()
        {
            return GetSumOfNotFoundNumbers() * Draws.Last();
        }

        private static List<List<int>> LoadNumbersByRow(IEnumerable<string> cardStrings)
        {
            return cardStrings.Select(x => x.Replace("  "," ").Split(' ').Select(x => int.Parse(x)).ToList()).ToList();
        }

        public void AddDraw(int draw)
        {
            Round++;
            Draws.Add(draw);
        }

        public bool IsGameWinning()
        {
            var isColumnWinning = NumbersByColumn.Select(x => Draws.Intersect(x).Count()).ToList();
            var isRowWinning = NumbersByRow.Select(x => Draws.Intersect(x).Count()).ToList();

            return isColumnWinning.Any(x => x == 5) || isRowWinning.Any(x => x == 5);
        }
    }
}