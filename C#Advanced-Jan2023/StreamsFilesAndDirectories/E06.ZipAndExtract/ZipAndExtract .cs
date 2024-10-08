namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            //check, if the archive exist, if it does delete it
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            using ZipArchive archiveFile = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);

            string fileName = Path.GetFileName(inputFilePath);

            archiveFile.CreateEntryFromFile(inputFilePath, fileName);

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive archiveFile = ZipFile.OpenRead(zipArchiveFilePath);

            ZipArchiveEntry archiveEntry = archiveFile.GetEntry(fileName);

            archiveEntry.ExtractToFile(outputFilePath);
        }
    }
}
