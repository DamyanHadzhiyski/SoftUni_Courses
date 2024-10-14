using E04.WildFarm.Core.Interfaces;
using E04.WildFarm.Factories.Interfaces;
using E04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace E04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(command);

                    IFood food = CreateFood();

                    Console.WriteLine(animal.ProduceSound());

                    animal.Eat(food);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

                animals.Add(animal);
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        private IAnimal CreateAnimal(string command)
        {
            string[] animalArgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.Create(animalArgs);

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTokens[0];
            int foodQuantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.Create(foodType, foodQuantity);

            return food;
        }
    }
}
