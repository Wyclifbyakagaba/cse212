Console.WriteLine("\n======================\nSorting\n======================");
Sorting.Run();

Console.WriteLine("\n======================\nStandardDeviation\n======================");
StandardDeviation.Run();

Console.WriteLine("\n======================\nSearch\n======================");
Search.Run();

// ===== MY OWN TEST (optional) =============
List<int> data = new List<int> { 1, 2, 3, 4, 5 };

Arrays.RotateListRight(data, 2);

Console.WriteLine("\nRotate Test:");
Console.WriteLine(string.Join(", ", data));
