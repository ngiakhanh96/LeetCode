﻿namespace ConsoleApp1._2dArray;

public class _200
{
    public bool[,] IsVisited { get; set; }

    public char[][] Grid { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int NumIslands(char[][] grid)
    {
        IsVisited = new bool[grid.Length, grid[0].Length];
        Grid = grid;

        var count = 0;
        for (var i = 0; i < Grid.Length; i++)
        {
            for (int j = 0; j < Grid[i].Length; j++)
            {
                if (Grid[i][j] == '1' && !IsVisited[i, j])
                {
                    count++;
                    Dfs(i, j);
                }
            }
        }
        return count;

    }

    private void Dfs(int rowIndex, int colIndex)
    {
        IsVisited[rowIndex, colIndex] = true;
        if (rowIndex > 0 && Grid[rowIndex - 1][colIndex] == '1' && !IsVisited[rowIndex - 1, colIndex])
        {
            Dfs(rowIndex - 1, colIndex);
        }
        if (colIndex > 0 && Grid[rowIndex][colIndex - 1] == '1' && !IsVisited[rowIndex, colIndex - 1])
        {
            Dfs(rowIndex, colIndex - 1);
        }
        if (rowIndex < Grid.Length - 1 && Grid[rowIndex + 1][colIndex] == '1' && !IsVisited[rowIndex + 1, colIndex])
        {
            Dfs(rowIndex + 1, colIndex);
        }
        if (colIndex < Grid[0].Length - 1 && Grid[rowIndex][colIndex + 1] == '1' && !IsVisited[rowIndex, colIndex + 1])
        {
            Dfs(rowIndex, colIndex + 1);
        }
    }

    public int NumIslands2(char[][] grid)
    {
        IsVisited = new bool[grid.Length, grid[0].Length];
        Grid = grid;

        var count = 0;
        for (var i = 0; i < Grid.Length; i++)
        {
            for (int j = 0; j < Grid[i].Length; j++)
            {
                if (Grid[i][j] == '1' && !IsVisited[i, j])
                {
                    count++;
                    Bfs(i, j);
                }
            }
        }
        return count;

    }

    private void Bfs(int rowIndex, int colIndex)
    {
        BfsQueue.Enqueue(new int[] { rowIndex, colIndex });
        IsVisited[rowIndex, colIndex] = true;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }
        var currentPosition = BfsQueue.Dequeue();
        var rowIndex = currentPosition[0];
        var colIndex = currentPosition[1];

        if (rowIndex > 0 && Grid[rowIndex - 1][colIndex] == '1' && !IsVisited[rowIndex - 1, colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex });
            IsVisited[rowIndex - 1, colIndex] = true;
        }
        if (colIndex > 0 && Grid[rowIndex][colIndex - 1] == '1' && !IsVisited[rowIndex, colIndex - 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1 });
            IsVisited[rowIndex, colIndex - 1] = true;
        }
        if (rowIndex < Grid.Length - 1 && Grid[rowIndex + 1][colIndex] == '1' && !IsVisited[rowIndex + 1, colIndex])
        {
            BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex });
            IsVisited[rowIndex + 1, colIndex] = true;
        }
        if (colIndex < Grid[0].Length - 1 && Grid[rowIndex][colIndex + 1] == '1' && !IsVisited[rowIndex, colIndex + 1])
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1 });
            IsVisited[rowIndex, colIndex + 1] = true;
        }

        Bfs();
    }
}