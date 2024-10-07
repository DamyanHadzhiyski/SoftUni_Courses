namespace E02.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //read the number of operations for each type
            int[] elementsCount = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //read the elements
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //create the stack
            Queue<int> queue = new Queue<int>();

            //push elements
            int n = elementsCount[0];

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            //pop elements, if stack is not empty
            int s = elementsCount[1];

            for (int i = 0; i < s; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                    continue;
                }
            }

            //if stack is not empty, peek elements
            if (queue.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                //get the number to peek
                int x = elementsCount[2];
                int smallest = queue.Peek();
                bool exists = false;

                while (queue.Count != 0)
                {
                    int currentNumber = queue.Peek();

                    if (currentNumber == x)
                    {
                        Console.WriteLine("true");
                        exists = true;
                        break;
                    }
                    else if (currentNumber < smallest)
                    {
                        smallest = currentNumber;
                    }
                    queue.Dequeue();
                }

                if (!exists)
                {
                    Console.WriteLine(smallest);
                }
            }
        }
    }
}
