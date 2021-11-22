namespace ConsoleApp1._2dArray;

public class _305
{
    public IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        var grid = new int[m, n];
        var unionFind = new UnionFind<int>(grid);
        var count = 0;
        var res = new List<int>();
        foreach (var position in positions)
        {
            if (grid[position[0], position[1]] == 1)
            {
                res.Add(count);
                continue;
            }

            count++;
            grid[position[0], position[1]] = 1;
            var adjacentCells = new int[][]
            {
                new int[] { position[0] - 1, position[1] },
                new int[] { position[0], position[1] - 1 },
                new int[] { position[0] + 1, position[1] },
                new int[] { position[0], position[1] + 1 }
            };
            foreach (var adjacentCell in adjacentCells)
            {
                if (adjacentCell[0] >= 0 &&
                    adjacentCell[0] <= m - 1 &&
                    adjacentCell[1] >= 0 &&
                    adjacentCell[1] <= n - 1 &&
                    grid[adjacentCell[0], adjacentCell[1]] == 1)
                {
                    if (unionFind.TryUnion(position[0], position[1], adjacentCell[0], adjacentCell[1]))
                    {
                        count--;
                    }
                }
            }

            res.Add(count);
        }
        return res;
    }
}