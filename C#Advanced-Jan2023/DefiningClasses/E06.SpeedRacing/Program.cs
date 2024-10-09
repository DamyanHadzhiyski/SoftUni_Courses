using E06.SpeedRacing;
using System.Reflection;

//number of cars to track
int carsCount = int.Parse(Console.ReadLine());

//creat a list to store all cars
List<Car> carsList = new List<Car>();

//get info for each car
for (int i = 0; i < carsCount; i++)
{
    //read the car info
    string[] carInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    //split the car info accordingly
    string model = carInfo[0];
    double fuelAmount = double.Parse(carInfo[1]);
    double fuelConsumption = double.Parse(carInfo[2]);

    //create a new car and add it to the list
    Car newCar = new Car(model, fuelAmount, fuelConsumption);
    carsList.Add(newCar);
}

//start the race
string input = string.Empty;

while ((input = Console.ReadLine()) != "End")
{
    //split the input comand
    string[] splittedInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string modelToDrive = splittedInput[1];
    double kmToDrive = double.Parse(splittedInput[2]);

    //get the car to drive and drive it if possible
    Car carToDrive = carsList.First(c => c.Model == modelToDrive);

    carToDrive.Drive(kmToDrive);
}

//print each car with someinfo
foreach (var car in carsList)
{
    Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
}
