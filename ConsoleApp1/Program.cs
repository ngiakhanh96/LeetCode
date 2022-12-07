global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;
using System.Text;

var a = SlidingPuzzle(new[]
{
    new[] {1,2,3},
    new[] {4,0,5}
});
static int SlidingPuzzle(int[][] board)
{
    var queue = new Queue<string>();
    var numOfNodesInCurrentLevel = 1;
    var currentLevel = 0;
    var initialState = new StringBuilder();
    for (var i = 0; i < board.Length; i++)
    {
        for (var j = 0; j < board[0].Length; j++)
        {
            initialState.Append(board[i][j].ToString());
        }
    }
    queue.Enqueue(initialState.ToString());
    var visited = new HashSet<string> { initialState.ToString() };
    var endState = "123450";

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
                    var temp = nextState[i];
                    nextState[i - 3] = temp;
                    nextState[i] = nextState[i - 3];
                    nextStates.Add(new string(nextState));
                }
                else
                {
                    var nextState = currentState.ToCharArray();
                    var temp = nextState[i];
                    nextState[i + 3] = temp;
                    nextState[i] = nextState[i + 3];
                    nextStates.Add(new string(nextState));
                }

                if (i is 1 or 4)
                {
                    var nextState = currentState.ToCharArray();
                    var temp = nextState[i];
                    nextState[i - 1] = temp;
                    nextState[i] = nextState[i - 1];
                    nextStates.Add(new string(nextState));

                    nextState = currentState.ToCharArray();
                    temp = nextState[i];
                    nextState[i + 1] = temp;
                    nextState[i] = nextState[i + 1];
                    nextStates.Add(new string(nextState));
                }
                else if (i is 0 or 3)
                {
                    var nextState = currentState.ToCharArray();
                    var temp = nextState[i];
                    nextState[i + 1] = temp;
                    nextState[i] = nextState[i + 1];
                    nextStates.Add(new string(nextState));
                }
                else
                {
                    var nextState = currentState.ToCharArray();
                    var temp = nextState[i];
                    nextState[i - 1] = temp;
                    nextState[i] = nextState[i - 1];
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
}



//public class NumMatrix
//{
//    private HashSet<(int x, int y, int z)> VisitedCells = new HashSet<(int x, int y, int z)>();
//    public int MaximumMinimumPath(int[][] grid)
//    {

//        var low = int.MaxValue;
//        var high = int.MinValue;

//        for (var i = 0; i < grid.Length; i++)
//        {
//            for (var j = 0; j < grid[0].Length; j++)
//            {
//                low = Math.Min(low, grid[i][j]);
//                high = Math.Max(high, grid[i][j]);
//            }
//        }

//        while (low < high)
//        {
//            var middle = low + (high - low) / 2;

//            var canDfs = CanDfs(grid, middle, high);
//            Console.WriteLine(low);
//            Console.WriteLine(high);
//            Console.WriteLine("-----------------");
//            if (canDfs)
//            {
//                low = middle + 1;
//            }
//            else
//            {
//                high = middle;
//            }
//        }

//        return low;
//    }

//    private bool CanDfs(int[][] grid, int middle, int high)
//    {
//        VisitedCells.Clear();
//        VisitedCells.Add((0, 0, grid[0][0]));
//        return Dfs(grid, 0, 0, middle, grid[0][0]);

//    }

//    private bool Dfs(int[][] grid, int row, int col, int middle, int currentScore)
//    {
//        var adjacentCells = new[]
//        {
//            new[] {row - 1, col},
//            new[] {row + 1, col},
//            new[] {row, col - 1},
//            new[] {row, col + 1}
//    };

//        foreach (var cell in adjacentCells)
//        {
//            var adjacentCellRow = cell[0];
//            var adjacentCellCol = cell[1];

//            if (adjacentCellRow >= 0 && adjacentCellRow < grid.Length &&
//                adjacentCellCol >= 0 && adjacentCellCol < grid[0].Length)
//            {
//                var newCurrentScore = Math.Min(currentScore, grid[adjacentCellRow][adjacentCellCol]);
//                if (!VisitedCells.Contains((adjacentCellRow, adjacentCellCol, newCurrentScore)))
//                {
//                    VisitedCells.Add((adjacentCellRow, adjacentCellCol, newCurrentScore));
//                    if (adjacentCellRow == grid.Length - 1 &&
//                        adjacentCellCol == grid[0].Length - 1 &&
//                        newCurrentScore > middle)
//                    {
//                        return true;
//                    }

//                    if (Dfs(grid, adjacentCellRow, adjacentCellCol, middle, newCurrentScore))
//                    {
//                        return true;
//                    }
//                }
//            }
//        }

//        return false;
//    }
//}