namespace AdventOfCode2021.Day03;

using System;

public class Challenge
{
    public List<string> DiagnosticReports { get; set; }

    public Challenge(string inputFile)
    {
        DiagnosticReports = LoadInputs(inputFile).ToList();
    }

    private static IEnumerable<string> LoadInputs(string inputFile)
    {
        return ReadFromFile(inputFile);
    }

    private static IEnumerable<string> ReadFromFile(string inputFile)
    {
        return File.ReadAllLines(inputFile);
    }

    public static IEnumerable<IEnumerable<char>> GetBitsGroupedByPosition(List<string> diagnosticReports)
    {
        var bitsMatrix = new List<char>[diagnosticReports.First().Length];

        for (var i = 0; i < bitsMatrix.Length; i++)
        {
            bitsMatrix[i] = new List<char>();
        }

        foreach (var diagnosticReport in diagnosticReports)
        {
            var diagnosticReportArray = diagnosticReport.ToArray();

            for (var i = 0; i < diagnosticReport.Length; i++)
            {
                bitsMatrix[i].Add(diagnosticReportArray[i]);
            }
        }

        return bitsMatrix.ToList();
    }

    public int GetGammaRate()
    {
        var bitsGroupedByPosition = GetBitsGroupedByPosition(DiagnosticReports);
        var mostCommonBits = GetMostCommonBits(bitsGroupedByPosition);
        return Convert.ToInt32(mostCommonBits, 2);
    }

    public int GetOxygenRating()
    {
        var oxygenDiagnosticReports = DiagnosticReports;

        for (var i = 0; i < DiagnosticReports.First().Length; i++)
        {
            var bitsGroupedByPosition = GetBitsGroupedByPosition(oxygenDiagnosticReports);
            var mostCommonBits = GetMostCommonBits(bitsGroupedByPosition);

            var mostCommonBit = mostCommonBits[i];
            oxygenDiagnosticReports = oxygenDiagnosticReports.Where(x => x[i] == mostCommonBit).ToList();

            if (oxygenDiagnosticReports.Count == 1)
            {
                break;
            }
        }

        return Convert.ToInt32(oxygenDiagnosticReports.First(), 2);
    }

    public int GetLifeSupportRating()
    {
        return GetOxygenRating() * GetCO2ScrubberRating();
    }

    public int GetCO2ScrubberRating()
    {
        var oxygenDiagnosticReports = DiagnosticReports;

        for (var i = 0; i < DiagnosticReports.First().Length; i++)
        {
            var bitsGroupedByPosition = GetBitsGroupedByPosition(oxygenDiagnosticReports);
            var leastCommonBits = GetLeastCommonBits(bitsGroupedByPosition);

            var leastCommonBit = leastCommonBits[i];
            oxygenDiagnosticReports = oxygenDiagnosticReports.Where(x => x[i] == leastCommonBit).ToList();

            if (oxygenDiagnosticReports.Count == 1)
            {
                break;
            }
        }

        return Convert.ToInt32(oxygenDiagnosticReports.First(), 2);
    }

    public int GetEpsilonRate()
    {
        var bitsGroupedByPosition = GetBitsGroupedByPosition(DiagnosticReports);
        var leastCommonBits = GetLeastCommonBits(bitsGroupedByPosition);
        return Convert.ToInt32(leastCommonBits, 2);
    }

    private static string GetLeastCommonBits(IEnumerable<IEnumerable<char>> bitsGroupedByPosition)
    {
        var mostCommonBits = new List<string>();

        foreach (var bits in bitsGroupedByPosition)
        {
            mostCommonBits.Add(GetLeastCommonBit(bits));
        }

        return string.Join("", mostCommonBits);
    }

    public static string GetMostCommonBits(IEnumerable<IEnumerable<char>> bitsGroupedByPosition)
    {
        var mostCommonBits = new List<string>();

        foreach (var bits in bitsGroupedByPosition)
        {
            mostCommonBits.Add(GetMostCommonBit(bits));
        }

        return string.Join("", mostCommonBits);
    }

    public static string GetMostCommonBit(IEnumerable<char> bits)
    {
        return bits.Where(x => x == '0').Count() > bits.Where(x => x == '1').Count() ? "0" : "1";
    }

    public static string GetLeastCommonBit(IEnumerable<char> bits)
    {
        return bits.Where(x => x == '0').Count() <= bits.Where(x => x == '1').Count() ? "0" : "1";
    }

    public int GetPowerConsumption()
    {
        return GetEpsilonRate() * GetGammaRate();
    }
}
