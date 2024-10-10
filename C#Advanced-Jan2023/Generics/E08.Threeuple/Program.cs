using E08.Threeuple;

//read the inputs
string[] personInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string personName = personInfo[0] + " " + personInfo[1];
string address = personInfo[2];
string town = string.Empty;

for (int i = 3; i < personInfo.Length; i++)
{
    town += personInfo[i] + " ";
}

string[] beerConsumption = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string name = beerConsumption[0];
int beerConsumed = int.Parse(beerConsumption[1]);
string drunkOrNot = string.Empty;

if (beerConsumption[2] == "drunk")
{
    drunkOrNot = "True";
}
else
{
    drunkOrNot = "False";
}

string[] bank = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string accountName = bank[0];
double balance = double.Parse(bank[1]);
string bankName = bank[2];

//create a new objects for each input
CustomTuple<string, string, string> person = new CustomTuple<string, string, string>(personName, address, town);
CustomTuple<string, int, string> beer = new CustomTuple<string, int, string>(name, beerConsumed, drunkOrNot);
CustomTuple<string, double, string> bankInfo = new CustomTuple<string, double, string>(accountName, balance, bankName);

person.Print();
beer.Print();
bankInfo.Print();