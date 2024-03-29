﻿namespace ConsoleApp1.DFS;

[LastVisited(2022, 11, 22)]
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

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
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
                adjacentCell[0] <= Grid.Length - 1 &&
                adjacentCell[1] >= 0 &&
                adjacentCell[1] <= Grid[0].Length - 1 &&
                Grid[adjacentCell[0]][adjacentCell[1]] == 1 &&
                !IsVisited[adjacentCell[0], adjacentCell[1]])
            {
                Dfs(adjacentCell[0], adjacentCell[1]);
            }
        }
    }
}