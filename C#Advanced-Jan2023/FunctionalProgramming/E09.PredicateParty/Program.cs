//get the list with all people that are comming
using System.Data;
using System.Diagnostics;
using System.Globalization;

List<string> guests = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.ToList();

//start reading the input commands
string input = string.Empty;

while ((input = Console.ReadLine()) != "Party!")
{
	string[] splitCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

	string command = splitCommand[0];
	string criteria = splitCommand[1];
	string filter = splitCommand[2];

	if (command == "Remove")
	{
		guests.RemoveAll(Match(criteria, filter));
	}
	else if (command == "Double")
	{
		List<string> matchingNames = guests.FindAll(Match(criteria, filter));

		for (int i = 0; i < matchingNames.Count; i++)
		{
			int index = guests.IndexOf(matchingNames[i]);
			guests.Insert(index, matchingNames[i]);
		}
	}
}

//print the final result
if (guests.Any())
{
	Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
}
else
{
	Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> Match(string criteria, string filter)
{
	switch (criteria)
	{
		case "StartsWith":
			return s => s.StartsWith(filter);
		case "EndsWith":
			return s => s.EndsWith(filter);
		case "Length":
			return s => s.Length == int.Parse(filter);
		default:
			return default;
	}
}