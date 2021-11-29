namespace ConsoleApp1.BFS;

public class _1091
{
    public bool[,] IsVisited { get; set; }

    public int[][] Grid { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int ShortestClearPath { get; set; } = -1;

    public int ShortestPathBinaryMatrix(int[][] grid)
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
        BfsQueue.Enqueue(new int[] { rowStartIndex, colStartIndex });
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

                var adjacentCells = new int[][]
                {
                    new int[] { rowIndex - 1, colIndex },
                    new int[] { rowIndex, colIndex - 1 },
                    new int[] { rowIndex + 1, colIndex },
                    new int[] { rowIndex, colIndex + 1 },
                    new int[] { rowIndex - 1, colIndex - 1 },
                    new int[] { rowIndex - 1, colIndex + 1 },
                    new int[] { rowIndex + 1, colIndex - 1 },
                    new int[] { rowIndex + 1, colIndex + 1 }
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