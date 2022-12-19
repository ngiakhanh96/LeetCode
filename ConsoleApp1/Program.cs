global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;

var a = MaximizeSweetness(new[] { 93138, 60229, 11179, 91723, 85722, 58195, 95146, 85049, 33816 }, 5);
int _currentMaxScore = int.MinValue;
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