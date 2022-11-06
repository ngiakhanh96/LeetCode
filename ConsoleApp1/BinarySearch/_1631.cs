namespace ConsoleApp1.BinarySearch;

//Timeout ??
public class _1631
{
    public int[][] Heights { get; set; }

    public bool[,] IsVisitedCells { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int NumCellsInCurrentLevel { get; set; }

    public int MinimumEffortPath(int[][] heights)
    {
        Heights = heights;
        var minMinEffortPath = 0;
        var maxMinEffortPath = int.MinValue;
        foreach (var row in heights)
        {
            foreach (var val in row)
            {
                maxMinEffortPath = Math.Max(maxMinEffortPath, val);
            }
        }

        while (minMinEffortPath < maxMinEffortPath)
        {
            var midMinEffortPath = minMinEffortPath + (maxMinEffortPath - minMinEffortPath) / 2;
            if (Bfs(0, 0, midMinEffortPath))
            {
                maxMinEffortPath = midMinEffortPath;
            }
            else
            {
                minMinEffortPath = midMinEffortPath + 1;
            }
        }

        return minMinEffortPath;
    }

    private bool Bfs(int startRowIndex, int startColIndex, int targetMinEffortPath)
    {
        BfsQueue.Clear();
        IsVisitedCells = new bool[Heights.Length, Heights[0].Length];
        BfsQueue.Enqueue(new[] { startRowIndex, startColIndex, 0 });
        IsVisitedCells[startRowIndex, startColIndex] = true;
        while (BfsQueue.Count > 0)
        {
            NumCellsInCurrentLevel = BfsQueue.Count;
            for (var i = 0; i < NumCellsInCurrentLevel; i++)
            {
                var currentPosition = BfsQueue.Dequeue();

                var rowIndex = currentPosition[0];
                var colIndex = currentPosition[1];

                if (rowIndex == Heights.Length - 1 && colIndex == Heights[0].Length - 1)
                {
                    return true;
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
                        adjacentCell[0] <= Heights.Length - 1 &&
                        adjacentCell[1] >= 0 &&
                        adjacentCell[1] <= Heights[0].Length - 1 &&
                        !IsVisitedCells[adjacentCell[0], adjacentCell[1]])
                    {
                        var newMinEffortPath = Math.Abs(Heights[adjacentCell[0]][adjacentCell[1]] - Heights[rowIndex][colIndex]);
                        if (newMinEffortPath <= targetMinEffortPath)
                        {
                            BfsQueue.Enqueue(adjacentCell);
                            IsVisitedCells[adjacentCell[0], adjacentCell[1]] = true;
                        }
                    }
                }
            }

        }

        return false;
    }
}