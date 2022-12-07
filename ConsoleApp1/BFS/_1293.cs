namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 08)]
public class _1293
{
    public int ShortestPath(int[][] grid, int k)
    {
        if (k == 0 && grid[0][0] == 1)
        {
            return -1;
        }
        var queue = new Queue<int[]>();
        queue.Enqueue(new[] { 0, 0, k });
        var numOfNodesInCurrentLevel = 1;
        var currentLevel = 0;
        var visited = new bool[grid.Length, grid[0].Length, k + 1];
        visited[0, 0, k] = true;

        while (queue.Any())
        {
            var currentCell = queue.Dequeue();
            var currentCellX = currentCell[0];
            var currentCellY = currentCell[1];
            if (currentCellX == grid.Length - 1 && currentCellY == grid[0].Length - 1)
            {
                return currentLevel;
            }

            var adjCells = new[] {
                new[]{currentCellX - 1, currentCellY},
                new[]{currentCellX + 1, currentCellY},
                new[]{currentCellX, currentCellY - 1},
                new[]{currentCellX, currentCellY + 1},
            };

            foreach (var adjCell in adjCells)
            {
                var adjCellX = adjCell[0];
                var adjCellY = adjCell[1];
                if (adjCellX >= 0 && adjCellX < grid.Length &&
                    adjCellY >= 0 && adjCellY < grid[0].Length)
                {
                    var bombs = currentCell[2];
                    if (grid[adjCellX][adjCellY] == 1)
                    {
                        bombs--;
                    }

                    if (bombs >= 0 && !visited[adjCellX, adjCellY, bombs])
                    {
                        visited[adjCellX, adjCellY, bombs] = true;
                        queue.Enqueue(new[] { adjCellX, adjCellY, bombs });
                    }
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

    public Queue<int[]> BfsQueue { get; set; } = new();

    public bool[,,] Visited { get; set; }

    public int MinSteps { get; set; } = -1;

    public int[][] Grid { get; set; }

    public int ShortestPath2(int[][] grid, int k)
    {
        Grid = grid;
        Visited = new bool[grid.Length, grid[0].Length, k + 1];
        Bfs(0, 0, k);
        return MinSteps;
    }

    private void Bfs(int startRowIndex, int startColIndex, int k)
    {
        var startCell = new[] { startRowIndex, startColIndex, k };
        var currentBomb = startCell[2];
        if (Grid[startRowIndex][startColIndex] == 1 && currentBomb > 0)
        {
            BfsQueue.Enqueue(new[] { startRowIndex, startColIndex, currentBomb - 1 });
            Visited[startRowIndex, startColIndex, currentBomb - 1] = true;
        }
        else if (Grid[startRowIndex][startColIndex] == 0)
        {
            BfsQueue.Enqueue(new[] { startRowIndex, startColIndex, currentBomb });
            Visited[startRowIndex, startColIndex, currentBomb] = true;
        }
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numCellsInCurrentLevel = BfsQueue.Count;
            currentLevel++;

            for (var i = 0; i < numCellsInCurrentLevel; i++)
            {
                var cell = BfsQueue.Dequeue();

                var rowIndex = cell[0];
                var colIndex = cell[1];
                currentBomb = cell[2];

                if (rowIndex == Grid.Length - 1 && colIndex == Grid[0].Length - 1)
                {
                    MinSteps = currentLevel;
                    return;
                }

                var adjacentCells = new[]
                {
                    new[]{rowIndex - 1, colIndex},
                    new[]{rowIndex, colIndex - 1},
                    new[]{rowIndex + 1, colIndex},
                    new[]{rowIndex, colIndex + 1}
                };

                foreach (var adjacentCell in adjacentCells)
                {
                    if (adjacentCell[0] >= 0 &&
                        adjacentCell[0] <= Grid.Length - 1 &&
                        adjacentCell[1] >= 0 &&
                        adjacentCell[1] <= Grid[0].Length - 1)
                    {
                        if (Grid[adjacentCell[0]][adjacentCell[1]] == 1 &&
                            currentBomb > 0 &&
                            !Visited[adjacentCell[0], adjacentCell[1], currentBomb - 1])
                        {
                            BfsQueue.Enqueue(new[] { adjacentCell[0], adjacentCell[1], currentBomb - 1 });
                            Visited[adjacentCell[0], adjacentCell[1], currentBomb - 1] = true;
                        }
                        else if (Grid[adjacentCell[0]][adjacentCell[1]] == 0 &&
                                 !Visited[adjacentCell[0], adjacentCell[1], currentBomb])
                        {
                            BfsQueue.Enqueue(new[] { adjacentCell[0], adjacentCell[1], currentBomb });
                            Visited[adjacentCell[0], adjacentCell[1], currentBomb] = true;
                        }
                    }
                }
            }

        }
    }
}