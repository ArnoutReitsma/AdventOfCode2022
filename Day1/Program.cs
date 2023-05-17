// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Reflection;

char[,] games = File.ReadAllText(@"..\..\..\input.txt").Split("\r\n").Select(s => s.Split()).Select(l => new { l[0], l[2] });


// Suspend the screen.  
System.Console.ReadLine();