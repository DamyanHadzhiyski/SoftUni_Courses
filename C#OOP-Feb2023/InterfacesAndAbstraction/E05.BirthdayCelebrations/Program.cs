namespace E05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create a list with all arrivals
            List<IBirthable> arrivals = new List<IBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (splitInput[0])
                {
                    case "Citizen":
                        Citizen citizen = new Citizen(splitInput[1], int.Parse(splitInput[2]), splitInput[3], splitInput[4]);
                        arrivals.Add(citizen);
                        break;
                    case "Robot":
                        Robot robot = new Robot(splitInput[1], splitInput[2]);
                        break;
                    case "Pet":
                        Pet pet = new Pet(splitInput[1], splitInput[2]);
                        arrivals.Add(pet);
                        break;
                }
            }

            //get the last digit for the fake Ids
            string yearOfBirth = Console.ReadLine();

            //check for fake Ids
            foreach(IBirthable born in arrivals) 
            {
                if (born.BirthYearMatch(yearOfBirth))
                {
                    Console.WriteLine(born.Birthdate);
                }
            }
        }
    }
}