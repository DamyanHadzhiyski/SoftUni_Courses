namespace E11.KeyRevolver
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //get bullet price
            int bulletPrice = int.Parse(Console.ReadLine());

            //get the size of the gun barrel
            int gunBarrelSize = int.Parse(Console.ReadLine());

            //gte bullets sizes and put them in a queue
            int[] bulletSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bulletsStack = new Stack<int>(bulletSizes);

            //get locks sizes and put them in a queue
            int[] lockSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> locksQueue = new Queue<int>(lockSizes);

            //get the value of the intelligence
            int intelligenceValue = int.Parse(Console.ReadLine());

            //counter for used bullets
            int bulletsUsed = 0;

            //start shooting
            while (locksQueue.Count != 0 && bulletsStack.Count != 0)
            {
                if (locksQueue.Peek() >= bulletsStack.Pop())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                //calculate left intelligence value
                intelligenceValue -= bulletPrice;

                //increase the value of used bullets
                bulletsUsed++;


                if (bulletsUsed >= gunBarrelSize && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsUsed = 0;
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else if (bulletsStack.Count >= 0 && locksQueue.Count <= 0)
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue}");
            }
        }
    }
}
