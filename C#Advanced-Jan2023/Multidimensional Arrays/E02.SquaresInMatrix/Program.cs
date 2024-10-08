namespace E02.SquaresInMatrix
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
            char[,] matrix = new char[rows, cols];

            //fill the matrix with characters
            for (int row = 0; row < rows; row++)
            {
                //get the input data
                char[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                //fill it in the rows
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            //count found square matrixes
            int foundSqrMatrixes = 0;

            //define size of the matrix to be found
            int lookRows = 2;
            int lookCols = 2;

            bool matrixFound = false;

            //look for 2x2 squares with equal chars
            for (int row = 0; row <= rows - lookRows; row++)
            {
                for (int col = 0; col <= cols - lookCols; col++)
                {
                    for (int currCol = 1; currCol < lookCols; currCol++)
                    {
                        if (matrix[row, col] == matrix[row, col + currCol] 
                            && matrix[row, col] == matrix[row + currCol, col])
                        {
                            if (matrix[row + currCol, col] == matrix[row + currCol, col + currCol])
                            {
                                matrixFound = true;
                                continue;
                            }
                            else
                            {
                                matrixFound = false;
                                break;
                            }
                        }
                        else
                        {
                            matrixFound = false;
                            break;
                        }
                    }
                
                    if (matrixFound)
                    {
                        foundSqrMatrixes++;
                    }
                }
            }

            Console.WriteLine(foundSqrMatrixes);
        }
    }
}
