namespace E04.FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //food quantity
            int foodQty = int.Parse(Console.ReadLine());

            //individual order quantity
            int[] ordersQty = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //put orders in queue
            Queue<int> orders = new Queue<int>(ordersQty);

            //find the biggest order
            int biggestOrder = int.MinValue;

            foreach (var order in orders)
            {
                if (order > biggestOrder)
                {
                    biggestOrder = order;
                }
            }

            Console.WriteLine(biggestOrder);

            //execute the orders
            bool succeeded = true;

            while (orders.Count != 0)
            {
                //check, if there is enough food
                if (foodQty >= orders.Peek())
                {
                    foodQty -= orders.Dequeue();
                }
                else
                {
                    succeeded = false;
                    break;
                }
            }
            
            if (succeeded)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
