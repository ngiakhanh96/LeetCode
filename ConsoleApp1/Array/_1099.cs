namespace ConsoleApp1.Array;

public class _1099
{
    public int TwoSumLessThanK(int[] nums, int k)
    {
        var leftPointer = 0;
        var rightPointer = nums.Length - 1;
        var res = -1;
        System.Array.Sort(nums);
        while (leftPointer < rightPointer)
        {
            if (nums[rightPointer] + nums[leftPointer] < k)
            {
                res = Math.Max(res, nums[rightPointer] + nums[leftPointer]);
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
        }
        return res;
    }
}