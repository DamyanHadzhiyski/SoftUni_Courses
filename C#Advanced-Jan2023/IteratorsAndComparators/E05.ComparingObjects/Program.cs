using E05.ComparingObjects;

//creat a list to store all persons
List<Person> personList = new List<Person>();

//start reading the persons
string input = string.Empty;

while ((input = Console.ReadLine()) != "END")
{
    string[] inArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = inArray[0];
    int age = int.Parse(inArray[1]);
    string town = inArray[2];

    //creat a person and add him to the list
    personList.Add(new Person(name, age, town));
}

//get the number of person to compare
int number = int.Parse(Console.ReadLine());

//get the persons info
Person personToCompare = personList.ElementAt(number - 1);

//create a counter for equal and different persons
int equalPersons = 0;
int diffPersons = 0;
//compare the person with the other persons in the list
foreach (var person in personList)
{
    if (personToCompare.CompareTo(person) == 0)
    {
        equalPersons++;
    }
    else
    {
        diffPersons++;
    }
}

//print the result
if (equalPersons == 1)
{
    Console.WriteLine("No matches");
}
else
{
    Console.WriteLine($"{equalPersons} {diffPersons} {personList.Count}");
}

