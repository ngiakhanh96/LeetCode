namespace ConsoleApp1.CountingSort;

[LastVisited(2022, 11, 7)]
public class _1365
{
    // Space(MaxValue - minValue)
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var dict = new Dictionary<int, List<int>>();
        var smallest = int.MaxValue;
        var largest = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!dict.TryAdd(nums[i], new List<int> { i }))
            {
                dict[nums[i]].Add(i);
            }
            smallest = Math.Min(smallest, nums[i]);
            largest = Math.Max(largest, nums[i]);
        }

        var count = 0;
        for (var i = smallest; i <= largest; i++)
        {
            if (dict.ContainsKey(i))
            {
                foreach (var index in dict[i])
                {
                    nums[index] = count;
                }
                count += dict[i].Count;
            }
        }

        return nums;
    }

    // Space(100)
    public int[] SmallerNumbersThanCurrent2(int[] nums)
    {
        var result = new int[nums.Length];
        var count = new int[101];
        for (var i = 0; i < nums.Length; i++)
        {
            count[nums[i]]++;
        }

        for (var i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] > 0 ? count[nums[i] - 1] : 0;
        }
        return result;
    }
}