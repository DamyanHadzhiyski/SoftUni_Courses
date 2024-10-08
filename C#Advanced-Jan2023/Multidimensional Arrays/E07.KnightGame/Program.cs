namespace E07.KnightGame
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //get the size of the board
            int size = int.Parse(Console.ReadLine());

            //implement the matrix
            char[,] board = new char[size, size];
            char knight = 'K';

            //fill every row with knights(K's) and empty spaces(0's)
            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = rowData[col];
                }
            }

            //if the size of the matrix does not allow knight to move, end the code
            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            //set counter for the removed knights
            int removedKnights = 0;

            //run the program until there is no knights that can get another
            while (true)
            {
                //set counter for the knights in reach
                int knightsAround = 0;

                //get the coordinates of the knight with most knights around it
                int highestRow = 0;
                int highestCol = 0;
                int highestCount = 0;

                //knights moves:
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == knight)
                        {
                            knightsAround = CountKnightsAround(board, knight, row, col);
                            
                            if (knightsAround > highestCount)
                            {
                                highestCount = knightsAround;
                                highestRow = row;
                                highestCol = col;
                            }
                        }
                    }
                }

                if (highestCount != 0)
                {
                    //remove the knight with highest number of reachable knights
                    board[highestRow, highestCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnights);
        }

        private static int CountKnightsAround(char[,] board, char knight, int row, int col)
        {
            int knightsAround = 0;

            //up_right - (currRow - 2) & (currCol + 1)
            if (row - 2 >= 0 && col + 1 < board.GetLength(1)
                && board[row - 2, col + 1] == knight)
            {
                knightsAround++;
            }

            //right_up - (currRow - 1) & (currCol + 2)
            if (row - 1 >= 0 && col + 2 < board.GetLength(1)
                && board[row - 1, col + 2] == knight)
            {
                knightsAround++;
            }

            //right_down - (currRow + 1) & (currCol + 2)
            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1)
                && board[row + 1, col + 2] == knight)
            {
                knightsAround++;
            };

            //down_right - (currRow + 2) & (currCol + 1)
            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1)
                && board[row + 2, col + 1] == knight)
            {
                knightsAround++;
            }

            //down_left - (currRow + 2) & (currCol - 1)
            if (row + 2 < board.GetLength(0) && col - 1 >= 0
                && board[row + 2, col - 1] == knight)
            {
                knightsAround++;
            }

            //left_down - (currRow + 1) & (currCol - 2)
            if (row + 1 < board.GetLength(0) && col - 2 >= 0
                && board[row + 1, col - 2] == knight)
            {
                knightsAround++;
            }

            //left_up - (currRow - 1) & (currCol - 2)
            if (row - 1 >= 0 && col - 2 >= 0
                && board[row - 1, col - 2] == knight)
            {
                knightsAround++;
            }

            //up_left - (currRow - 2) & (currCol - 1)
            if (row - 2 >= 0 && col - 1 >= 0
                && board[row - 2, col - 1] == knight)
            {
                knightsAround++;
            }

            return knightsAround;
        }
    }
}
