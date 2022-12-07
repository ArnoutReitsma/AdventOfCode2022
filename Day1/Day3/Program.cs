// See https://aka.ms/new-console-template for more information
using System.Linq;

Console.WriteLine("Hello, Day3!");

var lineNumb = 0;
var sumPriority = 0;
var sumPriority2 = 0;
List<string> threePack = new List<string>();
foreach (string line in System.IO.File.ReadLines(@"..\..\..\input.txt"))
{
    // Part 1
    var middle = line.Length / 2;
    var firstRucksack = line.Take(middle);
    var secondRucksack = line.TakeLast(middle);

    var matchingItems = firstRucksack.ToList().Intersect(secondRucksack.ToList());
    matchingItems.ToList().ForEach(mi => sumPriority += CharToPriority(mi));

    // Part 2
    threePack.Add(line);
    lineNumb++;
    if (lineNumb % 3 == 0)
    {
        var matchingItems2 = threePack.Select(s => s.ToList()).Aggregate<IEnumerable<char>>(
       (previousList, nextList) => previousList.Intersect(nextList)
       ).ToList();
        matchingItems2.ToList().ForEach(mi => sumPriority2+= CharToPriority(mi));
        threePack = new List<string>();
        continue;

    }
}

Console.WriteLine($"Sum Priority: {sumPriority.ToString()}");
Console.WriteLine($"Sum Priority2: {sumPriority2.ToString()}");
int CharToPriority(char c)
{
    if (char.IsLower(c))
    {
        return (int)c - 96;
    }
    else
    {
        return (int)c - 38;
    }
}