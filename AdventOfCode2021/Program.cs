// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using AdventOfCode2021.Day17;

var stopwatch = new Stopwatch();
stopwatch.Start();

var challenge = new Challenge(@"D:\Development\AdventOfCode\AdventOfCode2021\AdventOfCode2021.Tests\Day17\input.txt");

var result = challenge.SolvePart2();
stopwatch.Stop();
Console.WriteLine(result);
Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
