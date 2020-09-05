using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class ZombieInMatrixProblem
    {
        public int MinHours(int rows, int columns, List<List<int>> grid)
        {
            int hours = 0;
            int humans = rows * columns;

            if (rows <= 0 || columns <= 0)
                return hours;

            Queue<int[]> queue = new Queue<int[]>();


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        humans--;
                        queue.Enqueue(new int[] { i, j });
                    }
                }
            }

            int queueCount = queue.Count;
            int[][] directions = {
                new int[]{0, 1},
                new int[]{1, 0},
                new int[]{0, -1},
                new int[]{-1, 0}
            };

            while (humans > 0 && queueCount > 0)
            {
                for (int i = 0; i < queueCount; i++)
                {
                    int[] zombie = queue.Dequeue();

                    foreach (int[] direction in directions)
                    {
                        int newRow = zombie[0] + direction[0];
                        int newColumn = zombie[1] + direction[1];

                        if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && grid[newRow][newColumn] == 0)
                        {
                            humans--;
                            grid[newRow][newColumn] = 1;
                            queue.Enqueue(new int[] { newRow, newColumn });
                        }
                    }
                }

                hours++;
                queueCount = queue.Count;
            }

            return hours;
        }
    }
}