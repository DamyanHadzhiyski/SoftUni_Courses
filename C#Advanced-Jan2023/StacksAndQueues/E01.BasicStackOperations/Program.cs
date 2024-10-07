namespace E01.BasicStackOperations
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
            Stack<int> stack = new Stack<int>();

            //push elements
            int n = elementsCount[0];

            for (int i = 0; i < n; i++)
            {
                stack.Push(elements[i]);
            }

            //pop elements, if stack is not empty
            int s = elementsCount[1];

            for (int i = 0; i < s; i++)
            {
                if (stack.Count != 0)
                {
                    stack.Pop();
                    continue;
                }            
            }

            //if stack is not empty, peek elements
            if (stack.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                //get the number to peek
                int x = elementsCount[2];
                int smallest = stack.Peek();
                bool exists = false;

                while (stack.Count != 0)
                {
                    int currentNumber = stack.Peek();
                    
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
                    stack.Pop();
                }

                if(!exists)
                {
                    Console.WriteLine(smallest);
                }
            }
        }
    }
}
