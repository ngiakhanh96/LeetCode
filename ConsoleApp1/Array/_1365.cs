namespace ConsoleApp1.Array;

public class _1365
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var result = new int[nums.Length];
        var count = new int[101];
        for (int i = 0; i < nums.Length; i++)
        {
            count[nums[i]]++;
        }

        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] > 0 ? count[nums[i] - 1] : 0;
        }
        return result;
    }
}