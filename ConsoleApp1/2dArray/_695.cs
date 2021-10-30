namespace ConsoleApp1._2dArray;

public class _695
{
    public bool[,] IsVisited { get; set; }

    public int[][] Grid { get; set; }

    public int MaxArea { get; set; }

    public int CurrentArea { get; set; }

    public int MaxAreaOfIsland(int[][] grid)
    {
        Grid = grid;
        IsVisited = new bool[Grid.Length, Grid[0].Length];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (Grid[i][j] == 1 && !IsVisited[i, j])
                {
                    CurrentArea = 0;
                    Dfs(i, j);
                    MaxArea = Math.Max(MaxArea, CurrentArea);
                }
            }
        }
        return MaxArea;
    }

    private void Dfs(int rowIndex, int colIndex)
    {
        IsVisited[rowIndex, colIndex] = true;
        CurrentArea++;
        if (rowIndex > 0 && Grid[rowIndex - 1][colIndex] == 1 && !IsVisited[rowIndex - 1, colIndex])
        {
            Dfs(rowIndex - 1, colIndex);
        }
        if (colIndex > 0 && Grid[rowIndex][colIndex - 1] == 1 && !IsVisited[rowIndex, colIndex - 1])
        {
            Dfs(rowIndex, colIndex - 1);
        }
        if (rowIndex < Grid.Length - 1 && Grid[rowIndex + 1][colIndex] == 1 && !IsVisited[rowIndex + 1, colIndex])
        {
            Dfs(rowIndex + 1, colIndex);
        }
        if (colIndex < Grid[0].Length - 1 && Grid[rowIndex][colIndex + 1] == 1 && !IsVisited[rowIndex, colIndex + 1])
        {
            Dfs(rowIndex, colIndex + 1);
        }
    }
}