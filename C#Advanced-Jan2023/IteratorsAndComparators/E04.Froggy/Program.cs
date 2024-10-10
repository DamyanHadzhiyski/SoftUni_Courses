//read the stones allignment
using E04.Froggy;

List<int> input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

//create the lake with the stones
Lake lake = new Lake(input);

Console.WriteLine(string.Join(", ", lake));
