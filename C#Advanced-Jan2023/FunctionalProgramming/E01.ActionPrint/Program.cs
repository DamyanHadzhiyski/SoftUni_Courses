string[] names = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> print = PrintText;

foreach (string name in names)
{
	print(name);
}

void PrintText(string x)
{
	Console.WriteLine(x);
}