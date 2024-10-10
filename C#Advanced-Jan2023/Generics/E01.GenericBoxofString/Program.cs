using E01.GenericBoxofString;

//read the number of boxes
int boxes = int.Parse(Console.ReadLine());

for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    string value = Console.ReadLine();

    Box<string> newBox = new Box<string>(value);

    Console.WriteLine(newBox.ToString());
}