//create the elements in the list
using E01.ListyIterator;

List<string> elements = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

elements.RemoveAt(0);

ListyIterator<string> listyElements = new ListyIterator<string>(elements);

string input = string.Empty;

while ((input = Console.ReadLine()) != "END")
{
    switch(input)
    {
        case "Move":
            listyElements.Move();
            break;
        case "HasNext":
            listyElements.HasNext();
            break;
        case "Print":
            listyElements.Print();
            break;
    }
}