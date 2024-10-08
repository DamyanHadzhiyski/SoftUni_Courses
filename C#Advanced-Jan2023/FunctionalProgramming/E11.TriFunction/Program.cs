//read the minimal required sum of the characters
int requiredSum = int.Parse(Console.ReadLine());

//read the list of all the name
List<string> namesList = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.ToList();

Func<string, int> checkSum = name =>
{
	int sum = 0;

	foreach (char ch in name)
	{
		sum += (int)ch;
	}

	return sum;
};

Func<List<string>, int, Func<string, int>, string> firstName = (names, sum, match) =>
{
	foreach (var name in names)
	{
		if (match(name) >= sum)
		{
			return name;
		}
	}

	return null;
};

Console.WriteLine(firstName(namesList, requiredSum, checkSum));