namespace ConsoleApp1._2dArray
{
    //Timeout ??
    public class _1631
    {
        public int[][] Heights { get; set; }

        public HashSet<string> IsVisitedCells { get; set; } = new HashSet<string>();

        public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

        public int NumCellsInCurrentLevel { get; set; }

        public int MinimumEffortPath(int[][] heights)
        {
            Heights = heights;
            var minMinEffortPath = 0;
            var maxMinEffortPath = int.MinValue;
            foreach (var row in heights)
            {
                foreach (var val in row)
                {
                    maxMinEffortPath = Math.Max(maxMinEffortPath, val);
                }
            }

            while (minMinEffortPath < maxMinEffortPath)
            {
                var midMinEffortPath = minMinEffortPath + (maxMinEffortPath - minMinEffortPath) / 2;
                if (Bfs(0, 0, midMinEffortPath))
                {
                    maxMinEffortPath = midMinEffortPath;
                }
                else
                {
                    minMinEffortPath = midMinEffortPath + 1;
                }
            }

            return minMinEffortPath;
        }

        private bool Bfs(int startRowIndex, int startColIndex, int targetMinEffortPath)
        {
            BfsQueue.Clear();
            IsVisitedCells.Clear();
            BfsQueue.Enqueue(new int[] { startRowIndex, startColIndex, 0 });
            IsVisitedCells.Add($"{startRowIndex},{startColIndex},0");
            while (BfsQueue.Count > 0)
            {
                var currentPosition = BfsQueue.Dequeue();
                NumCellsInCurrentLevel--;

                var rowIndex = currentPosition[0];
                var colIndex = currentPosition[1];
                var currentMinEffortPath = currentPosition[2];

                if (rowIndex == Heights.Length - 1 && colIndex == Heights[0].Length - 1 &&
                    currentMinEffortPath <= targetMinEffortPath)
                {
                    return true;
                }

                if (rowIndex > 0)
                {
                    var newMinEffortPath = Math.Max(
                        Math.Abs(Heights[rowIndex - 1][colIndex] - Heights[rowIndex][colIndex]),
                        currentMinEffortPath);
                    if (newMinEffortPath <= targetMinEffortPath && !IsVisitedCells.Contains($"{rowIndex - 1},{colIndex},{newMinEffortPath}"))
                    {
                        BfsQueue.Enqueue(new int[] { rowIndex - 1, colIndex, newMinEffortPath });
                        IsVisitedCells.Add($"{rowIndex - 1},{colIndex},{newMinEffortPath}");
                    }
                }

                if (colIndex > 0)
                {
                    var newMinEffortPath = Math.Max(
                        Math.Abs(Heights[rowIndex][colIndex - 1] - Heights[rowIndex][colIndex]),
                        currentMinEffortPath);
                    if (newMinEffortPath <= targetMinEffortPath && !IsVisitedCells.Contains($"{rowIndex},{colIndex - 1},{newMinEffortPath}"))
                    {
                        BfsQueue.Enqueue(new int[] { rowIndex, colIndex - 1, newMinEffortPath });
                        IsVisitedCells.Add($"{rowIndex},{colIndex - 1},{newMinEffortPath}");
                    }
                }

                if (rowIndex < Heights.Length - 1)
                {
                    var newMinEffortPath = Math.Max(
                        Math.Abs(Heights[rowIndex + 1][colIndex] - Heights[rowIndex][colIndex]),
                        currentMinEffortPath);
                    if (newMinEffortPath <= targetMinEffortPath && !IsVisitedCells.Contains($"{rowIndex + 1},{colIndex},{newMinEffortPath}"))
                    {
                        BfsQueue.Enqueue(new int[] { rowIndex + 1, colIndex, newMinEffortPath });
                        IsVisitedCells.Add($"{rowIndex + 1},{colIndex},{newMinEffortPath}");
                    }
                }
                if (colIndex < Heights[0].Length - 1)
                {
                    var newMinEffortPath = Math.Max(
                        Math.Abs(Heights[rowIndex][colIndex + 1] - Heights[rowIndex][colIndex]),
                        currentMinEffortPath);
                    if (newMinEffortPath <= targetMinEffortPath && !IsVisitedCells.Contains($"{rowIndex},{colIndex + 1},{newMinEffortPath}"))
                    {
                        BfsQueue.Enqueue(new int[] { rowIndex, colIndex + 1, newMinEffortPath });
                        IsVisitedCells.Add($"{rowIndex},{colIndex + 1},{newMinEffortPath}");
                    }
                }


                if (NumCellsInCurrentLevel == 0)
                {
                    NumCellsInCurrentLevel = BfsQueue.Count;
                }
            }

            return false;
        }
    }
}
