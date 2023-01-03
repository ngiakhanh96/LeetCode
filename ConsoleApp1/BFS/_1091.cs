namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 05)]
public class _1091
{
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1 || grid[grid.Length - 1][grid[0].Length - 1] == 1)
        {
            return -1;
        }

        var queue = new Queue<int[]>();
        queue.Enqueue(new[] { 0, 0 });
        var numOfNodesInCurrentLevel = 1;
        var currentLevel = 1;
        var visitedCells = new bool[grid.Length, grid[0].Length];
        visitedCells[0, 0] = true;

        while (queue.Any())
        {
            var currentCell = queue.Dequeue();
            var x = currentCell[0];
            var y = currentCell[1];
            if (x == grid.Length - 1 && y == grid[0].Length - 1)
            {
                return currentLevel;
            }

            var adjacentCells = new[]
            {
                new[]{x - 1, y},
                new[]{x, y - 1},
                new[]{x + 1, y},
                new[]{x, y + 1},
                new[]{x + 1, y + 1},
                new[]{x - 1, y - 1},
                new[]{x + 1, y - 1},
                new[]{x - 1, y + 1},
            };
            foreach (var adjCell in adjacentCells)
            {
                if (
                    adjCell[0] >= 0 && adjCell[0] < grid.Length &&
                    adjCell[1] >= 0 && adjCell[1] < grid[0].Length &&
                    !visitedCells[adjCell[0], adjCell[1]] &&
                    grid[adjCell[0]][adjCell[1]] == 0)
                {
                    visitedCells[adjCell[0], adjCell[1]] = true;
                    queue.Enqueue(adjCell);
                }
            }

            if (--numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                currentLevel++;
            }

        }

        return -1;
    }

    public bool[,] IsVisited { get; set; }

    public int[][] Grid { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new();

    public int ShortestClearPath { get; set; } = -1;

    public int ShortestPathBinaryMatrix2(int[][] grid)
    {
        IsVisited = new bool[grid.Length, grid[0].Length];
        Grid = grid;

        Bfs(0, 0);
        return ShortestClearPath;
    }

    private void Bfs(int rowStartIndex, int colStartIndex)
    {
        if (Grid[rowStartIndex][colStartIndex] == 1)
        {
            return;
        }
        BfsQueue.Enqueue(new[] { rowStartIndex, colStartIndex });
        IsVisited[rowStartIndex, colStartIndex] = true;
        var currentLevel = 0;

        while (BfsQueue.Count > 0)
        {
            var numCellsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numCellsInCurrentLevel; i++)
            {
                var currentPosition = BfsQueue.Dequeue();
                var rowIndex = currentPosition[0];
                var colIndex = currentPosition[1];

                if (rowIndex == Grid.Length - 1 && colIndex == Grid[0].Length - 1)
                {
                    ShortestClearPath = currentLevel;
                    return;
                }

                var adjacentCells = new[]
                {
                    new[] { rowIndex - 1, colIndex },
                    new[] { rowIndex, colIndex - 1 },
                    new[] { rowIndex + 1, colIndex },
                    new[] { rowIndex, colIndex + 1 },
                    new[] { rowIndex - 1, colIndex - 1 },
                    new[] { rowIndex - 1, colIndex + 1 },
                    new[] { rowIndex + 1, colIndex - 1 },
                    new[] { rowIndex + 1, colIndex + 1 }
                };

                foreach (var adjacentCell in adjacentCells)
                {
                    if (adjacentCell[0] >= 0 &&
                        adjacentCell[0] <= Grid.Length - 1 &&
                        adjacentCell[1] >= 0 &&
                        adjacentCell[1] <= Grid[0].Length - 1 &&
                        Grid[adjacentCell[0]][adjacentCell[1]] == 0 &&
                        !IsVisited[adjacentCell[0], adjacentCell[1]])
                    {
                        BfsQueue.Enqueue(adjacentCell);
                        IsVisited[adjacentCell[0], adjacentCell[1]] = true;
                    }
                }
            }
        }
    }
}