using E07.Tuple;

//read the inputs
string[] personInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string personName = personInfo[0] + " " + personInfo[1];
string address = personInfo[2];

string[] beerConsumption = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string name = beerConsumption[0];
int beerConsumed = int.Parse(beerConsumption[1]);

string[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

int number1 = int.Parse(numbers[0]);
double number2 = double.Parse(numbers[1]);

//create a new objects for each input
CustomTuple<string, string> person = new CustomTuple<string, string>(personName, address);
CustomTuple<string, int> beer = new CustomTuple<string, int>(name, beerConsumed);
CustomTuple<int, double> numbersObject = new CustomTuple<int, double>(number1, number2);

person.Print();
beer.Print();
numbersObject.Print();