namespace E03.MaximumandMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //read the number of queries
            int queries = int.Parse(Console.ReadLine());

            //create the stack
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                //read the querie
                int[] querieType = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (querieType[0] == 1)
                {
                    //get the number to push in stack
                    int number = querieType[1];
                    stack.Push(number);
                }
                else if (querieType[0] == 2)
                {
                    stack.Pop();
                }
                else if (querieType[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        //convert stack to array
                        int[] stackArray = stack.ToArray();
                        int maximum = stackArray[0];

                        for (int j = 1; j < stackArray.Length; j++)
                        {
                            if (stackArray[j] > maximum)
                            {
                                maximum = stackArray[j];
                            }
                        }
                        Console.WriteLine(maximum);
                    }                    
                }
                else if (querieType[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        //convert stack to array
                        int[] stackArray = stack.ToArray();
                        int minimum = stackArray[0];

                        for (int k = 1; k < stackArray.Length; k++)
                        {
                            if (stackArray[k] < minimum)
                            {
                                minimum = stackArray[k];
                            }
                        }
                        Console.WriteLine(minimum);
                    }                    
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
