namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _1004
{
    public int LongestOnes(int[] nums, int k)
    {
        var (l, r) = (0, 0);
        var zero = nums[0] == 0 ? 1 : 0;
        var res = 0;
        while (r < nums.Length)
        {
            if (zero <= k)
            {
                res = Math.Max(res, r - l + 1);
                r++;
                if (r < nums.Length)
                {
                    zero += nums[r] == 0 ? 1 : 0;
                }
            }
            else
            {
                if (nums[l] == 0)
                {
                    zero--;
                }
                l++;
            }
        }
        return res;

    }

    public int LongestOnes2(int[] nums, int k)
    {
        var currentJ = 0;
        var currentNum0S = 0;
        var maxLength = 0;
        var shouldContinue = true;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0)
            {
                if (currentNum0S > 0)
                {
                    currentNum0S -= nums[i - 1] == 0 ? 1 : 0;
                }
                currentJ = i > currentJ ? i : currentJ;
            }

            for (var j = currentJ; j < nums.Length; j++)
            {
                currentNum0S += nums[j] == 0 ? 1 : 0;
                if (currentNum0S > k)
                {
                    currentJ = j;
                    currentNum0S--;
                    break;
                }
                maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
                if (j + 1 >= nums.Length)
                {
                    shouldContinue = false;
                }
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return maxLength;
    }
}