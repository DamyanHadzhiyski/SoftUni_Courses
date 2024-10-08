//read the end of the range value
int endRange = int.Parse(Console.ReadLine());

//fill a array with the elements for the list
int[] rangeElements = Enumerable.Range(1, endRange).ToArray();

//read the dividers
HashSet<int> dividers = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToHashSet();

//create a predicate for the filter condition
Predicate<int> filter = n =>
{
	foreach (var item in dividers)
	{
		if (n % item != 0)
		{
			return false;
		}
	}

	return true;
};

//creat a function that creetes a list with all matching elements
Func<int[], Predicate<int>, List<int>> function = (elements, match) =>
{
	List<int> numbers = new();

	foreach (var item in elements)
	{
		if (match(item))
		{
			numbers.Add(item);
		}
	}

	return numbers;
};

//create a list that will keep all mathicn elements
List<int> result = new();

result = function(rangeElements, filter);

Console.WriteLine(string.Join(" ", result));