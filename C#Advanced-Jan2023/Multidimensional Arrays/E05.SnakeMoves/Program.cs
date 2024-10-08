namespace E05.SnakeMoves
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

            //read the string representing the snake
            string snake = Console.ReadLine();

            //current letter from the snake
            int letter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[letter];                        
                    }
                    else
                    {
                        matrix[row, cols - col - 1] = snake[letter];
                    }

                    letter++;

                    if (letter >= snake.Length)
                    {
                        letter = 0;
                    }
                }
            }

            //print matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}"); ;
                }
                Console.WriteLine();
            }

        }
    }
}
