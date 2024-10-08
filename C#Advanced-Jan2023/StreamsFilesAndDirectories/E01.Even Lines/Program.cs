namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            //define parameter to pass the final result
            StringBuilder text = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int line = 0;

                while (!reader.EndOfStream)
                {
                    //read the input line
                    string inputText = reader.ReadLine();

                    if (line % 2 == 0)
                    {
                        //create array for chars to be replaced
                        char[] charArray = new char[] { '-', ',', '.', '!', '?' };

                        //replace the chars
                        for (int i = 0; i < charArray.Length; i++)
                        {
                            inputText = inputText.Replace(charArray[i], '@');
                        }

                        //split the text and add it in reverse order into the result parameter
                        string[] inputTextArray = inputText.Split();

                        for (int i = inputTextArray.Length - 1; i >= 0; i--)
                        {
                            text.Append(inputTextArray[i] + " ");
                        }

                        //add new line on the resulting parameter
                        text.AppendLine();
                    }

                    //increase the number of processed lines
                    line++;
                }
            }

            return text.ToString();
        }
    }
}

