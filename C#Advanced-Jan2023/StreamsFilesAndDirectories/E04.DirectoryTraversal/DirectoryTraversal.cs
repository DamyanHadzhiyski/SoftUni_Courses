namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            //define list that will keep the extension and the files with the extension and their size
            //Dictionary<extension, Dictionary<fileName, size>
            Dictionary<string, Dictionary<string, long>> filesList = new Dictionary<string, Dictionary<string, long>>();

            DirectoryInfo directoryInformation = new DirectoryInfo(inputFolderPath);

            foreach (var item in directoryInformation.GetFiles())
            {
                string fileExtension = item.Extension.ToString();
                string fileName = item.Name.ToString();
                long fileSize = item.Length / 1000;

                if (!filesList.ContainsKey(fileExtension))
                {
                    filesList.Add(item.Extension.ToString(), new Dictionary<string, long>());
                }

                filesList[fileExtension].Add(fileName, fileSize);
                filesList[fileExtension] = filesList[fileExtension].OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            filesList = filesList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            StringBuilder result = new StringBuilder();

            foreach (var extension in filesList)
            {
                //char extGrpSeparator = '|';
                //char nameGrpSeparator = '_';
                //char sizeSeparator = '-';

                result.AppendLine(extension.Key);

                foreach (var file in extension.Value)
                {
                    result.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }

            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            StreamWriter createFile = new StreamWriter(path);

            createFile.Write(textContent);

            createFile.Close();
        }
    }
}
