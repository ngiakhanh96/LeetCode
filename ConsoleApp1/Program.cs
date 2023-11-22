global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;
using ConsoleApp1.Tree;
using ConsoleApp1.Tree.DFS;

var a = (Action test, string te) => () =>
{
    Console.WriteLine(te + " Start");
    test?.Invoke();
    Console.WriteLine(te + " End");
};

var a1 = a(null, "c");
var a2 = a(a1, "b");
a(a2, "a")();

a(a(a(null, "c"), "b"), "a")();


var t = new _145().PostorderTraversal2(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))));

int MaximizeSweetness(int[] v, int k)
{
    var averageSweetness = (double)v.Sum() / (k + 1);
    var currentSweetness = 0;
    var minSweetness = int.MaxValue;
    var maxChunksPerPerson = v.Length - (k + 1) + 1;
    var currentChunk = 0;
    foreach (var sweetness in v)
    {
        if (currentChunk + 1 > maxChunksPerPerson)
        {
            minSweetness = Math.Min(minSweetness, currentSweetness);
            currentSweetness = sweetness;
            currentChunk = 1;
        }
        else
        {
            if (currentSweetness + sweetness >= averageSweetness)
            {
                if (Math.Abs(currentSweetness - averageSweetness) < Math.Abs(currentSweetness + sweetness - averageSweetness))
                {
                    minSweetness = Math.Min(minSweetness, currentSweetness);
                    currentSweetness = sweetness;
                    currentChunk = 1;
                }
                else
                {
                    minSweetness = Math.Min(minSweetness, currentSweetness + sweetness);
                    currentSweetness = 0;
                    currentChunk = 0;
                }
            }
            else
            {
                currentSweetness += sweetness;
                currentChunk++;
            }
        }

    }
    minSweetness = currentSweetness > 0 ? Math.Min(currentSweetness, minSweetness) : minSweetness;
    return minSweetness;
}

var tFourSum = FourSum(new int[] { 2, 2, 2, 2 }, 8);
IList<IList<int>> FourSum(int[] nums, int target)
{
    Array.Sort(nums);
    var k = 4;
    return kSum(nums, target, 4, 0);
}

IList<IList<int>> kSum(int[] nums, int target, int k, int start)
{
    var result = new List<IList<int>>();
    if (k == 2)
    {
        return TwoSum(nums, target, start);
    }
    else
    {
        /*if (start > 0 && nums[start] == nums[start - 1]) {
            return kSum(nums, target - nums[start], k, start + 1);
        }*/
        for (var i = start; i < nums.Length - (k - 1); i++)
        {
            var lists = kSum(nums, target - nums[i], k - 1, i + 1);
            foreach (var list in lists)
            {
                list.Add(nums[i]);
                result.Add(list);
            }
        }
    }
    return result;
}

List<IList<int>> TwoSum(int[] nums, int target, int start)
{
    var result = new List<IList<int>>();
    var pointer1 = start;
    var pointer2 = nums.Length - 1;
    while (pointer1 < pointer2)
    {
        if (pointer1 > start && nums[pointer1] == nums[pointer1 - 1])
        {
            pointer1++;
            continue;
        }
        if (pointer2 < nums.Length - 1 && nums[pointer2] == nums[pointer2 + 1])
        {
            pointer2--;
            continue;
        }
        if ((long)nums[pointer1] + nums[pointer2] == target)
        {
            result.Add(new List<int> { nums[pointer1], nums[pointer2] });
            pointer1++;
            pointer2--;
        }
        else if ((long)nums[pointer1] + nums[pointer2] < target)
        {
            pointer1++;
        }
        else
        {
            pointer2--;
        }
    }
    return result;
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