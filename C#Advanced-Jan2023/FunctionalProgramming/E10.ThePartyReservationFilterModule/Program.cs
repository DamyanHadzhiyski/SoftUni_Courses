//read the list with the invitaions
List<string> invitations = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.ToList();

//creat a list that holds all the filters and values
Dictionary<string, Predicate<string>> filters = new();

//read the input commands
string input = string.Empty;

while ((input = Console.ReadLine()) != "Print")
{
	string[] splitCommand = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

	string command = splitCommand[0];
	string filter = splitCommand[1];
	string value = splitCommand[2];

	switch (command)
	{
		case "Add filter":
			filters.Add(filter + value, GetPredicate(filter, value));
			break;
		case "Remove filter":
			filters.Remove(filter + value);
			break;
	}
}

//execute the filtering
foreach (var filter in filters)
{
	invitations.RemoveAll(filter.Value);
}

Console.WriteLine(string.Join(" ", invitations));

Predicate<string> GetPredicate(string filter, string value)
{
	switch (filter)
	{
		case "Starts with":
			return s => s.StartsWith(value);
		case "Ends with":
			return s => s.EndsWith(value);
		case "Length":
			return s => s.Length == int.Parse(value);
		case "Contains":
			return s => s.Contains(value);
		default:
			return default;
	}
}


