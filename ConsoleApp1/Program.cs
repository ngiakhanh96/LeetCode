global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;

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


var a = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
public class NumMatrix
{
    private int[,] _prefixMatrix;
    public NumMatrix(int[][] matrix)
    {
        _prefixMatrix = new int[matrix.Length, matrix[0].Length];
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                _prefixMatrix[i, j] = (i >= 1 ? _prefixMatrix[i - 1, j] : 0) +
                                      (j >= 1 ? _prefixMatrix[i, j - 1] : 0) -
                                      (i >= 1 && j >= 1 ? _prefixMatrix[i - 1, j - 1] : 0) +
                                      matrix[i][j];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return _prefixMatrix[row2, col2] -
               (row1 >= 1 ? _prefixMatrix[row1 - 1, col2] : 0) -
               (col1 >= 1 ? _prefixMatrix[row2, col1 - 1] : 0) +
               (row1 >= 1 && col1 >= 1 ? _prefixMatrix[row1 - 1, col1 - 1] : 0);
    }
}
