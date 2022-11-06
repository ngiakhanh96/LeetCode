namespace ConsoleApp1.BinarySearch;

public class _1102
{
    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public bool[,] IsVisited { get; set; }

    public int[][] Grid { get; set; }

    public int MaximumMinimumPath(int[][] grid)
    {
        Grid = grid;
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

        var res = 0;
        while (minMinPath <= maxMinPath)
        {
            var midMinPath = minMinPath + (maxMinPath - minMinPath) / 2;
            if (Bfs(midMinPath))
            {
                res = midMinPath;
                minMinPath = midMinPath + 1;
            }
            else
            {
                maxMinPath = midMinPath - 1;
            }
        }

        return res;
    }

    private bool Bfs(int midMinPath)
    {
        if (Grid[0][0] < midMinPath)
        {
            return false;
        }
        BfsQueue.Clear();
        IsVisited = new bool[Grid.Length, Grid[0].Length];
        IsVisited[0, 0] = true;
        BfsQueue.Enqueue(new[] { 0, 0 });

        while (BfsQueue.Count > 0)
        {
            var numOfCellsInCurrentLevel = BfsQueue.Count;
            for (var i = 0; i < numOfCellsInCurrentLevel; i++)
            {
                var cell = BfsQueue.Dequeue();
                var rowIndex = cell[0];
                var colIndex = cell[1];

                if (rowIndex == Grid.Length - 1 && colIndex == Grid[0].Length - 1)
                {
                    return true;
                }

                var adjacentCells = new[]
                {
                    new[] { rowIndex - 1, colIndex },
                    new[] { rowIndex, colIndex - 1 },
                    new[] { rowIndex + 1, colIndex },
                    new[] { rowIndex, colIndex + 1 }
                };

                foreach (var adjacentCell in adjacentCells)
                {

                    if (adjacentCell[0] >= 0 &&
                        adjacentCell[0] <= Grid.Length - 1 &&
                        adjacentCell[1] >= 0 &&
                        adjacentCell[1] <= Grid[0].Length - 1 &&
                        !IsVisited[adjacentCell[0], adjacentCell[1]] &&
                        Grid[adjacentCell[0]][adjacentCell[1]] >= midMinPath)
                    {
                        BfsQueue.Enqueue(new[] { adjacentCell[0], adjacentCell[1] });
                        IsVisited[adjacentCell[0], adjacentCell[1]] = true;
                    }
                }
            }
        }

        return false;
    }

    // Dfs version
    private HashSet<(int x, int y)> VisitedCells = new HashSet<(int x, int y)>();
    public int MaximumMinimumPath2(int[][] grid)
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
        if (grid[0][0] <= middle)
        {
            return false;
        }
        VisitedCells.Clear();
        VisitedCells.Add((0, 0));
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
                adjacentCellCol >= 0 && adjacentCellCol < grid[0].Length &&
                !VisitedCells.Contains((adjacentCellRow, adjacentCellCol)))
            {
                var newCurrentScore = Math.Min(currentScore, grid[adjacentCellRow][adjacentCellCol]);
                if (newCurrentScore > middle)
                {
                    VisitedCells.Add((adjacentCellRow, adjacentCellCol));
                    if (adjacentCellRow == grid.Length - 1 &&
                        adjacentCellCol == grid[0].Length - 1)
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