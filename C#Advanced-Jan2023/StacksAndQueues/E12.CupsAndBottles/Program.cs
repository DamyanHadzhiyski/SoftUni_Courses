namespace E12.CupsAndBottles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //get cup's capacity na dput them in queue
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> cupsQueue = new Queue<int>(cupsCapacity);

            //get bottle's capacity and put them in stack
            int[] bottlesCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bottlesStack = new Stack<int>(bottlesCapacity);

            //waste water amount counter
            int wasteWaterAmount = 0;

            //start filling
            while (cupsQueue.Count != 0 && bottlesStack.Count != 0)
            {
                int waterInCup = 0;

                while (waterInCup < cupsQueue.Peek() && bottlesStack.Count > 0)
                {
                    //check is cup has enough capacity to take the water from the bottle
                    //if no, fill the cup and remove it from the queue
                    //add the reamining bottle water in the waste water amount
                    //and remove the bottle from the stack
                    if (bottlesStack.Peek() >= (cupsQueue.Peek() - waterInCup))
                    {
                        //increase waste water amount and remove the cup and bottle
                        wasteWaterAmount += (bottlesStack.Pop() - (cupsQueue.Dequeue() - waterInCup));
                        break;
                    }
                    //if the cup can take the water in the bottle
                    //fill the cup and remove the bottle
                    else
                    {
                        //increase the water in the cup
                        waterInCup += bottlesStack.Pop();
                    }
                }
            }

            //print remaining bottles individual amount
            if (bottlesStack.Count > 0)
            { 
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
            }
            

            //print remaining cups individual capacity
            if (cupsQueue.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }
            

            //print wasted water amount
            Console.WriteLine($"Wasted litters of water: {wasteWaterAmount}");
        }
    }
}
