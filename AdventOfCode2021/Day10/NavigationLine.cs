namespace AdventOfCode2021.Day10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NavigationLine
{
    public NavigationLine(string line)
    {
        Line = line;
    }

    public string Line { get; }

    public (Status status, int IllegalValue) DeterimineStatus()
    {
        var charsToCheck = new Stack<char>();
        var openingCharacters = new char[] { '(', '[', '{', '<' };
        var closingCharacters = new char[] { ')', ']', '}', '>' };
        var pairs = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' }, { '>', '<' } };
        var illegalValues = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };

        var lineChars = Line.Chunk(1).Select(x=>x.First());
        foreach (var lineChar in lineChars)
        {
            if(openingCharacters.Contains(lineChar))
            {
                charsToCheck.Push(lineChar);
            }
            if (closingCharacters.Contains(lineChar))
            {
                pairs.TryGetValue(lineChar, out var pairChar);

                if(charsToCheck.Peek() == pairChar)
                {
                    charsToCheck.Pop();
                    continue;
                }
                illegalValues.TryGetValue(lineChar, out var illegalValue);

                return (Status.Corrupt, illegalValue);
            }
        }

        if (charsToCheck.Count > 0)
        {
            return (Status.Incomplete,0);
        }
        return (Status.Correct,0);
    }

    internal long CalculateCompletionScore()
    {
        long completionScore = 0;

        var charsToCheck = new Stack<char>();
        var openingCharacters = new char[] { '(', '[', '{', '<' };
        var closingCharacters = new char[] { ')', ']', '}', '>' };
        var pairs = new Dictionary<char, char>() { { ')', '(' }, { ']', '[' }, { '}', '{' }, { '>', '<' } };
        var reversePairs = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
        var completionValues = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

        var lineChars = Line.Chunk(1).Select(x => x.First());
        foreach (var lineChar in lineChars)
        {
            if (openingCharacters.Contains(lineChar))
            {
                charsToCheck.Push(lineChar);
            }
            if (closingCharacters.Contains(lineChar))
            {
                pairs.TryGetValue(lineChar, out var pairChar);

                if (charsToCheck.Peek() == pairChar)
                {
                    charsToCheck.Pop();
                    continue;
                }
            }
        }

        while (charsToCheck.TryPop(out var charToComplete))
        {
            reversePairs.TryGetValue(charToComplete, out var pairChar);

            completionValues.TryGetValue(pairChar, out var completionValue);

            completionScore = (completionScore * 5) + completionValue;
        }

        return completionScore;
    }
}
