using E04.WildFarm.Factories.Interfaces;
using E04.WildFarm.Models.Animals.Birds;
using E04.WildFarm.Models.Animals.Mammals;
using E04.WildFarm.Models.Animals.Mammals.Felines;
using E04.WildFarm.Models.Interfaces;

namespace E04.WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] arguments)
        {
            string type = arguments[0];
            string name = arguments[1];
            double weight = double.Parse(arguments[2]);

            switch (type)
            {
                case "Owl":
                    return new Owl(name, weight, double.Parse(arguments[3]));
                case "Hen":
                    return new Hen(name, weight, double.Parse(arguments[3]));
                case "Mouse":
                    return new Mouse(name, weight, arguments[3]);
                case "Dog":
                    return new Dog(name, weight, arguments[3]);
                case "Cat":
                    return new Cat(name, weight, arguments[3], arguments[4]);
                case "Tiger":
                    return new Tiger(name, weight, arguments[3], arguments[4]);
                default:
                    throw new ArgumentException("Invalid animal type!");
            };
        }
    }
}
