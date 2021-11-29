namespace ConsoleApp1.BFS;

// Use hashSet slower than Dictionary ?
public class _1197
{
    public Dictionary<int, Dictionary<int, bool>> IsVisitedDict = new Dictionary<int, Dictionary<int, bool>>();

    public HashSet<(int x, int y)> IsVisitedHashSet { get; set; } = new HashSet<(int x, int y)>();

    public Queue<int[]> BfsQueue { get; set; } = new Queue<int[]>();

    public int MinMoves { get; set; }

    public int[] EndCell { get; set; }

    public int MinKnightMoves(int x, int y)
    {
        EndCell = new int[] { x, y };
        Bfs(0, 0);
        return MinMoves;
    }

    private void Bfs(int rowStartIndex, int colStartIndex)
    {
        BfsQueue.Enqueue(new int[] { rowStartIndex, colStartIndex });
        //if (!IsVisitedDict.ContainsKey(rowStartIndex))
        //{
        //    IsVisitedDict[rowStartIndex] = new Dictionary<int, bool>();
        //}
        //if (!IsVisitedDict[rowStartIndex].ContainsKey(colStartIndex))
        //{
        //    IsVisitedDict[rowStartIndex][colStartIndex] = true;
        //}
        IsVisitedHashSet.Add((rowStartIndex, colStartIndex));
        var currentLevel = -1;

        while (BfsQueue.Count > 0)
        {
            var numberOfCellsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (int i = 0; i < numberOfCellsInCurrentLevel; i++)
            {
                var currentPosition = BfsQueue.Dequeue();
                var rowIndex = currentPosition[0];
                var colIndex = currentPosition[1];

                if (rowIndex == EndCell[0] && colIndex == EndCell[1])
                {
                    MinMoves = currentLevel;
                    return;
                }

                var possibleKnightMoves = new int[][]
                {
                    new int[] { rowIndex - 2, colIndex - 1 },
                    new int[] { rowIndex - 1, colIndex - 2 },
                    new int[] { rowIndex - 2, colIndex + 1 },
                    new int[] { rowIndex - 1, colIndex + 2 },
                    new int[] { rowIndex + 1, colIndex - 2 },
                    new int[] { rowIndex + 2, colIndex - 1 },
                    new int[] { rowIndex + 1, colIndex + 2 },
                    new int[] { rowIndex + 2, colIndex + 1 }
                };

                foreach (var possibleKnightMove in possibleKnightMoves)
                {
                    //if (!IsVisitedDict.ContainsKey(possibleKnightMove[0]))
                    //{
                    //    IsVisitedDict[possibleKnightMove[0]] = new Dictionary<int, bool>();
                    //}
                    //if (!IsVisitedDict[possibleKnightMove[0]].ContainsKey(possibleKnightMove[1]))
                    //{
                    //    BfsQueue.Enqueue(possibleKnightMove);
                    //    IsVisitedDict[possibleKnightMove[0]][possibleKnightMove[1]] = true;
                    //}
                    if (IsVisitedHashSet.Add((possibleKnightMove[0], possibleKnightMove[1])))
                    {
                        BfsQueue.Enqueue(possibleKnightMove);
                    }
                }
            }
        }
    }
}