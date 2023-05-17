// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day6!");

var inputText = System.IO.File.ReadAllText(@"..\..\..\input.txt");

//var startPacketLength = 4;
var startPacketLength = 14;

for(int i = 0; i < inputText.Length; i++)
{
    if(inputText.Substring(i, startPacketLength).Distinct().Count() == startPacketLength)
    {
        Console.WriteLine($"First start-of-packet at: {i+ startPacketLength}");
        return;
    }
}