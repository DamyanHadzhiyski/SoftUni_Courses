//read the input list of numbers
List<int> numbers = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToList();

//define function to be performed
Func<List<int>, string, List<int>> calculate = (list, command) =>
{
	List<int> result = new List<int>();

	for (int i = 0; i < list.Count; i++)
	{
		switch (command)
		{
			case "add":
				result.Add(list[i] + 1);
				break;
			case "multiply":
				result.Add(list[i] * 2);
				break;
			case "subtract":
				result.Add(list[i] - 1);
				break;
		}
	}

	return result;
};

//create parameter to hold the input
string command = string.Empty;

//run the program until the command is different from "end"
while ((command = Console.ReadLine()) != "end")
{
	if (command == "print")
	{
		Console.WriteLine(string.Join(" ", numbers));
	}
	else
	{
		numbers = calculate(numbers, command);
	}
}