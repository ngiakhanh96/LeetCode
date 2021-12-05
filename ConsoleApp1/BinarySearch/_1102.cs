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
        BfsQueue.Enqueue(new int[] { 0, 0 });

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

                var adjacentCells = new int[][]
                {
                    new int[] { rowIndex - 1, colIndex },
                    new int[] { rowIndex, colIndex - 1 },
                    new int[] { rowIndex + 1, colIndex },
                    new int[] { rowIndex, colIndex + 1 }
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
                        BfsQueue.Enqueue(new int[] { adjacentCell[0], adjacentCell[1] });
                        IsVisited[adjacentCell[0], adjacentCell[1]] = true;
                    }
                }
            }
        }

        return false;
    }
}