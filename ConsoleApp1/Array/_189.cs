namespace ConsoleApp1.Array;

public class _189
{
    public void Rotate(int[] nums, int k, int start = 0)
    {
        k %= nums.Length - start;
        if (k == 0)
        {
            return;
        }
        for (var i = start; i < start + k; i++)
        {
            var temp = nums[i];
            nums[i] = nums[nums.Length - start - k + i];
            nums[nums.Length - start - k + i] = temp;
        }
        start += k;
        Rotate(nums, k, start);
    }
}