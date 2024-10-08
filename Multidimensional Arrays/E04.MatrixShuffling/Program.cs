namespace E04.MatrixShuffling
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the rows and cols as one string and split them
            int[] dimesnsions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimesnsions[0];
            int cols = dimesnsions[1];

            //implement the matrix
            string[,] matrix = new string[rows, cols];

            //fill the matrix with characters
            for (int row = 0; row < rows; row++)
            {
                //get the input data
                string[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //fill it in the rows
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            //create parameter for temporary storaing of one of the values
            string tempStore = string.Empty;

            //create parameters for coordinates
            int row1 = 0;
            int col1 = 0;
            int row2 = 0;
            int col2 = 0;

            //start the process
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //check if the input is in correct format
                if (isValid(inArray, rows, cols))
                {
                    row1 = int.Parse(inArray[1]);
                    col1 = int.Parse(inArray[2]);
                    row2 = int.Parse(inArray[3]);
                    col2 = int.Parse(inArray[4]);

                    tempStore = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempStore;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                    
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            //print matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} "); ;
                }
                Console.WriteLine();
            }
        }

        private static bool isValid(string[] inArray, int rows, int cols)
        {
            if (inArray.Length == 5 && inArray[0] == "swap")
            {
                int row1 = int.Parse(inArray[1]);
                int col1 = int.Parse(inArray[2]);
                int row2 = int.Parse(inArray[3]);
                int col2 = int.Parse(inArray[4]);

                if (row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows
                    && col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
