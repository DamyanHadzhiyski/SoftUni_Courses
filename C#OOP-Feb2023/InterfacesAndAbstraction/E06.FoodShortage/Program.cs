using System.Security.Cryptography.X509Certificates;

namespace E06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create a list with all arrivals
            int numberOfPeople = int.Parse(Console.ReadLine());

            //create list with humans
            List<Human> listHumans = new();

            //add people to the list
            string input = string.Empty;

            for (int i = 0; i < numberOfPeople; i++)
            {
                input = Console.ReadLine();

                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 3)
                {
                    Human rebel = new Rebel(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                    listHumans.Add(rebel);
                }
                else
                {
                    Human citizen = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2], splitInput[3]);
                    listHumans.Add(citizen);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                listHumans.FirstOrDefault(buyer => buyer.Name == input)?.BuyFood();
            }

            Console.WriteLine(listHumans.Sum(b => b.Food));
        }
    }
}