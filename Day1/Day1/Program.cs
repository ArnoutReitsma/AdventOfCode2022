// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Reflection;

List<int> top3MostCalories = new() { 0, 0, 0 };
int calories = 0;

foreach (string line in System.IO.File.ReadLines(@"C:\Users\Arnout Reitsma\source\repos\AdventOfCode2022\Day1\Day1\input.txt"))
{
    if (line == string.Empty)
    {
        for (int i = 0; i < 3; i++)
        {
            if (calories > top3MostCalories[i])
            {
                top3MostCalories.Insert(i, calories);
                top3MostCalories.RemoveAt(3);
                break;
            }
        }

        calories = 0;
        continue;
    }
    calories += int.Parse(line);
}

System.Console.WriteLine("Top 3 MostCalories {0}", top3MostCalories.Sum());
// Suspend the screen.  
System.Console.ReadLine();