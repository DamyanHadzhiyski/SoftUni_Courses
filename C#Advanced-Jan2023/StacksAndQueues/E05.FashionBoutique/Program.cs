namespace E05.FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //read clothes quantity
            int[] clothesQty = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //create stack for the clothes
            Stack<int> clothes = new Stack<int>(clothesQty);

            //read initial rack capacity
            int initRackCapacity = int.Parse(Console.ReadLine());

            //quantity of rack used
            int racksQty = 1;

            //rack capaciy left
            int leftRackCapacity = initRackCapacity;

            //put clothes on the racks
            while (clothes.Count != 0)
            {
                if (leftRackCapacity >= clothes.Peek())
                {
                    leftRackCapacity -= clothes.Pop();
                }
                else
                {
                    racksQty++;
                    leftRackCapacity = initRackCapacity;
                }
            }

            //print the quantity of the racks used
            Console.WriteLine(racksQty);
        }
    }
}
