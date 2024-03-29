﻿namespace ConsoleApp1.DFS;

[LastVisited(2022, 11, 22)]
public class _200
{
    public bool[,] IsVisited { get; set; }

    public char[][] Grid { get; set; }

    public Queue<int[]> BfsQueue { get; set; } = new();

    public int NumIslands(char[][] grid)
    {
        IsVisited = new bool[grid.Length, grid[0].Length];
        Grid = grid;

        var count = 0;
        for (var i = 0; i < Grid.Length; i++)
        {
            for (var j = 0; j < Grid[i].Length; j++)
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
                Grid[adjacentCell[0]][adjacentCell[1]] == '1' &&
                !IsVisited[adjacentCell[0], adjacentCell[1]])
            {
                Dfs(adjacentCell[0], adjacentCell[1]);
            }
        }
    }

    public int NumIslands2(char[][] grid)
    {
        IsVisited = new bool[grid.Length, grid[0].Length];
        Grid = grid;

        var count = 0;
        for (var i = 0; i < Grid.Length; i++)
        {
            for (var j = 0; j < Grid[i].Length; j++)
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
        BfsQueue.Enqueue(new[] { rowIndex, colIndex });
        IsVisited[rowIndex, colIndex] = true;
        while (BfsQueue.Count > 0)
        {
            var numAdjacentCellsInCurrentLevel = BfsQueue.Count;
            for (var i = 0; i < numAdjacentCellsInCurrentLevel; i++)
            {
                var currentPosition = BfsQueue.Dequeue();
                rowIndex = currentPosition[0];
                colIndex = currentPosition[1];

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
                        Grid[adjacentCell[0]][adjacentCell[1]] == '1' &&
                        !IsVisited[adjacentCell[0], adjacentCell[1]])
                    {
                        BfsQueue.Enqueue(adjacentCell);
                        IsVisited[adjacentCell[0], adjacentCell[1]] = true;
                    }
                }
            }
        }
    }

    public int NumIslands3(char[][] grid)
    {
        Grid = grid;

        var unionFind = new UnionFind<char>(grid, ele => ele == '1');
        for (var i = 0; i < Grid.Length; i++)
        {
            for (var j = 0; j < Grid[0].Length; j++)
            {
                if (Grid[i][j] == '1')
                {
                    var adjacentCells = new[]
                    {
                        new[] { i - 1, j },
                        new[] { i, j - 1 },
                        new[] { i + 1, j },
                        new[] { i, j + 1 }
                    };
                    foreach (var adjacentCell in adjacentCells)
                    {
                        if (adjacentCell[0] >= 0 &&
                            adjacentCell[0] <= Grid.Length - 1 &&
                            adjacentCell[1] >= 0 &&
                            adjacentCell[1] <= Grid[0].Length - 1 &&
                            Grid[adjacentCell[0]][adjacentCell[1]] == '1')
                        {
                            unionFind.TryUnion(i, j, adjacentCell[0], adjacentCell[1]);
                        }
                    }
                }
            }
        }
        return unionFind.Count;

    }
}