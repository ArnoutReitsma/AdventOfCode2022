// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Security;

Console.WriteLine("Hello, Day5!");

var inputText = System.IO.File.ReadAllText(@"..\..\..\input.txt");
var lineList = inputText.Split('\n').SkipLast(1).ToList();

var field = new string[9].ToList();
var index = 0;
for (int j = 1; j < 35; j += 4)
{
    for (int i = 7; i >= 0; i--)
    {
        var current = lineList[i][j];
        if (current != (char)32)
        {
            field[index] = field[index] += current;
        };
    }
    index++;
}

for (int i = 10; i < lineList.Count(); i++)
{
    var split = lineList[i].Split(' ');
    var moveAmount = int.Parse(split[1]);
    var takeAt = int.Parse(split[3])-1;
    var moveTo = int.Parse(split[5])-1;
    //var toMove = field[takeAt].Substring(field[takeAt].Length - moveAmount, moveAmount).Reverse();
    var toMove = field[takeAt].Substring(field[takeAt].Length - moveAmount, moveAmount);
    field[takeAt] = field[takeAt].Substring(0, field[takeAt].Length - moveAmount);
    field[moveTo] = field[moveTo] += new string(toMove.ToArray());
}
var highestOnStacks = "";
field.ForEach(l => highestOnStacks += l.TakeLast(1).First());

Console.WriteLine($"Highest on every stack: {highestOnStacks}");
