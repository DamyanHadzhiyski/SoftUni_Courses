namespace E06.JaggedArrayManipulator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the number of rows
            int rows = int.Parse(Console.ReadLine());

            //implement the jagged array
            int[][] array = new int[rows][];

            //fill the array
            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                array[row] = rowData;
            }

            //analyze the array
            for (int row = 0; row < rows - 1; row++)
            {
                //get current row lenght
                int currRowLenght = array[row].GetLength(0);

                //get next row lenght
                int nextRowLenght = array[row + 1].GetLength(0);

                if (currRowLenght == nextRowLenght)
                {
                    for (int col = 0; col < array[row].GetLength(0); col++)
                    {
                        array[row][col] *= 2;
                        array[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < array[row].GetLength(0); col++)
                    {
                        array[row][col] /= 2;
                    }

                    for (int col = 0; col < array[row + 1].GetLength(0); col++)
                    {
                        array[row + 1][col] /= 2;
                    }
                }
            }

            //manipulate the array
            string input = string.Empty;

            while((input = Console.ReadLine()) != "End")
            {
                string[] inArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inArray[0];
                int changeRow = int.Parse(inArray[1]);
                int changeCol = int.Parse(inArray[2]);
                int value = int.Parse(inArray[3]);

                if (changeRow >= 0 && changeRow < rows 
                    && changeCol >= 0 && changeCol < array[changeRow].GetLength(0))
                {
                    switch (command)
                    {
                        case "Add":
                            array[changeRow][changeCol] += value;
                            break;
                        case "Subtract":
                            array[changeRow][changeCol] -= value;
                            break;
                        default:
                            break;
                    } 
                }
            }

            //print array
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < array[row].GetLength(0); col++)
                {
                    Console.Write($"{array[row][col]} "); ;
                }
                Console.WriteLine();
            }
        }
    }
}
