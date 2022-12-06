// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Reflection;

// A / X = ROCK
// B / Y = PAPER
// C / Z = SCISSORS

int win = 6;
int loss = 0;
int draw = 3;

int rock = 1;
int paper = 2;
int scissors = 3;

var conditions = new List<Condition>()
{
    new Condition(new string[] { "A", "X" }, draw + rock, loss + scissors),
    new Condition(new string[] { "B", "Y" }, draw + paper, draw + paper),
    new Condition(new string[] { "C", "Z" }, draw + scissors, win + rock),
    new Condition(new string[] { "A", "Y" }, win + paper, draw + rock),
    new Condition(new string[] { "B", "Z" }, win + scissors, win + scissors),
    new Condition(new string[] { "C", "X" }, win + rock, loss + paper),
    new Condition(new string[] { "A", "Z" }, loss + scissors, win + paper),
    new Condition(new string[] { "B", "X" }, loss + rock, loss + rock),
    new Condition(new string[] { "C", "Y" }, loss + paper, draw + scissors),
};
int scorePartOne = 0;
int scorePartTwo = 0;
foreach (string line in System.IO.File.ReadLines(@"..\..\..\input.txt"))
{
    var split = line.Split();
    var condition = conditions.Single(x => x.Game.SequenceEqual(split));
    scorePartOne += condition.Points;
    scorePartTwo += condition.PointsPartTwo;
}
System.Console.WriteLine(scorePartOne);
System.Console.WriteLine(scorePartTwo);
record Condition(string[] Game, int Points, int PointsPartTwo);