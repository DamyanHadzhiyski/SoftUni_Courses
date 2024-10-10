using E03.Stack;

//read the commands
string input = string.Empty;

CustomStack<string> stack = new();

while ((input = Console.ReadLine()) != "END")
{
    List<string> inArray = input
        .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
        .ToList();

    if (inArray[0] == "Pop")
    {
        stack.Pop();
    }
    else
    {
        inArray.RemoveAt(0);
        stack.Push(inArray);
    }
}


foreach (var item in stack)
{
    Console.WriteLine(item);
}

foreach (var item in stack)
{
    Console.WriteLine(item);
}