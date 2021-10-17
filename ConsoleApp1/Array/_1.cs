namespace ConsoleApp1.Array;

public class _1
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
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