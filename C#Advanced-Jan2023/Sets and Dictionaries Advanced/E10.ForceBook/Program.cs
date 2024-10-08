namespace E10.ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //create a dictionary that stores information for each force user
            //Dictionary<userName, forceSide>
            Dictionary<string, string> forceUsers = new Dictionary<string, string>();

            //create a dictionary that stores information for each force side
            //Dictionary<sideName, usersCount>
            Dictionary<string, int> forceSides = new Dictionary<string, int>();

            //read the data
            while (true)
            {
                //read the input and if it is "Lumpawaroo" stop reading
                string input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                string forceUser = string.Empty;
                string forceSide = string.Empty;
                string command = string.Empty;

                //split the input
                string[] inputArray = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArray.Length == 2)
                {
                    forceUser = inputArray[1];
                    forceSide = inputArray[0];
                    command = " | ";
                }
                else
                {
                    inputArray = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    forceUser = inputArray[0];
                    forceSide = inputArray[1];
                    command = " -> ";
                }
                
                //check if the contest exist, if not add it, else go next
                if (!forceUsers.ContainsKey(forceUser))
                {                   
                    //if the side does not exist, create it, else increse the number of users
                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides.Add(forceSide, 1);
                    }
                    else
                    {
                        forceSides[forceSide]++;
                    }

                    //add the user to the users list
                    forceUsers.Add(forceUser, forceSide);

                    if (command == " -> ")
                    {
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }                    
                }
                else
                {

                    if (command == " -> ")
                    {
                        //get users current side and remove it user counts by one
                        string currentSide = forceUsers[forceUser];
                        forceSides[currentSide]--;

                        //change the side and increase the new side users count
                        forceUsers[forceUser] = forceSide;
                        if (!forceSides.ContainsKey(forceSide))
                        {
                            forceSides.Add(forceSide, 0);
                        }
                        forceSides[forceSide]++;

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }


            //order
            forceSides = forceSides
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            forceUsers = forceUsers
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            //print users results
            foreach (var side in forceSides)
            {
                if (side.Value > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value}");

                    foreach (var user in forceUsers.Where(x => x.Value == side.Key))
                    {
                        Console.WriteLine($"! {user.Key}");
                    }
                }   
            }
        }
    }
}
