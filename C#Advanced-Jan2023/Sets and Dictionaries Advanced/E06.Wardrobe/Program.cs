namespace E06.Wardrobe
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //read the number of lines with clothes
            int clothesCount = int.Parse(Console.ReadLine());

            //implement a dictonary to store the info for the clothes
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            //fill the dictionary
            for (int i = 0; i < clothesCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string[] clothType = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothType)
                {
                    if (!clothes[color].ContainsKey(cloth))
                    {
                        clothes[color].Add(cloth, 0);
                    }
                    clothes[color][cloth]++;
                }
            }

            //read the cloth that you are looking for
            string[] lookForCloth = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //split the color and the type
            string findColor = lookForCloth[0];
            string findType = lookForCloth[1];

            //print values
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == findColor && cloth.Key == findType)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
