namespace E05.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //read the text from the console
            string inputText = Console.ReadLine();

            //creat a dictonary that will keep the characters and their appearence times
            Dictionary<char, int> symbolsList = new Dictionary<char, int>();

            foreach (char ch in inputText)
            {
                if (!symbolsList.ContainsKey(ch))
                {
                    symbolsList[ch] = 0;
                }
                symbolsList[ch]++;
            }

            symbolsList = symbolsList.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in symbolsList)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }  
        }
    }
}
