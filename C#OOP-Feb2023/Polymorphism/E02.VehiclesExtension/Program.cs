//get car info
using E01.Vehicles.Models;

string[] carInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

//create the car
Vehicle car = new Car(double.Parse(carInfo[3]), double.Parse(carInfo[1]), double.Parse(carInfo[2]));

//get truck info
string[] truckInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

//create the truck
Vehicle truck = new Truck(double.Parse(truckInfo[3]), double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

//get bus info
string[] busInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

//create the truck
Vehicle bus = new Bus(double.Parse(busInfo[3]), double.Parse(busInfo[1]), double.Parse(busInfo[2]));

//number of commands
int commands = int.Parse(Console.ReadLine());

for (int i = 0; i < commands; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (input[0] == "Drive")
    {
        switch (input[1])
        {
            case "Car":
                car.Drive(double.Parse(input[2]));
                break;
            case "Truck":
                truck.Drive(double.Parse(input[2]));
                break;
            case "Bus":
                bus.Drive(double.Parse(input[2]));
                break;
        }
    }
    else if (input[0] == "Refuel")
    {

        switch (input[1])
        {
            case "Car":
                car.Refuel(double.Parse(input[2]));
                break;
            case "Truck":
                truck.Refuel(double.Parse(input[2]));
                break;
            case "Bus":
                bus.Refuel(double.Parse(input[2]));
                break;
        }
    }
    else
    {
        bus.Drive(double.Parse(input[2]), false);
    }
}

Console.WriteLine(car.ToString());
Console.WriteLine(truck.ToString());
Console.WriteLine(bus.ToString());