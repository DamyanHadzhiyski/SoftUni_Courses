namespace E10.RadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            //get the lair size
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            //implement the lair
            char[,] lair = new char[rows, cols];

            //get the player location
            int startRow = 0;
            int startCol = 0;

            //fill the layter with B - bunnies, P - player, . - empty space
            for (int row = 0; row < rows; row++)
            {
                //read the data for the first line
                string dataRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = dataRow[col];

                    if (lair[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            //get the string with the moves
            string moves = Console.ReadLine();

            //did the player won the game and where it ended
            string gameEnd = string.Empty;
            int currRow = startRow;
            int currCol = startCol;

            //start playing
            for (int move = 0; move < moves.Length; move++)
            {
                lair[currRow, currCol] = '.';
                int lastRow = currRow;
                int lastCol = currCol;

                switch (moves[move])
                {
                    case 'U':
                        currRow--;
                        break;
                    case 'D':
                        currRow++;
                        break;
                    case 'R':
                        currCol++;
                        break;
                    case 'L':
                        currCol--;
                        break;
                    default:
                        break;
                }

                lair = SpreadBunnies(lair);

                if (currRow < 0 || currRow >= lair.GetLength(0) || currCol < 0 || currCol >= lair.GetLength(1))
                {
                    gameEnd = "won";
                    currRow = lastRow;
                    currCol = lastCol;
                    break;
                }
                
                if (lair[currRow, currCol] == 'B')
                {
                    gameEnd = "dead";
                    break;
                }
            }

            //print the lair
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }

            //print final result
            Console.WriteLine($"{gameEnd}: {currRow} {currCol}");
        }

        private static char[,] SpreadBunnies(char[,] lair)
        {
            //create temp matrix, that will be edited
            char[,] tempLair = new char[lair.GetLength(0), lair.GetLength(1)];

            //fill the temp matrix
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    tempLair[i, j] = lair[i, j];
                }
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if(row > 0)
                        {
                            tempLair[row - 1, col] = 'B';
                        }

                        if (row < lair.GetLength(0) - 1)
                        {
                            tempLair[row + 1, col] = 'B';
                        }

                        if (col > 0)
                        {
                            tempLair[row, col - 1] = 'B';
                        }

                        if (col < lair.GetLength(1) - 1)
                        {
                            tempLair[row, col + 1] = 'B';
                        }                       
                    }
                }
            }

            return tempLair;
        }
    }
}
