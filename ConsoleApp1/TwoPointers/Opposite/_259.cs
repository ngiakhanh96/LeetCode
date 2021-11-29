namespace ConsoleApp1.TwoPointers.Opposite;

public class _259
{
    public int ThreeSumSmaller(int[] nums, int target)
    {
        var res = 0;
        if (nums.Length < 3)
        {
            return res;
        }
        System.Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            var newTarget = target - nums[i];
            var (j, k) = (i + 1, nums.Length - 1);
            while (j < k)
            {
                if (nums[j] + nums[k] < newTarget)
                {
                    res += k - j;
                    j++;
                }
                else
                {
                    k--;
                }
            }
        }
        return res;
    }
}