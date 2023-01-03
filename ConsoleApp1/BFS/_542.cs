namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 08)]
public class _542
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        var queue = new Queue<int[]>();
        var numberOfNodesInCurrentLevel = 0;
        var currentLevel = 0;
        var visited = new bool[mat.Length, mat[0].Length];
        var result = new int[mat.Length][];

        for (var i = 0; i < mat.Length; i++)
        {
            result[i] = new int[mat[0].Length];
            for (var j = 0; j < mat[0].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    queue.Enqueue(new int[] { i, j });
                    visited[i, j] = true;
                    numberOfNodesInCurrentLevel++;
                }
            }
        }

        while (queue.Any())
        {
            var currentCell = queue.Dequeue();
            var x = currentCell[0];
            var y = currentCell[1];

            result[x][y] = currentLevel;
            var adjCells = new[] {
                new[] {x - 1, y},
                new[] {x, y - 1},
                new[] {x + 1, y},
                new[] {x, y + 1}
            };

            foreach (var adjCell in adjCells)
            {
                var nextCellX = adjCell[0];
                var nextCellY = adjCell[1];
                if (nextCellX >= 0 && nextCellX < mat.Length &&
                    nextCellY >= 0 && nextCellY < mat[0].Length &&
                    !visited[nextCellX, nextCellY])
                {
                    visited[nextCellX, nextCellY] = true;
                    queue.Enqueue(new int[] { nextCellX, nextCellY });
                }
            }

            if (--numberOfNodesInCurrentLevel == 0)
            {
                numberOfNodesInCurrentLevel = queue.Count;
                currentLevel++;
            }
        }

        return result;
    }
}