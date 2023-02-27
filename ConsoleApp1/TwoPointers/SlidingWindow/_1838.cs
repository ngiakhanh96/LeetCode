namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _1838
{
    public int MaxFrequency(int[] nums, int k)
    {
        var res = 0;
        if (nums.Length == 0)
        {
            return res;
        }
        System.Array.Sort(nums);
        var (l, r) = (0, 0);
        long sum = nums[r];
        while (l < nums.Length && r < nums.Length)
        {
            if (sum + k >= nums[r] * (r - l + 1))
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < nums.Length)
                {
                    sum += nums[r];
                }
            }
            else
            {
                sum -= nums[l];
                l++;
            }
        }

        return res;
    }
}