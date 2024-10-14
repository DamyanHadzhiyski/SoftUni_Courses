namespace E04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create a list with all arrivals
            List<IIdentifiable> arrivals = new List<IIdentifiable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length == 2)
                {
                    IIdentifiable robot = new Robot(splitInput[0], splitInput[1]);
                    arrivals.Add(robot);
                }
                else
                {
                    IIdentifiable citizen = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                    arrivals.Add(citizen);
                }
            }

            //get the last digit for the fake Ids
            string fakeIdLastDigit = Console.ReadLine();

            //check for fake Ids
            foreach(IIdentifiable arrival in arrivals) 
            {
                if (arrival.IsFake(fakeIdLastDigit))
                {
                    Console.WriteLine(arrival.Id);
                }
            }
        }
    }
}