namespace ConsoleApp1.Array;

public class _560
{
    public int SubarraySum(int[] nums, int k)
    {
        var dict = new Dictionary<int, int> { { 0, 1 } };
        var currentSum = 0;
        var count = 0;
        foreach (var num in nums)
        {
            currentSum += num;
            count += dict.GetValueOrDefault(currentSum - k, 0);

            if (!dict.TryAdd(currentSum, 1))
            {
                dict[currentSum]++;
            }
        }

        return count;
    }
}