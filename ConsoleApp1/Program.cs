global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;

int solution(int[] A)
{
    var t = A.Where(p => p > 0).Distinct().ToList();
    t.Sort();
    if (t.Count == 0)
    {
        return 1;
    }

    if (t.Count == 1)
    {
        return t.First() == 1 ? 2 : 1;
    }

    if (t.First() > 1)
    {
        return 1;
    }

    var previousNumber = t[0];
    for (var i = 1; i < t.Count; i++)
    {
        if (t[i] == previousNumber + 1)
        {
            previousNumber = t[i];
        }
        else
        {
            return previousNumber + 1;
        }
    }

    return t.Last() + 1;
}

var c = Calculate("0-2147483647");
int Calculate(string s)
{
    s += ".";
    var stack = new Stack<string>();
    var highPriorityDict = new Dictionary<char, Func<int, int, int>>{
        {'*', (a, b) => a * b},
        {'/', (a, b) => a / b}
    };
    var lowPriorityDict = new Dictionary<char, Func<int, int, int>>{
        {'+', (a, b) => a + b},
        {'-', (a, b) => a - b},
    };
    var currentNumber = 0;
    foreach (var token in s)
    {
        if (token == ' ')
        {
            continue;
        }
        if (char.IsDigit(token))
        {
            currentNumber = currentNumber * 10 + token - '0';
        }
        else
        {
            if (stack.Count > 0 && highPriorityDict.TryGetValue(stack.Peek()[0], out var function))
            {
                stack.Pop();
                var number1 = stack.Pop();
                var result = function(int.Parse(number1), currentNumber);
                stack.Push(result.ToString());
            }
            else
            {
                stack.Push(currentNumber.ToString());
            }
            if (token != '.')
            {
                stack.Push(token.ToString());
            }

            currentNumber = 0;
        }
    }
    var reversedStack = new Stack<string>();
    while (stack.Count > 0)
    {
        reversedStack.Push(stack.Pop());
    }

    while (reversedStack.Count > 1)
    {
        var number2 = reversedStack.Pop();
        var opr = reversedStack.Pop()[0];
        var number1 = reversedStack.Pop();
        var result = lowPriorityDict[opr](int.Parse(number1), int.Parse(number2));
        reversedStack.Push(result.ToString());
    }

    return int.Parse(reversedStack.Pop());
}

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

var tFourSum = FourSum(new[] { 2, 2, 2, 2 }, 8);
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

var t = KthLargestValue([[5, 2], [1, 6]], 1);

int KthLargestValue(int[][] matrix, int k)
{
    var coordinateValues = new int[matrix.Length * matrix[0].Length];
    var index = 0;
    for (var r = 0; r < matrix.Length; r++)
    {
        for (var c = 0; c < matrix[0].Length; c++)
        {
            matrix[r][c] ^= (r > 0 ? matrix[r - 1][c] : 0) ^
                            (c > 0 ? matrix[r][c - 1] : 0) ^
                            (r > 0 && c > 0 ? matrix[r - 1][c - 1] : 0);
            coordinateValues[index] = matrix[r][c];
            index++;
        }
    }
    var start = 0;
    var end = coordinateValues.Length;
    var pivotIndex = -1;

    while (pivotIndex != k - 1)
    {
        if (pivotIndex > k - 1)
        {
            end = pivotIndex;
        }
        else
        {
            start = pivotIndex + 1;
        }

        pivotIndex = end - 1;
        var pivot = coordinateValues[pivotIndex];
        var boundary = start;
        for (var i = start; i < end; i++)
        {
            if (coordinateValues[i] >= coordinateValues[boundary])
            {
                if (i == pivotIndex)
                {
                    pivotIndex = boundary;
                }
                (coordinateValues[i], coordinateValues[boundary]) = (coordinateValues[boundary++], coordinateValues[i]);
            }
        }
    }

    return coordinateValues[pivotIndex];
}
