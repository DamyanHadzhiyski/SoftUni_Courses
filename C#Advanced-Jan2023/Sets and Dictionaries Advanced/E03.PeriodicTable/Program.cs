namespace E03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //get the count of the elements
            int count = int.Parse(Console.ReadLine());

            //creat hash set that will keep only unique names
            List<string> elementsList = new List<string>();

            //read the usernames
            for (int i = 0; i < count; i++)
            {
                //read the name of the element
                string[] elementsNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elementsNames.Length; j++)
                {
                    if (!elementsList.Contains(elementsNames[j]))
                    {
                        elementsList.Add(elementsNames[j]);
                    }
                }
            }

            //sort the list
            elementsList.Sort();

            Console.WriteLine(string.Join(" ", elementsList));
        }
    }
}
