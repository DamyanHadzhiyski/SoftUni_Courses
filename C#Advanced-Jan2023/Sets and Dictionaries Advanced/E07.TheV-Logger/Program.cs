namespace E07.TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //implement a dictonary to store the info for the clothes
            Dictionary<string, Dictionary<string, List<string>>> vloggers = new Dictionary<string, Dictionary<string, List<string>>>();

            //get the data
            while (true)
            {
                //read the input string
                string input = Console.ReadLine();

                //stop the execution if input is Statistics
                if (input == "Statistics")
                {
                    break;
                }

                //split the input
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //get the name of the vlogger
                string vloggerName = inputArray[0];

                //check if it is follower or new joiner and fill the V-Logger data
                if (inputArray[1] != "followed")
                {
                    //add new vlogger
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, List<string>>());
                        vloggers[vloggerName]["followed"] = new List<string>();
                        vloggers[vloggerName]["followers"] = new List<string>();
                    }
                }
                else
                {
                    //follower name
                    string followedName = inputArray[2];

                    //checlk if the follower and followed vloggers exists
                    if (vloggers.ContainsKey(vloggerName) //vlogger is existing
                        && vloggers.ContainsKey(followedName) //the one be followed is existing
                        && vloggerName != followedName //their not the same vlloger
                        && !vloggers[vloggerName]["followed"].Contains(followedName)) //check if the one to be followed is not already in the followed list

                    {
                        //add the follower to the followed vlogger, followers list
                        vloggers[followedName]["followers"].Add(vloggerName);
                        vloggers[vloggerName]["followed"].Add(followedName);
                        
                        //sort 
                        vloggers[followedName]["followers"].Sort();
                    }
                }
            }

            //sort by most followers
            vloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["followed"].Count).ToDictionary(x => x.Key, x => x.Value);

            //print values
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int rank = 0;
            foreach (var vlogger in vloggers)
            {
                rank++;

                Console.WriteLine($"{rank}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["followed"].Count} following");

                if (rank == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
