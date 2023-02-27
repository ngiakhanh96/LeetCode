namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _487
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var res = 1;
        if (nums.Length == 0)
        {
            return res;
        }

        var remaining0sToFlip = nums[0] == 1 ? 1 : 0;
        var (l, r) = (0, 0);
        while (r < nums.Length && l < nums.Length)
        {
            if (remaining0sToFlip >= 0)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < nums.Length)
                {
                    remaining0sToFlip -= nums[r] == 1 ? 0 : 1;
                }
            }
            else
            {
                remaining0sToFlip += nums[l] == 0 ? 1 : 0;
                l++;
            }
        }

        return res;
    }
}