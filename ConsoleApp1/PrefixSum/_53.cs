namespace ConsoleApp1.PrefixSum;

[LastVisited(2023, 07, 25)]
public class _53
{
    public int MaxSubArray(int[] array)
    {
        var count = 0;
        var minValue = 0;
        var maxSum = int.MinValue;
        for (var i = 0; i < array.Length; i++)
        {
            count += array[i];
            var currentMaxSum = count - minValue;
            maxSum =
                maxSum > currentMaxSum
                    ? maxSum
                    : currentMaxSum;
            minValue = minValue < count ? minValue : count;
        }

        return maxSum;
    }

    // DP approach
    public int MaxSubArray2(int[] nums)
    {
        var maxSum = nums[0];
        var currentMax = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            maxSum = Math.Max(maxSum, currentMax);
        }
        return maxSum;
    }
}