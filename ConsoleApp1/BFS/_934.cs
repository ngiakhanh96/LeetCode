namespace ConsoleApp1.BFS;

public class _934
{
    public Queue<(int x, int y)> BfsQueue { get; set; } = new Queue<(int x, int y)>();
    public HashSet<(int x, int y)> VisitedCell { get; set; } = new HashSet<(int x, int y)>();
    public int Distance { get; set; }
    public int[][] Grid { get; set; }
    public int ShortestBridge(int[][] grid)
    {
        Grid = grid;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == 1)
                {
                    Dfs(row, col);
                    break;
                }
            }

            if (VisitedCell.Count > 0)
            {
                break;
            }
        }

        foreach (var cell in VisitedCell)
        {
            BfsQueue.Enqueue(cell);
        }

        Bfs();
        return Distance;
    }

    private void Bfs()
    {
        while (BfsQueue.Any())
        {
            var numOfCellInCurrentLevel = BfsQueue.Count;
            for (int i = 0; i < numOfCellInCurrentLevel; i++)
            {
                var (row, col) = BfsQueue.Dequeue();
                var nextCells = new[]
                {
                    new[] {row-1, col},
                    new[] {row+1, col},
                    new[] {row, col-1},
                    new[] {row, col+1},
                };

                foreach (var nextCell in nextCells)
                {
                    var nextRow = nextCell[0];
                    var nextCol = nextCell[1];
                    if (nextRow >= 0 && nextRow < Grid.Length &&
                        nextCol >= 0 && nextCol < Grid[0].Length &&
                        !VisitedCell.Contains((nextRow, nextCol)))
                    {
                        if (Grid[nextRow][nextCol] == 1)
                        {
                            return;
                        }
                        VisitedCell.Add((nextRow, nextCol));
                        BfsQueue.Enqueue((nextRow, nextCol));
                    }
                }
            }
            Distance++;
        }
    }

    private void Dfs(int row, int col)
    {
        VisitedCell.Add((row, col));
        var nextCells = new[]
        {
            new[] {row-1, col},
            new[] {row+1, col},
            new[] {row, col-1},
            new[] {row, col+1},
        };

        foreach (var nextCell in nextCells)
        {
            var nextRow = nextCell[0];
            var nextCol = nextCell[1];
            if (nextRow >= 0 && nextRow < Grid.Length &&
                nextCol >= 0 && nextCol < Grid[0].Length &&
                Grid[nextRow][nextCol] == 1 &&
                !VisitedCell.Contains((nextRow, nextCol)))
            {
                Dfs(nextRow, nextCol);
            }
        }
    }
}