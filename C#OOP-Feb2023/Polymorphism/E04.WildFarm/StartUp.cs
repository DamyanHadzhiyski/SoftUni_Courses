using E04.WildFarm.Core;
using E04.WildFarm.Core.Interfaces;
using E04.WildFarm.Factories.Interfaces;
using E04.WildFarm.Factories;
using E04.WildFarm.Models.Interfaces;
using System.Reflection.PortableExecutable;

IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(animalFactory, foodFactory);

engine.Run();
