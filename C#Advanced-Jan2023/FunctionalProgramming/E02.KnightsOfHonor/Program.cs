string[] namesArray = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> addAndPrint = PrintText;

foreach (var item in namesArray)
{
	addAndPrint(item);
}

void PrintText(string x)
{
	Console.WriteLine($"Sir {x}");
}