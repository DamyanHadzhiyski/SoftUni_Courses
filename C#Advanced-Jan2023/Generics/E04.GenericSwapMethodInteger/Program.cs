using E04.GenericSwapMethodInteger;

//read the number of elements
int boxes = int.Parse(Console.ReadLine());

//creat a element of class Box
Box<int> elements = new Box<int>();

//fill the ist
for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    int value = int.Parse(Console.ReadLine());

    elements.Add(value);
}

//read the indexes to swap
int[] indexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

//swap the elements
elements.Swap(indexes[0], indexes[1]);

//print all elements
elements.PrintAll();

