//read the upper an lower range limits and split it
int[] range = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

int lower = range[0];
int upper = range[1];

//creat a list that will keep the numbers in the range
List<int> numbers = new();

for (int i = lower; i <= upper; i++)
{
	numbers.Add(i);
};

//read the type of numbers (even or odd) to print from the console
string command = Console.ReadLine();

Predicate<int> isEvenOrOdd;

if (command == "odd")
{
	isEvenOrOdd = n => n % 2 != 0;
}
else
{
	isEvenOrOdd = n => n % 2 == 0;
}

foreach (int number in numbers)
{
	if (isEvenOrOdd(number))
	{
		Console.Write($"{number} ");
	}
}
