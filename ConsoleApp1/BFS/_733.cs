namespace ConsoleApp1.BFS;

[LastVisited(2023, 08, 17)]
public class _733
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var bfsQueue = new Queue<(int, int)>();
        bfsQueue.Enqueue((sr, sc));
        var visited = new bool[image.Length, image[0].Length];
        visited[sr, sc] = true;
        var val = image[sr][sc];
        while (bfsQueue.Count > 0)
        {
            var (currentCellX, currentCellY) = bfsQueue.Dequeue();
            image[currentCellX][currentCellY] = color;

            var nextCells = new int[][] {
                new[] {currentCellX + 1, currentCellY},
                new[] {currentCellX - 1, currentCellY},
                new[] {currentCellX, currentCellY + 1},
                new[] {currentCellX, currentCellY - 1},
            };

            foreach (var nextCell in nextCells)
            {
                var nextCellX = nextCell[0];
                var nextCellY = nextCell[1];
                if (nextCellX >= 0 && nextCellX < image.Length &&
                    nextCellY >= 0 && nextCellY < image[0].Length &&
                    !visited[nextCellX, nextCellY] &&
                    image[nextCellX][nextCellY] == val)
                {
                    bfsQueue.Enqueue((nextCellX, nextCellY));
                    visited[nextCellX, nextCellY] = true;
                }
            }
        }

        return image;
    }
}