namespace ConsoleApp1.BFS;

// Use hashSet slower than Dictionary ?
[LastVisited(2022, 12, 05)]
public class _1197
{
    public int MinKnightMoves(int x, int y)
    {
        var queue = new Queue<int[]>();
        queue.Enqueue(new int[] { 0, 0 });
        var numOfCellsInCurrentLevel = 1;
        var currentLevel = 0;
        var visitedCells = new HashSet<(int x, int y)> { (0, 0) };

        while (queue.Any())
        {
            var currentCell = queue.Dequeue();
            var currentCellX = currentCell[0];
            var currentCellY = currentCell[1];

            if (currentCellX == x && currentCellY == y)
            {
                return currentLevel;
            }

            var nextCells = new int[][] {
                new int[] {currentCellX - 2, currentCellY - 1},
                new int[] {currentCellX + 2, currentCellY - 1},
                new int[] {currentCellX - 1, currentCellY - 2},
                new int[] {currentCellX + 1, currentCellY - 2},
                new int[] {currentCellX - 2, currentCellY + 1},
                new int[] {currentCellX + 2, currentCellY + 1},
                new int[] {currentCellX - 1, currentCellY + 2},
                new int[] {currentCellX + 1, currentCellY + 2},
            };

            foreach (var nextCell in nextCells)
            {
                if (visitedCells.Add((nextCell[0], nextCell[1])))
                {
                    queue.Enqueue(nextCell);
                }
            }

            numOfCellsInCurrentLevel--;
            if (numOfCellsInCurrentLevel == 0)
            {
                numOfCellsInCurrentLevel = queue.Count;
                currentLevel++;
            }
        }

        return currentLevel;

    }

    public HashSet<(int x, int y)> IsVisitedHashSet { get; set; } = new HashSet<(int x, int y)>();

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int MinMoves { get; set; }

    public int[] EndCell { get; set; }

    public int MinKnightMoves2(int x, int y)
    {
        EndCell = new[] { x, y };
        Bfs(0, 0);
        return MinMoves;
    }

    private void Bfs(int rowStartIndex, int colStartIndex)
    {
        BfsQueue.Enqueue(new[] { rowStartIndex, colStartIndex });
        IsVisitedHashSet.Add((rowStartIndex, colStartIndex));
        var currentLevel = -1;

        while (BfsQueue.Count > 0)
        {
            var numberOfCellsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numberOfCellsInCurrentLevel; i++)
            {
                var currentPosition = BfsQueue.Dequeue();
                var rowIndex = currentPosition[0];
                var colIndex = currentPosition[1];

                if (rowIndex == EndCell[0] && colIndex == EndCell[1])
                {
                    MinMoves = currentLevel;
                    return;
                }

                var possibleKnightMoves = new[]
                {
                    new[] { rowIndex - 2, colIndex - 1 },
                    new[] { rowIndex - 1, colIndex - 2 },
                    new[] { rowIndex - 2, colIndex + 1 },
                    new[] { rowIndex - 1, colIndex + 2 },
                    new[] { rowIndex + 1, colIndex - 2 },
                    new[] { rowIndex + 2, colIndex - 1 },
                    new[] { rowIndex + 1, colIndex + 2 },
                    new[] { rowIndex + 2, colIndex + 1 }
                };

                foreach (var possibleKnightMove in possibleKnightMoves)
                {
                    if (IsVisitedHashSet.Add((possibleKnightMove[0], possibleKnightMove[1])))
                    {
                        BfsQueue.Enqueue(possibleKnightMove);
                    }
                }
            }
        }
    }
}