// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Day8!");

var inputText = System.IO.File.ReadAllText(@"..\..\..\input.txt");
int[][] treeField = inputText.Split('\n').SkipLast(1).Select(s => s.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

// PART 1
var visibleTrees = 0;
for (int x = 0; x < treeField.Length; x++)
{
    for (int y = 0; y < treeField[x].Length; y++)
    {
        if (y == 0 || y == treeField.Length - 1 || x == 0 || x == treeField.Length - 1)
        {
            visibleTrees++;
            continue;
        }
        var field = treeField[y][x];

        var isVisible = true;
        // From top
        for (int t = 0; t < y; t++)
        {
            if (field <= treeField[t][x])
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
        {
            visibleTrees++;
            continue;
        }
        isVisible = true;
        // From below
        for (int b = treeField.Length - 1; b > y; b--)
        {
            if (field <= treeField[b][x])
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
        {
            visibleTrees++;
            continue;
        }
        isVisible = true;
        // From left
        for (int l = 0; l < x; l++)
        {
            if (field <= treeField[y][l])
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
        {
            visibleTrees++;
            continue;
        }
        isVisible = true;
        // From right
        for (int r = treeField[y].Length - 1; r > x; r--)
        {
            if (field <= treeField[y][r])
            {
                isVisible = false;
                break;
            }
        }
        if (isVisible)
        {
            visibleTrees++;
            continue;
        }
      
    }
}
Console.WriteLine($"visibleTrees: {visibleTrees}");

// PART 2
var highestScenicScore = 0;
for (int x = 0; x < treeField.Length; x++)
{
    for (int y = 0; y < treeField[x].Length; y++)
    {
        var field = treeField[y][x];

        var up = y;
        var below = treeField.Length - y;
        var left = x;
        var right = treeField[y].Length - x;
        var index = 0;
        // Up
        for (int u = y - 1; u > 0; --u)
        {
            index++;
            if (field <= treeField[u][x])
            {
                up = index;
                break;
            }
        }
        index = 0;
        //  below
        for (int b = y + 1; b < treeField.Length - 1; b--)
        {
            index++;
            if (field <= treeField[b][x])
            {
                below = index;
                break;
            }
        }
        index = 0;
        //  left
        for (int l = x - 1; l > 0; l--)
        {
            index++;
            if (field <= treeField[y][l])
            {
                left = index;
                break;
            }
        }
        index = 0;
        //  right
        for (int r = x + 1; r < treeField[y].Length - 1; r++)
        {
            index++;
            if (field <= treeField[y][r])
            {
                right = index;
                break;
            }
        }
        var scenicScore = up * below * left * right;
        highestScenicScore =   highestScenicScore < scenicScore ? scenicScore : highestScenicScore; 
    }
}
Console.WriteLine($"highestScenicScore: {highestScenicScore}");