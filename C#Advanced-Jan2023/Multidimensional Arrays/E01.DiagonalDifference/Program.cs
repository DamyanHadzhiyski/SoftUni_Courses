namespace E01.DiagonalDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the size of the matrix
            int size = int.Parse(Console.ReadLine());

            //implement the matrix
            int[][] matrix = new int[size][];

            //fill the matrix
            for (int i = 0; i < size; i++)
            {
                int[] innerMatrix = (
                    Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray()
                );

                matrix[i] = innerMatrix;
            }

            //calculate sums of the diagonals
            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < size; i++)
            {
                primarySum += matrix[i][i];
                secondarySum += matrix[matrix.GetLength(0) - 1 - i][i];
            }

            int absDiff = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(absDiff);
        }
    }
}
