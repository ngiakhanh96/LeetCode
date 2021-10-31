namespace ConsoleApp1._2dArray;

public class _1293
{
    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public HashSet<string> VisitedHashSet { get; set; } = new HashSet<string>();

    public int CurrentLevel { get; set; }

    public int NumOfCellsInCurrentLevel { get; set; }

    public int MinSteps { get; set; } = -1;

    public int[][] Grid { get; set; }

    public int ShortestPath(int[][] grid, int k)
    {
        Grid = grid;
        Bfs(0, 0, k);
        return MinSteps;
    }

    private void Bfs(int startRowIndex, int startColIndex, int k)
    {
        var startCell = new int[] { startRowIndex, startColIndex, k };
        var rowIndex = startCell[0];
        var colIndex = startCell[1];
        var currentBomb = startCell[2];
        if (Grid[rowIndex][colIndex] == 1 && currentBomb > 0)
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex, currentBomb - 1 });
            VisitedHashSet.Add($"{rowIndex},{colIndex},{currentBomb - 1}");
        }
        else if (Grid[rowIndex][colIndex] == 0)
        {
            BfsQueue.Enqueue(new int[] { rowIndex, colIndex, currentBomb });
            VisitedHashSet.Add($"{rowIndex},{colIndex},{currentBomb}");
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
        var currentBomb = cell[2];

        if (rowIndex == Grid.Length - 1 && colIndex == Grid[0].Length - 1)
        {
            MinSteps = CurrentLevel;
            return;
        }

        if (rowIndex > 0)
        {
            if (Grid[rowIndex - 1][colIndex] == 1 && currentBomb > 0 && !VisitedHashSet.Contains($"{rowIndex - 1},{colIndex},{currentBomb - 1}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex, currentBomb - 1 });
                VisitedHashSet.Add($"{rowIndex - 1},{colIndex},{currentBomb - 1}");
            }
            else if (Grid[rowIndex - 1][colIndex] == 0 && !VisitedHashSet.Contains($"{rowIndex - 1},{colIndex},{currentBomb}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex, currentBomb });
                VisitedHashSet.Add($"{rowIndex - 1},{colIndex},{currentBomb }");
            }
        }

        if (colIndex > 0)
        {
            if (Grid[rowIndex][colIndex - 1] == 1 && currentBomb > 0 && !VisitedHashSet.Contains($"{rowIndex},{colIndex - 1},{currentBomb - 1}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1, currentBomb - 1 });
                VisitedHashSet.Add($"{rowIndex},{colIndex - 1},{currentBomb - 1}");
            }
            else if (Grid[rowIndex][colIndex - 1] == 0 && !VisitedHashSet.Contains($"{rowIndex},{colIndex - 1},{currentBomb}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1, currentBomb });
                VisitedHashSet.Add($"{rowIndex},{colIndex - 1},{currentBomb }");
            }
        }

        if (rowIndex < Grid.Length - 1)
        {
            if (Grid[rowIndex + 1][colIndex] == 1 && currentBomb > 0 && !VisitedHashSet.Contains($"{rowIndex + 1},{colIndex},{currentBomb - 1}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex, currentBomb - 1 });
                VisitedHashSet.Add($"{rowIndex + 1},{colIndex},{currentBomb - 1}");
            }
            else if (Grid[rowIndex + 1][colIndex] == 0 && !VisitedHashSet.Contains($"{rowIndex + 1},{colIndex},{currentBomb}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex, currentBomb });
                VisitedHashSet.Add($"{rowIndex + 1},{colIndex},{currentBomb }");
            }
        }

        if (colIndex < Grid[0].Length - 1)
        {
            if (Grid[rowIndex][colIndex + 1] == 1 && currentBomb > 0 && !VisitedHashSet.Contains($"{rowIndex},{colIndex + 1},{currentBomb - 1}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1, currentBomb - 1 });
                VisitedHashSet.Add($"{rowIndex},{colIndex + 1},{currentBomb - 1}");
            }
            else if (Grid[rowIndex][colIndex + 1] == 0 && !VisitedHashSet.Contains($"{rowIndex},{colIndex + 1},{currentBomb}"))
            {
                BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1, currentBomb });
                VisitedHashSet.Add($"{rowIndex},{colIndex + 1},{currentBomb }");
            }
        }

        if (NumOfCellsInCurrentLevel == 0)
        {
            NumOfCellsInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
        }
        Bfs();
    }
}