global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var a = CanVisitAllRooms(new List<IList<int>>
        {
            new List<int>{1},
            new List<int>{2},
            new List<int>{3},
            new List<int>()
        });
    }

    public static bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visited = new HashSet<int> { 0 };
        Dfs(0, visited, rooms);
        return visited.Count == rooms.Count;
    }

    private static void Dfs(int roomNumber, HashSet<int> visited, IList<IList<int>> rooms)
    {
        foreach (var key in rooms[roomNumber])
        {
            if (!visited.Add(key))
            {
                Dfs(key, visited, rooms);
            }
        }
    }



    public class NumMatrix
    {
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
            var adjacentCells = new[]
            {
                new[] {row - 1, col},
                new[] {row + 1, col},
                new[] {row, col - 1},
                new[] {row, col + 1}
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