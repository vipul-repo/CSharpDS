using System;

namespace CSharpDS
{
    class NumIslandsProblem
    {
        public NumIslandsProblem()
        {
        }

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int islands = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                if (grid[row] == null)
                    continue;

                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        islands++;
                        ExploreIsland(grid, row, col);
                    }
                }
            }

            return islands;
        }

        private void ExploreIsland(char[][] grid, int col, int row)
        {
            if (row < 0 || row >= grid.Length || grid[row] == null || col < 0 || col >= grid[row].Length)
                return;

            if (grid[row][col] == '1')
            {
                grid[row][col] = '0';

                ExploreIsland(grid, row - 1, col);
                ExploreIsland(grid, row, col + 1);
                ExploreIsland(grid, row + 1, col);
                ExploreIsland(grid, row, col - 1);
            }
        }
    }
}