namespace E10.Crossroads
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //green light duration in seconds
            int greenOnTime = int.Parse(Console.ReadLine());

            //free window duration
            int freeWindowTime = int.Parse(Console.ReadLine());

            //create queue for the cars waiting
            Queue<string> waitingCars = new Queue<string>();

            //parameer to save the passing trough the intersection car
            string passingCar = string.Empty;
            bool crash = false;
            int totalCarsPassed = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int timeout = 0;

                    //if it is green let another car to pass
                    while (timeout < greenOnTime && crash == false && waitingCars.Count > 0)
                    {
                        passingCar = waitingCars.Dequeue();

                        //wait till a car pass trough the intersection
                        foreach (char ch in passingCar)
                        {
                            //increase the time that has passed
                            timeout++;

                            //check if the green time and free time are over
                            if (timeout > (greenOnTime + freeWindowTime))
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{passingCar} was hit at {ch}.");
                                crash = true;
                                break;
                            }
                        }
                        if (!crash && waitingCars.Count >= 0)
                        {
                            totalCarsPassed++;
                        } 
                    }
                }
                else
                {
                    waitingCars.Enqueue(input);
                }
            }
            if (!crash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
