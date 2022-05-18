global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;
using ConsoleApp1.Stack;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var t = new _456().Find132pattern(new int[] { 3, 5, 0, 1, 4 });

    }

    public class NumMatrix
    {
        public NumMatrix()
        {
        }

        private HashSet<(int x, int y, int z)> VisitedCells = new HashSet<(int x, int y, int z)>();
        public int MaximumMinimumPath(int[][] grid)
        {

            var low = int.MaxValue;
            var high = int.MinValue;

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    low = Math.Min(low, grid[i][j]);
                    high = Math.Max(high, grid[i][j]);
                }
            }

            while (low < high)
            {
                var middle = low + (high - low) / 2;

                var canDfs = CanDfs(grid, middle, high);
                Console.WriteLine(low);
                Console.WriteLine(high);
                Console.WriteLine("-----------------");
                if (canDfs)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle;
                }
            }

            return low;
        }

        private bool CanDfs(int[][] grid, int middle, int high)
        {
            VisitedCells.Clear();
            VisitedCells.Add((0, 0, grid[0][0]));
            return Dfs(grid, 0, 0, middle, grid[0][0]);

        }

        private bool Dfs(int[][] grid, int row, int col, int middle, int currentScore)
        {
            var adjacentCells = new int[][] {
                new int[] {row - 1, col},
                new int[] {row + 1, col},
                new int[] {row, col - 1},
                new int[] {row, col + 1}
        };

            foreach (var cell in adjacentCells)
            {
                var adjacentCellRow = cell[0];
                var adjacentCellCol = cell[1];

                if (adjacentCellRow >= 0 && adjacentCellRow < grid.Length &&
                    adjacentCellCol >= 0 && adjacentCellCol < grid[0].Length)
                {
                    var newCurrentScore = Math.Min(currentScore, grid[adjacentCellRow][adjacentCellCol]);
                    if (!VisitedCells.Contains((adjacentCellRow, adjacentCellCol, newCurrentScore)))
                    {
                        VisitedCells.Add((adjacentCellRow, adjacentCellCol, newCurrentScore));
                        if (adjacentCellRow == grid.Length - 1 &&
                            adjacentCellCol == grid[0].Length - 1 &&
                            newCurrentScore > middle)
                        {
                            return true;
                        }

                        if (Dfs(grid, adjacentCellRow, adjacentCellCol, middle, newCurrentScore))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}