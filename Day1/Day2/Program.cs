// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Reflection;

List<int> top3MostCalories = new() { 0, 0, 0 };
int calories = 0;

foreach (string line in System.IO.File.ReadLines(@"..\..\..\input.txt"))
{

}

System.Console.WriteLine("Top 3 MostCalories {0}", top3MostCalories.Sum());
// Suspend the screen.  
System.Console.ReadLine();