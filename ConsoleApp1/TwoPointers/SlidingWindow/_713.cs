namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _713
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        var product = 1;
        var currentJ = 0;
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0)
            {
                if (product > 1)
                {
                    product /= nums[i - 1];
                }
                currentJ = i > currentJ ? i : currentJ;
                count += currentJ - i;
            }

            for (var j = currentJ; j < nums.Length; j++)
            {
                product *= nums[j];
                if (product >= k)
                {
                    product /= nums[j];
                    currentJ = j;
                    break;
                }
                count++;
                if (j + 1 >= nums.Length)
                {
                    currentJ = j + 1;
                }
            }
        }

        return count;
    }
}