namespace ConsoleApp1._2dArray;

public class _1091
{
    public bool[,] IsVisited { get; set; }

    public int[][] Grid { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int CurrentLevel { get; set; }

    public int NumberOfCellsInCurrentLevel { get; set; }

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
        CurrentLevel = 1;
        NumberOfCellsInCurrentLevel = BfsQueue.Count;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }
        var currentPosition = BfsQueue.Dequeue();
        NumberOfCellsInCurrentLevel--;
        var rowIndex = currentPosition[0];
        var colIndex = currentPosition[1];

        if (rowIndex == Grid.Length - 1 && colIndex == Grid[0].Length - 1)
        {
            ShortestClearPath = CurrentLevel;
            return;
        }

        if (rowIndex > 0 && Grid[rowIndex - 1][colIndex] == 0 && !IsVisited[rowIndex - 1, colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex });
            IsVisited[rowIndex - 1, colIndex] = true;
        }
        if (colIndex > 0 && Grid[rowIndex][colIndex - 1] == 0 && !IsVisited[rowIndex, colIndex - 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1 });
            IsVisited[rowIndex, colIndex - 1] = true;
        }
        if (rowIndex < Grid.Length - 1 && Grid[rowIndex + 1][colIndex] == 0 && !IsVisited[rowIndex + 1, colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex });
            IsVisited[rowIndex + 1, colIndex] = true;
        }
        if (colIndex < Grid[0].Length - 1 && Grid[rowIndex][colIndex + 1] == 0 && !IsVisited[rowIndex, colIndex + 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1 });
            IsVisited[rowIndex, colIndex + 1] = true;
        }

        if (rowIndex > 0 && colIndex > 0 && Grid[rowIndex - 1][colIndex - 1] == 0 && !IsVisited[rowIndex - 1, colIndex - 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex - 1 });
            IsVisited[rowIndex - 1, colIndex - 1] = true;
        }

        if (rowIndex > 0 && colIndex < Grid[0].Length - 1 && Grid[rowIndex - 1][colIndex + 1] == 0 && !IsVisited[rowIndex - 1, colIndex + 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex + 1 });
            IsVisited[rowIndex - 1, colIndex + 1] = true;
        }

        if (rowIndex < Grid.Length - 1 && colIndex > 0 && Grid[rowIndex + 1][colIndex - 1] == 0 && !IsVisited[rowIndex + 1, colIndex - 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex - 1 });
            IsVisited[rowIndex + 1, colIndex - 1] = true;
        }

        if (rowIndex < Grid.Length - 1 && colIndex < Grid[0].Length - 1 && Grid[rowIndex + 1][colIndex + 1] == 0 && !IsVisited[rowIndex + 1, colIndex + 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex + 1 });
            IsVisited[rowIndex + 1, colIndex + 1] = true;
        }

        if (NumberOfCellsInCurrentLevel == 0)
        {
            NumberOfCellsInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
        }

        Bfs();
    }
}