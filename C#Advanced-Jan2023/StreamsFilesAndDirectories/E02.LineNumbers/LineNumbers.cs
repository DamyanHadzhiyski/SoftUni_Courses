namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                StringBuilder text = new StringBuilder();

                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    //parameter that keeps the line number
                    int line = 0;

                    while (!reader.EndOfStream)
                    {
                        string inputText = reader.ReadLine();
                        int punctuationCount = 0;
                        int letterCount = 0;

                        foreach (char ch in inputText)
                        {
                            if (((int)ch >= 65 && (int)ch <= 90) 
                                ||((int)ch >= 97 && (int)ch <= 122))
                            {
                                letterCount++;
                            }
                            else if ((int)ch != 32)
                            {
                                punctuationCount++;
                            }
                        }
                        text.AppendLine($"Line {++line} {inputText} ({letterCount})({punctuationCount})");
                    }

                    writer.WriteLine(text);
                }
            }
        }
    }
}
