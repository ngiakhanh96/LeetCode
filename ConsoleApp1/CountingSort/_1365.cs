namespace ConsoleApp1.CountingSort;

public class _1365
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
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