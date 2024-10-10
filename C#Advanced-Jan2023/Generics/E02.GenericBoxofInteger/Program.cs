using E02.GenericBoxofInteger;

//read the number of boxes
int boxes = int.Parse(Console.ReadLine());

for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    int value = int.Parse(Console.ReadLine());

    Box<int> newBox = new Box<int>(value);

    Console.WriteLine(newBox.ToString());
}