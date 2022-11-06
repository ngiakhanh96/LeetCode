namespace ConsoleApp1.BFS;

public class _542
{
    public int[][] DistanceToNearest0s { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public bool[][] Visited { get; set; }

    public int[][] InputMatrix { get; set; }

    public int[][] UpdateMatrix(int[][] mat)
    {
        DistanceToNearest0s = new int[mat.Length][];
        Visited = new bool[mat.Length][];
        InputMatrix = mat;

        Bfs(mat);
        return DistanceToNearest0s;
    }

    private void Bfs(int[][] mat)
    {
        for (var rowIndex = 0; rowIndex < mat.Length; rowIndex++)
        {
            DistanceToNearest0s[rowIndex] ??= new int[mat[rowIndex].Length];

            Visited[rowIndex] ??= new bool[mat[rowIndex].Length];

            for (var colIndex = 0; colIndex < mat[rowIndex].Length; colIndex++)
            {
                if (mat[rowIndex][colIndex] == 0)
                {
                    BfsQueue.Enqueue(new[] { rowIndex, colIndex });
                }
            }
        }

        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numOfCellsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numOfCellsInCurrentLevel; i++)
            {
                var cell = BfsQueue.Dequeue();
                var rowIndex = cell[0];
                var colIndex = cell[1];

                if (InputMatrix[rowIndex][colIndex] == 1)
                {
                    DistanceToNearest0s[rowIndex][colIndex] = currentLevel;
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
                        adjacentCell[0] <= InputMatrix.Length - 1 &&
                        adjacentCell[1] >= 0 &&
                        adjacentCell[1] <= InputMatrix[0].Length - 1 &&
                        InputMatrix[adjacentCell[0]][adjacentCell[1]] == 1 &&
                        !Visited[adjacentCell[0]][adjacentCell[1]])
                    {
                        BfsQueue.Enqueue(adjacentCell);
                        Visited[adjacentCell[0]][adjacentCell[1]] = true;
                    }
                }
            }
        }
    }
}