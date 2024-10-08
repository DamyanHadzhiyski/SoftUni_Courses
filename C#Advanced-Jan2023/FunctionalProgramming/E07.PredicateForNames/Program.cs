//name lenght to be filtered
int lenght = int.Parse(Console.ReadLine());

//read the list with the names
string[] names = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries);

//create a predicate that filters the names
Predicate<string> match = s => s.Length <= lenght;

//create a functon that filter the names and create a list with the remaining names
Func<string[], Predicate<string>, List<string>> filter = (name, match) =>
{
	List<string> filteredNames = new List<string>();

	for (int i = 0; i < name.Length; i++)
	{
		if (match(name[i]))
		{
			filteredNames.Add(name[i]);
		}
	}

	return filteredNames;
};

List<string> remainingNames = new List<string>();

remainingNames = filter(names, match);

Console.WriteLine(string.Join(Environment.NewLine, remainingNames));