namespace E03.MaximalSum
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
            int[,] matrix = new int[rows, cols];

            //fill the matrix with characters
            for (int row = 0; row < rows; row++)
            {
                //get the input data
                int[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                //fill it in the rows
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            //set rows and cols for the looked matrix
            int lookRows = 3;
            int lookCols = 3;

            //save the greatest sum of elements
            int greatestSum = 0;

            //save the greatest sum start row and col
            int startRow = 0;
            int startCol = 0;

            //calculate the sum in 3x3 matrixes
            for (int row = 0; row <= rows - lookRows; row++)
            {
                for (int col = 0; col <= cols - lookCols; col++)
                {
                    int currentSum = 0;

                    for (int currRow = 0; currRow < lookRows; currRow++)
                    {
                        for (int currCol = 0; currCol < lookCols; currCol++)
                        {
                            currentSum += matrix[row + currRow, col + currCol];
                        }
                    }

                    if (currentSum > greatestSum)
                    {
                        greatestSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            //print greatest sum
            Console.WriteLine($"Sum = {greatestSum}");

            //print matrix with the greatest sum
            for (int currRow = startRow; currRow < startRow + lookRows; currRow++)
            {
                for (int currCol = startCol; currCol < startCol + lookCols; currCol++)
                {
                    Console.Write($"{matrix[currRow, currCol]} "); ;
                }
                Console.WriteLine();
            }  
        }
    }
}
