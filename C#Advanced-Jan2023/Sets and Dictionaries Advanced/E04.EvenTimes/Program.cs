namespace E04.EvenTimes
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //get the count of the elements
            int count = int.Parse(Console.ReadLine());

            //creat a dictionary that will keep the elements
            Dictionary<string, int> elementsList = new Dictionary<string, int>();

            //define parameter to store value that appears even number of times
            string value = string.Empty;

            for (int j = 0; j < count; j++)
            {
                string element = Console.ReadLine();

                if (!elementsList.ContainsKey(element))
                {
                    elementsList[element] = 0; 
                }
                elementsList[element]++;
            }

            foreach (var element in elementsList)
            {
                if (element.Value % 2 == 0)
                {
                    Console.WriteLine(element.Key);
                    return;
                }
            }
        }
    }
}
