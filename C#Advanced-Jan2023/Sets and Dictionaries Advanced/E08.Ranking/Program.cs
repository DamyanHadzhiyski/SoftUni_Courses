namespace E08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the information for the contests and put it in a dictionary
            //Dictionary<contest, password>
            Dictionary<string, string> contestsList = new Dictionary<string, string>();

            while(true)
            {
                //read the input and if it is "end of contests" stop reading
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                //split the input to contest name and password for the contest
                string[] inputArray = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputArray[0];
                string contestPassword = inputArray[1];

                //check if the contest exist, if not add it, else go next
                if (!contestsList.ContainsKey(contestName))
                {
                    contestsList.Add(contestName, contestPassword);
                }
            }

            //get the information for the users that are signing to the contest
            //Dictionary<userName, Dictionary<contest, points>>
            Dictionary<string, Dictionary<string, int>> usersList = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                //read the input and if it is "end of submissions" stop reading
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                //split the input to contest name, password, user and points
                string[] inputArray = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputArray[0];
                string entryPassword = inputArray[1];
                string userName = inputArray[2];
                int contestPoints = int.Parse(inputArray[3]);

                //check if the contest exist and that the password is correct
                if (contestsList.ContainsKey(contestName) 
                    && contestsList[contestName] == entryPassword)
                {
                    //check if the user exists, if not add it
                    if (!usersList.ContainsKey(userName))
                    {
                        usersList.Add(userName, new Dictionary<string, int>());
                    }

                    //if the contest is not in his lists, add it
                    if (!usersList[userName].ContainsKey(contestName))
                    {
                        usersList[userName].Add(contestName, 0);
                    }

                    //check if current points on this contest and user
                    //are less then the new points, if yes, change them
                    if (usersList[userName][contestName] < contestPoints)
                    {
                        usersList[userName][contestName] = contestPoints;
                    }

                    //sort users contest by points in descending order
                    usersList[userName] = usersList[userName].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                }
            }

            //sort
            usersList = usersList.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //find user with most points
            string topUserName = string.Empty;
            int topUserPoints = 0;

            foreach (var user in usersList)
            {
                int usersPointsSum = 0;

                foreach(var contest in user.Value)
                {
                    usersPointsSum += contest.Value;
                }

                if (usersPointsSum > topUserPoints)
                {
                    topUserPoints = usersPointsSum;
                    topUserName = user.Key;
                }
            }

            //print values
            Console.WriteLine($"Best candidate is {topUserName} with total {topUserPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in usersList)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var course in user.Value)
                { 
                    {
                        Console.WriteLine($"#  {course.Key} -> {course.Value}");
                    }
                }
            }
        }
    }
}
