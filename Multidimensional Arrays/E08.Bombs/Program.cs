namespace E08.Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the size of the field
            int size = int.Parse(Console.ReadLine());

            //initilize the field
            int[,] field = new int[size, size];

            //fill the data in the field
            for (int i = 0; i < size; i++)
            {
                int[] dataRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    field[i, j] = dataRow[j];
                }
            }

            //define List with bomb coordinations
            List<string> bombsList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //start bombs processing
            for (int i = 0; i < bombsList.Count; i++)
            {
                //convert string coordinates into indexes
                int[] indexes = bombsList.ElementAt(i)
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                //split the coordinates
                int row = indexes[0];
                int col = indexes[1];

                //process the bomb on the given coordinates
                ClearBomb(field, row, col);
            }

            //define parameters to count live cells and their sum
            int liveCellsCount = 0;
            int liveCellsSum = 0;

            //count and sum the values of all live cells
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] > 0)
                    {
                        liveCellsCount++;
                        liveCellsSum += field[i, j];
                    }
                }
            }

            //print active cells count
            Console.WriteLine($"Alive cells: {liveCellsCount}");

            //print active cells sums
            Console.WriteLine($"Sum: {liveCellsSum}");

            //print the resulting field
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void ClearBomb(int[,] field, int row, int col)
        {
            //get the bomb value
            int bombValue = field[row, col];

            if (bombValue > 0)
            {
                field[row,col] = 0;

                //top
                if (row > 0 && field[row - 1,col] > 0)
                {
                    field[row - 1,col] -= bombValue;
                }

                //bottom
                if (row < field.GetLength(0) - 1 && field[row + 1,col] > 0)
                {
                    field[row + 1,col] -= bombValue;
                }

                //left
                if (col > 0 && field[row,col - 1] > 0)
                {
                    field[row,col - 1] -= bombValue;
                }

                //right
                if (col < field.GetLength(1) - 1 && field[row,col + 1] > 0)
                {
                    field[row,col + 1] -= bombValue;
                }

                //top left
                if (row > 0 && col > 0 && field[row - 1,col - 1] > 0)
                {
                    field[row - 1,col - 1] -= bombValue;
                }

                //bottom left
                if (row < field.GetLength(0) - 1 && col > 0 && field[row + 1,col - 1] > 0)
                {
                    field[row + 1,col - 1] -= bombValue;
                }

                //top right
                if (row > 0 && col < field.GetLength(1) - 1 && field[row - 1,col + 1] > 0)
                {
                    field[row - 1,col + 1] -= bombValue;
                }

                //bottom right
                if (row < field.GetLength(0) - 1 && col < field.GetLength(1) - 1 && field[row + 1,col + 1] > 0)
                {
                    field[row + 1,col + 1] -= bombValue;
                }
            }
        }
    }
}
