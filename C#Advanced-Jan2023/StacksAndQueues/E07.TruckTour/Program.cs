namespace E07.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //read petrol pumps count
            int pumpsQty = int.Parse(Console.ReadLine());

            //create queues for the petrol amounts and the distances
            Queue<int> petrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            //execute the program
            for (int i = 0; i < pumpsQty; i++)
            {
                //read information for the pump
                int[] pumpInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                //split pump info between the queues index 0 - petrol amount, index 1- distance to next pump
                petrol.Enqueue(pumpInfo[0]);
                distance.Enqueue(pumpInfo[1]);      
            }

            int currentPetrolAmount = 0;
            int pumpIndex = 0;

            for (int i = 0; i < pumpsQty; i++)
            {
                currentPetrolAmount = petrol.Peek();

                int currentPump = 1;
                bool resetQueue = false;
                bool succeeded = true;

                while (currentPump <= pumpsQty + 1)
                {
                    if (currentPetrolAmount >= distance.Peek() && resetQueue == false)
                    {
                        petrol.Enqueue(petrol.Dequeue());
                        currentPetrolAmount += (petrol.Peek() - distance.Peek());
                        distance.Enqueue(distance.Dequeue());
                    }
                    else
                    {
                        petrol.Enqueue(petrol.Dequeue());
                        distance.Enqueue(distance.Dequeue());
                        resetQueue = true;
                        succeeded = false;
                    }
                    currentPump++;
                }

                if (succeeded)
                {
                    pumpIndex = i;
                    break;
                }
            }

            Console.WriteLine(pumpIndex);
        }
    }
}
