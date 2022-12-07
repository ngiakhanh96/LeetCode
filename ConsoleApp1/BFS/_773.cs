using System.Text;

namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 08)]
public class _773
{
    public int SlidingPuzzle(int[][] board)
    {
        var queue = new Queue<string>();
        var numOfNodesInCurrentLevel = 1;
        var currentLevel = 0;
        var initialState = new StringBuilder();
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[0].Length; j++)
            {
                initialState.Append(board[i][j]);
            }
        }
        queue.Enqueue(initialState.ToString());
        var visited = new HashSet<string> { initialState.ToString() };
        const string endState = "123450";

        while (queue.Any())
        {
            var currentState = queue.Dequeue();
            if (currentState == endState)
            {
                return currentLevel;
            }

            var nextStates = new List<string>();
            for (var i = 0; i < currentState.Length; i++)
            {
                if (currentState[i] == '0')
                {
                    if (i > 2)
                    {
                        var nextState = currentState.ToCharArray();
                        Swap(i, i - 3, nextState);
                        nextStates.Add(new string(nextState));
                    }
                    else
                    {
                        var nextState = currentState.ToCharArray();
                        Swap(i, i + 3, nextState);
                        nextStates.Add(new string(nextState));
                    }

                    if (i is 1 or 4)
                    {
                        var nextState = currentState.ToCharArray();
                        Swap(i, i - 1, nextState);
                        nextStates.Add(new string(nextState));

                        nextState = currentState.ToCharArray();
                        Swap(i, i + 1, nextState);
                        nextStates.Add(new string(nextState));
                    }
                    else if (i is 0 or 3)
                    {
                        var nextState = currentState.ToCharArray();
                        Swap(i, i + 1, nextState);
                        nextStates.Add(new string(nextState));
                    }
                    else
                    {
                        var nextState = currentState.ToCharArray();
                        Swap(i, i - 1, nextState);
                        nextStates.Add(new string(nextState));
                    }
                    break;
                }
            }

            foreach (var nextState in nextStates)
            {
                if (visited.Add(nextState))
                {
                    queue.Enqueue(nextState);
                }
            }


            if (--numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                currentLevel++;
            }
        }
        return -1;

        void Swap(int initialPos, int secondPos, char[] chrArr)
        {
            (chrArr[initialPos], chrArr[secondPos]) = (chrArr[secondPos], chrArr[initialPos]);
        }
    }

    public Queue<string> BfsQueue { get; set; } = new();

    public HashSet<string> VisitedHashSet { get; set; } = new();

    public int MinMove { get; set; } = -1;

    public Dictionary<string, List<string>> AdjacentStatesDict { get; set; } = new();

    public int SlidingPuzzle2(int[][] board)
    {
        Bfs(board);
        return MinMove;
    }

    private List<string> BuildAdjacentStates(string state)
    {
        var adjacentStates = new List<string>();
        for (var i = 0; i < state.Length; i++)
        {
            if (state[i] == '0')
            {
                adjacentStates.Add(i % 3 == i
                    ? BuildAdjacentState(i, i % 3 + 3, state)
                    : BuildAdjacentState(i, i % 3, state));
                if (i is 1 or 2 or 4 or 5)
                {
                    adjacentStates.Add(BuildAdjacentState(i, i - 1, state));
                }

                if (i is 0 or 1 or 3 or 4)
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
        for (var j = 0; j < state.Length; j++)
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