namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream readStream = new FileStream(inputFilePath, FileMode.Open);
            FileStream writeStream = new FileStream(outputFilePath, FileMode.CreateNew);

            readStream.CopyTo(writeStream);

            readStream.Close();
            writeStream.Close();
        }
    }
}
