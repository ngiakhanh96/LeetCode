namespace ConsoleApp1.BFS;

public class _1293
{
    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public bool[,,] Visited { get; set; }

    public int MinSteps { get; set; } = -1;

    public int[][] Grid { get; set; }

    public int ShortestPath(int[][] grid, int k)
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