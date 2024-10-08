namespace E01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //get the count of entered usernames
            int count = int.Parse(Console.ReadLine());

            //creat hash set that will keep only unique names
            HashSet<string> usernames = new HashSet<string>();

            //read the usernames
            for (int i = 0; i < count; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
