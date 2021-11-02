namespace ConsoleApp1._2dArray;

public class _773
{
    public Queue<string> BfsQueue { get; set; } = new Queue<string>();

    public HashSet<string> VisitedHashSet { get; set; } = new HashSet<string>();

    public int MinMove { get; set; } = -1;

    public Dictionary<string, List<string>> AdjacentStatesDict { get; set; } =
        new Dictionary<string, List<string>>();

    public int SlidingPuzzle(int[][] board)
    {
        Bfs(board);
        return MinMove;
    }

    private List<string> BuildAdjacentStates(string state)
    {
        var adjacentStates = new List<string>();
        for (int i = 0; i < state.Length; i++)
        {
            if (state[i] == '0')
            {
                adjacentStates.Add(i % 3 == i
                    ? BuildAdjacentState(i, i % 3 + 3, state)
                    : BuildAdjacentState(i, i % 3, state));
                if (i == 1 || i == 2 || i == 4 || i == 5)
                {
                    adjacentStates.Add(BuildAdjacentState(i, i - 1, state));
                }

                if (i == 0 || i == 1 || i == 3 || i == 4)
                {
                    adjacentStates.Add(BuildAdjacentState(i, i + 1, state));
                }
            }
        }

        return adjacentStates;
    }

    private string BuildAdjacentState(int swapIndex1, int swapIndex2, string state)
    {
        var adjacentState = "";
        for (int j = 0; j < state.Length; j++)
        {
            if (j == swapIndex1)
            {
                adjacentState += state[swapIndex2];
            }
            else if (j == swapIndex2)
            {
                adjacentState += state[swapIndex1];
            }
            else
            {
                adjacentState += state[j];
            }
        }

        return adjacentState;
    }

    private void Bfs(int[][] board)
    {
        var beginState = "";
        foreach (var row in board)
        {
            foreach (var col in row)
            {
                beginState += col;
            }
        }
        BfsQueue.Enqueue(beginState);
        var currentLevel = -1;
        VisitedHashSet.Add(beginState);
        while (BfsQueue.Count > 0)
        {
            var numStatesInCurrentCell = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numStatesInCurrentCell; i++)
            {
                var state = BfsQueue.Dequeue();

                if (state == "123450")
                {
                    MinMove = currentLevel;
                    return;
                }

                var adjacentStates = BuildAdjacentStates(state);
                foreach (var adjacentState in adjacentStates)
                {
                    if (VisitedHashSet.Add(adjacentState))
                    {
                        BfsQueue.Enqueue(adjacentState);
                    }
                }
            }
        }
    }
}