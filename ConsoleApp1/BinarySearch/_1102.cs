namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _1102
{
    public int MaximumMinimumPath(int[][] grid)
    {
        var minValue = int.MaxValue;
        var maxValue = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                minValue = Math.Min(grid[i][j], minValue);
                maxValue = Math.Max(grid[i][j], maxValue);
            }
        }

        var low = minValue;
        var high = maxValue;
        while (low < high)
        {
            var middle = low + (high - low + 1) / 2;
            var visited = new bool[grid.Length, grid[0].Length];
            if (grid[0][0] >= middle && Dfs(0, 0, grid[0][0], grid, visited, middle))
            {
                low = middle;
            }
            else
            {
                high = middle - 1;
            }
        }

        return low;
    }

    private bool Dfs(int row, int col, int score, int[][] grid, bool[,] visited, int middle)
    {
        if (row == grid.Length - 1 && col == grid[0].Length - 1)
        {
            return true;
        }
        visited[row, col] = true;
        var nextCells = new[]
        {
            new[] {row - 1, col},
            new[] {row, col - 1},
            new[] {row + 1, col},
            new[] {row, col + 1}
        };
        foreach (var nextCell in nextCells)
        {
            var nextCellX = nextCell[0];
            var nextCellY = nextCell[1];
            if (nextCellX >= 0 && nextCellX < grid.Length &&
                nextCellY >= 0 && nextCellY < grid[0].Length &&
                !visited[nextCellX, nextCellY])
            {
                var newScore = Math.Min(score, grid[nextCellX][nextCellY]);
                if (newScore >= middle &&
                    Dfs(nextCellX, nextCellY, newScore, grid, visited, middle))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public int MaximumMinimumPath2(int[][] grid)
    {
        var minMinPath = int.MaxValue;
        var maxMinPath = int.MinValue;
        foreach (var row in grid)
        {
            foreach (var col in row)
            {
                minMinPath = Math.Min(minMinPath, col);
                maxMinPath = Math.Max(maxMinPath, col);
            }
        }
        while (minMinPath < maxMinPath)
        {
            var midMinPath = minMinPath + (maxMinPath - minMinPath + 1) / 2;
            if (grid[0][0] >= midMinPath && Bfs(midMinPath, grid, grid[0][0]))
            {

                minMinPath = midMinPath;
            }
            else
            {
                maxMinPath = midMinPath - 1;
            }
        }

        return minMinPath;
    }

    private bool Bfs(int midMinPath, int[][] grid, int score)
    {
        var queue = new Queue<int[]>();
        queue.Enqueue(new[] { 0, 0 });
        var visited = new bool[grid.Length, grid[0].Length];
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            var currentNodeX = currentNode[0];
            var currentNodeY = currentNode[1];
            if (currentNodeX == grid.Length - 1 && currentNodeY == grid[0].Length - 1)
            {
                return true;
            }

            var nextCells = new[]
            {
                new[] {currentNodeX - 1, currentNodeY},
                new[] {currentNodeX, currentNodeY - 1},
                new[] {currentNodeX + 1, currentNodeY},
                new[] {currentNodeX, currentNodeY + 1}
            };
            foreach (var nextCell in nextCells)
            {
                var nextCellX = nextCell[0];
                var nextCellY = nextCell[1];
                if (nextCellX >= 0 && nextCellX < grid.Length &&
                    nextCellY >= 0 && nextCellY < grid[0].Length &&
                    !visited[nextCellX, nextCellY])
                {
                    var newScore = Math.Min(score, grid[nextCellX][nextCellY]);
                    if (newScore >= midMinPath)
                    {
                        visited[nextCellX, nextCellY] = true;
                        queue.Enqueue(nextCell);
                    }
                }
            }
        }

        return false;
    }
}