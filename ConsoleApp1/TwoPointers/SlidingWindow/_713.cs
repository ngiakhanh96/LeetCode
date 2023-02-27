namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _713
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        var res = 0;
        var currProduct = nums[0];
        var (l, r) = (0, 0);
        while (r < nums.Length && l < nums.Length)
        {
            if (currProduct < k)
            {
                res += r - l + 1;
                r++;
                if (r < nums.Length)
                {
                    currProduct *= nums[r];
                }
            }
            else
            {
                currProduct /= nums[l];
                l++;
            }
        }
        return res;
    }
}