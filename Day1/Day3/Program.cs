// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day3!");

var sumPriority = 0;
foreach (string line in System.IO.File.ReadLines(@"..\..\..\input.txt"))
{
    var middle = line.Length / 2;
    var firstRucksack = line.Take(middle);
    var secondRucksack = line.TakeLast(middle);

    var matchingItems = firstRucksack.ToList().Intersect(secondRucksack.ToList());
    matchingItems.ToList().ForEach(mi => sumPriority += CharToPriority(mi));
}

Console.WriteLine($"Sum Priority: {sumPriority.ToString()}");
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