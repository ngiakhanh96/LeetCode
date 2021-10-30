namespace ConsoleApp1._2dArray;

public class _542
{
    public int[][] DistanceToNearest0s { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public bool[][] Visited { get; set; }

    public int CurrentLevel { get; set; }

    public int NumOfCellsInCurrentLevel { get; set; }

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
                    BfsQueue.Enqueue(new int[] { rowIndex, colIndex });
                }
            }
        }

        CurrentLevel = 0;
        NumOfCellsInCurrentLevel = BfsQueue.Count;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }

        var cell = BfsQueue.Dequeue();
        NumOfCellsInCurrentLevel--;
        var rowIndex = cell[0];
        var colIndex = cell[1];

        if (InputMatrix[rowIndex][colIndex] == 1)
        {
            DistanceToNearest0s[rowIndex][colIndex] = CurrentLevel;
        }

        if (rowIndex > 0 && InputMatrix[rowIndex - 1][colIndex] == 1 && !Visited[rowIndex - 1][colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex });
            Visited[rowIndex - 1][colIndex] = true;
        }

        if (rowIndex < InputMatrix.Length - 1 && InputMatrix[rowIndex + 1][colIndex] == 1 && !Visited[rowIndex + 1][colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex });
            Visited[rowIndex + 1][colIndex] = true;
        }

        if (colIndex > 0 && InputMatrix[rowIndex][colIndex - 1] == 1 && !Visited[rowIndex][colIndex - 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1 });
            Visited[rowIndex][colIndex - 1] = true;
        }

        if (colIndex < InputMatrix[rowIndex].Length - 1 && InputMatrix[rowIndex][colIndex + 1] == 1 && !Visited[rowIndex][colIndex + 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1 });
            Visited[rowIndex][colIndex + 1] = true;
        }

        if (NumOfCellsInCurrentLevel == 0)
        {
            NumOfCellsInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
        }
        Bfs();
    }
}