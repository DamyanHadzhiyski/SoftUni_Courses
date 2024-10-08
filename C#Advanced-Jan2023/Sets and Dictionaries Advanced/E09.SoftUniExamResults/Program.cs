namespace E09.SoftUniExamResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the information for the user and put it in a dictionary
            //Dictionary<userName, int>
            Dictionary<string, int> submissionsList = new Dictionary<string, int>();

            //create a dictionary with users and points
            Dictionary<string, int> usersList = new Dictionary<string, int>();

            //fill the data
            while (true)
            {
                //read the input and if it is "exam finished" stop reading
                string input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                //split the input to contest name and password for the contest
                string[] inputArray = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string userName = inputArray[0];
                string language = inputArray[1];
                
                if (language == "banned")
                {
                    usersList.Remove(userName);
                    continue;
                }

                int points = int.Parse(inputArray[2]);

                //check if the contest exist, if not add it
                if (!usersList.ContainsKey(userName))
                {
                    usersList.Add(userName, points);
                }

                //fill the user points and submission count for the language
                if (usersList[userName] < points)
                {
                    usersList[userName] = points; ;
                }

                //check if the submission exists, if not add it
                if (!submissionsList.ContainsKey(language))
                {
                    submissionsList.Add(language, 0);
                }

                submissionsList[language]++;
                
                //sort by most points
                usersList = usersList.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
                submissionsList = submissionsList.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            }

            //print users results
            Console.WriteLine("Results:");

            foreach (var user in usersList)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            //print language submissions
            Console.WriteLine("Submissions:");

            foreach (var submission in submissionsList)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
