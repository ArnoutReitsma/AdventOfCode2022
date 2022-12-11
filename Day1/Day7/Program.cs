// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day7!");

var totalDirSizes = 0;
var dir = new LinkedList<Directory>();
var currentDir = dir.AddFirst(new Directory("/", new List<File>()));

foreach (string line in System.IO.File.ReadLines(@"..\..\..\input.txt"))
{
    if(line == "$ ls")
    {
        continue;
    }
    switch (line)
    {
        case "$ cd ..":
            currentDir = dir.Find(currentDir.Value).Previous;
            continue;
        case "$ cd /":
            currentDir = dir.First;
            continue;
        case var path when path.StartsWith("$ cd "):
            var dirName = line.Split()[2];
            var findDir = FindDirectory(dirName);
            if (findDir != null)
            {
                currentDir = dir.Find(findDir);
            } else
            {
                currentDir = dir.AddAfter(currentDir, new Directory(dirName, new List<File>()));
            }
            continue;
    }
    var lineSplit = line.Split();
    if (int.TryParse(lineSplit[0], out int size))
    {
        var tmp = currentDir.Value;
        tmp.Files.Add(new File(lineSplit[1], size));
        dir.Find(currentDir.Value).Value = tmp;
    }
}
Directory FindDirectory(string Name)
{
    var dirEnumerator = dir.GetEnumerator();
    while (dirEnumerator.MoveNext())
    {
        if (dirEnumerator.Current.Name == Name)
        {
            return dirEnumerator.Current;
        }
    }
    return null;
}
int SumDir()
{
    var sum = 0;
    var dirEnumerator = dir.GetEnumerator();
    while (dirEnumerator.MoveNext())
    {
        var sumFiles = dirEnumerator.Current.Files.Select(x => x.Size).Sum();
        if(sumFiles <= 100000)
        {
            sum += sumFiles;
        }
    }
    return sum;
}
totalDirSizes = SumDir();
Console.WriteLine($"Total dir size: {totalDirSizes}");
record Directory(string Name, List<File> Files);
record File(string Name, int Size);

