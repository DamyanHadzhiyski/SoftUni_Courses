//read the innput elements
int[] elements = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

//read the divisor
int divisor = int.Parse(Console.ReadLine());

//create a predicate that will check if the number is devisible
Predicate<int> isNotDivisible = n => n % divisor != 0;

//create a functionthat will remove all divisible numbers
Func<int[], Predicate<int>, List<int>> removeElements = (numbers, divisible) =>
{
	List<int> elements = new List<int>();

	for (int i = 0; i < numbers.Length; i++)
	{
		if (divisible(numbers[i]))
		{
			elements.Add(numbers[i]);
		}
	}

	return elements;
};

//create a fuction that will revers the remainning elements
Func<List<int>, List<int>> reverse = elements =>
{
	List<int> reversed = new List<int>();

	for (int i = elements.Count - 1; i >= 0; i--)
	{
		reversed.Add(elements[i]);
	}

	return reversed;
};

//declare a list that will keep non-divisible numbers
List<int> result = new();

result = removeElements(elements, isNotDivisible);
result = reverse(result);

Console.WriteLine(string.Join(" ", result));