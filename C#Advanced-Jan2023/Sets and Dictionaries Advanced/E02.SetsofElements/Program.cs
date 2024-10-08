namespace E02.SetsofElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the length of both sets
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //create the lists
            HashSet<int> firstList = new HashSet<int>();
            HashSet<int> secondList = new HashSet<int>();

            //fil the data in the first list
            for (int i = 0; i < lengths[0]; i++)
            {
                firstList.Add(int.Parse(Console.ReadLine()));
            }

            //fil the data in the second list
            for (int i = 0; i < lengths[1]; i++)
            {
                secondList.Add(int.Parse(Console.ReadLine()));
            }

            //creat a list that will keep the equal elements
            List<int> commonList = new List<int>();

            for (int i = 0; i < firstList.Count; i++)
            {
                if (secondList.Contains(firstList.ElementAt(i)))
                {
                    commonList.Add(firstList.ElementAt(i));
                }
            }

            Console.WriteLine(string.Join(" ", commonList));
        }
    }
}
