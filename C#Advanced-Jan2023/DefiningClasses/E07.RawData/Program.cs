using E07.RawData;

//read the count of cars
int carsCount = int.Parse(Console.ReadLine());

//creat list to store all cars
List<Car> carsList = new List<Car>();
//get the info for each car
for (int i = 0; i < carsCount; i++)
{
    string[] info = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    //define parameter for each info value
    string model = info[0];
    int engineSpeed = int.Parse(info[1]);
    int enginePower = int.Parse(info[2]);
    int cargoWeight = int.Parse(info[3]);
    string cargoType = info[4];
    decimal tire1Pressure = decimal.Parse(info[5]);
    int tire1Age = int.Parse(info[6]);
    decimal tire2Pressure = decimal.Parse(info[7]);
    int tire2Age = int.Parse(info[8]);
    decimal tire3Pressure = decimal.Parse(info[9]);
    int tire3Age = int.Parse(info[10]);
    decimal tire4Pressure = decimal.Parse(info[11]);
    int tire4Age = int.Parse(info[12]);

    //define new car
    Car newCar = new Car(model,
                    new Engine(engineSpeed, enginePower),
                    new Cargo(cargoWeight, cargoType),
                    new Tire[] {new Tire(tire1Pressure, tire1Age),
                                new Tire(tire2Pressure, tire2Age),
                                new Tire(tire3Pressure, tire3Age),
                                new Tire(tire4Pressure, tire4Age),});
    
    //add the car to the list
    carsList.Add(newCar);
}

//read the type of cargo, and print the cars that carries it
string cargoFilter = Console.ReadLine();

if (cargoFilter == "fragile")
{
    foreach (var car in carsList)
    {
        if (car.Cargo.Type == cargoFilter)
        {
            foreach (var tire in car.Tires)
            {
                if (tire.Pressure < 1)
                {
                    Console.WriteLine(car.Model);
                    break;
                }
            };
        }
    }
}
else
{
    foreach (var car in carsList)
    {
        if (car.Cargo.Type == cargoFilter && car.Engine.Power > 250)
        {
            Console.WriteLine(car.Model);
        }
    }
}
