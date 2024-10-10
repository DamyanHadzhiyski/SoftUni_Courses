using E06.GenericCountMethodDouble;

//read the number of elements
int boxes = int.Parse(Console.ReadLine());

//creat a element of class Box
Box<double> elements = new Box<double>();

//fill the ist
for (int i = 0; i < boxes; i++)
{
    //read the value of the box
    double value = double.Parse(Console.ReadLine());

    elements.Add(value);
}

//read the element to compare
double compareElement = double.Parse(Console.ReadLine());

//compare the elements with the element and print count of the bigger elements
Console.WriteLine(elements.Compare(compareElement));


