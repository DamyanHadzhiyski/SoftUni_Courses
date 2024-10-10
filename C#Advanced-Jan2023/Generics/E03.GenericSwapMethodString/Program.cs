using E03.GenericSwapMethodString;

//read the number of elements
int boxes = int.Parse(Console.ReadLine());

//creat a element of class Box
Box<string> strings = new Box<string>();

//fill the ist
for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    string value = Console.ReadLine();

    strings.Add(value);
}

//read the indexes to swap
int[] indexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

//swap the elements
strings.Swap(indexes[0], indexes[1]);

//print all elements
strings.PrintAll();

