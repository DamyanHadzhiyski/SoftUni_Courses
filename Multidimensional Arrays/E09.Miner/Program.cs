namespace E09.Miner
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

            //create a queue with the movement
            Queue<string> moves = new Queue<string>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            //implement the matrix field
            char[][] field = new char[size][];

            //fill the matrix field
            for (int i = 0; i < size; i++)
            {
                field[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            //count all the coals and find starting coordinates
            double coalsCount = 0;
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i][j] == 'c')
                    {
                        coalsCount++;
                    }

                    if (field[i][j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            //define possible ends of the game
            bool noMoreCoals = false;
            bool gameOver = false;

            //start mining
            int currRow = startRow;
            int currCol = startCol;

            while (moves.Count > 0)
            {
                //move the miner, if possible
                switch(moves.Dequeue())
                {
                    case "up":
                        if (currRow > 0)
                        {
                            currRow--;
                        }
                        break;
                    case "down":
                        if (currRow < size - 1)
                        {
                            currRow++;
                        }
                        break;
                    case "right":
                        if (currCol < size - 1)
                        {
                            currCol++;
                        }
                        break;
                    case "left":
                        if (currCol > 0)
                        {
                            currCol--;
                        }
                        break;
                    default:
                        break;

                }

                //check what is on the new possition
                if (field[currRow][currCol] == 'c')
                {
                    coalsCount--;
                    field[currRow][currCol] = '*';
                }
                else if(field[currRow][currCol] == 'e')
                {
                    gameOver = true;
                    break;
                }

                if (coalsCount <= 0)
                {
                    noMoreCoals = true;
                    break;
                }
            }

            // print message how the game ended
            if (gameOver)
            {
                Console.WriteLine($"Game over! ({currRow}, {currCol})");
            }
            else if(noMoreCoals)
            {
                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
            }
            else
            {
                Console.WriteLine($"{coalsCount} coals left. ({currRow}, {currCol})");
            }
        }
    }
}
