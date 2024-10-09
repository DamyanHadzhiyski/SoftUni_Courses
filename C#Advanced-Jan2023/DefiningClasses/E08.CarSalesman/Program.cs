using E07.RawData;

//read the count of engines
int enginesCount = int.Parse(Console.ReadLine());

//create a list to store all engined
List<Engine> engines = new List<Engine>();

//get the info for each engine
for (int i = 0; i < enginesCount; i++)
{
    string[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string engineModel = inputInfo[0];
    int enginePower = int.Parse(inputInfo[1]);
    int engineDisplacement = 0;
    string engineEfficiency = "n/a";

    //check if other parameters are passed
    if (inputInfo.Length == 3)
    {
        int.TryParse(inputInfo[2], out engineDisplacement);

        if (engineDisplacement == 0)
        {
            engineEfficiency = inputInfo[2];
        }
    }
    else if (inputInfo.Length == 4)
    {
        engineDisplacement = int.Parse(inputInfo[2]);
        engineEfficiency = inputInfo[3];
    }

    Engine newEngine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
    engines.Add(newEngine);
}


//read the count of cars
int carsCount = int.Parse(Console.ReadLine());

//create a list to store all cars
List<Car> cars = new List<Car>();

//get the info for each car
for (int i = 0; i < carsCount; i++)
{
    string[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string carModel = inputInfo[0];
    string engineModel = inputInfo[1];
    int weight = 0;
    string color = "n/a";

    //check if other parameters are passed
    if (inputInfo.Length == 3)
    {
        int.TryParse(inputInfo[2], out weight);

        if (weight == 0)
        {
            color = inputInfo[2];
        }
    }
    else if (inputInfo.Length == 4)
    {
        weight = int.Parse(inputInfo[2]);
        color = inputInfo[3];
    }

    //find the engine from the engin list
    Engine engine = engines.First(n => n.Model == engineModel);
    Car newCar = new Car(carModel, engine, weight, color);

    cars.Add(newCar);
}

//print cars info
foreach (var car in cars)
{
    car.Print();
}