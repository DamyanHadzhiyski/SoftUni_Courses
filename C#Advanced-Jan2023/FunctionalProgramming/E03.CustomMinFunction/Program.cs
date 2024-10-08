int[] numbers = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

Func<int[], int> smallest = SmallestMethod;

Console.WriteLine(smallest(numbers));

int SmallestMethod(int[] array)
{
	int smallest = array[0];

	foreach (int i in array)
	{
		if (i < smallest)
		{
			smallest = i;
		}
	}
	return smallest;
}