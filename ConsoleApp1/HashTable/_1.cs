namespace ConsoleApp1.HashTable;

[LastVisited(2022, 11, 16)]
public class _1
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(target - nums[i]))
            {
                return new[] { dict[target - nums[i]], i };
            }

            if (!dict.TryAdd(nums[i], i))
            {
                dict[nums[i]] = i;
            }
        }

        return null;
    }
}