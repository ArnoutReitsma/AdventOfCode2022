// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day4!");
var containingPairs = 0;
var overlapPairs = 0;

var inputText = System.IO.File.ReadAllText(@"..\..\..\input.txt");

var intList = inputText
    .Split('\n').SkipLast(1)
    .Select(a => a.Split(",")
        .Select(p => p.Split("-")
            .Select(int.Parse).ToArray()).ToArray());

containingPairs = intList.Count(p => IntergerPairsContaining(p[0][0], p[0][1], p[1][0], p[1][1]));
overlapPairs = intList.Count(p => IntergerPairsOverLap(p[0][0], p[0][1], p[1][0], p[1][1]));

Console.WriteLine($"Pairs containing the other: {containingPairs}");
Console.WriteLine($"Pairs overlap the other: {overlapPairs}");

bool IntergerPairsContaining(int a, int b, int y, int z)
{
    return (a <= y && b >= z) || (y <= a && z >= b);
}
bool IntergerPairsOverLap(int a, int b, int y, int z)
{
    return !((b < y) || (z < a));
}