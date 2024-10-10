using E05.GenericCountMethodString;

//read the number of elements
int boxes = int.Parse(Console.ReadLine());

//creat a element of class Box
Box<string> elements = new Box<string>();

//fill the ist
for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    string value = Console.ReadLine();

    elements.Add(value);
}

//read the element to compare
string compareElement = Console.ReadLine();

//compare the elements with the element and print count of the bigger elements
Console.WriteLine(elements.Compare(compareElement));


