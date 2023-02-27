namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2023, 02, 27)]
public class _992
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        return SubarraysWithAtMostKDistinct(nums, k) - SubarraysWithAtMostKDistinct(nums, k - 1);
    }

    private int SubarraysWithAtMostKDistinct(int[] nums, int k)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var count = 0;
        var (l, r) = (0, 0);
        var dict = new Dictionary<int, int> { { nums[r], 1 } };
        while (r < nums.Length && l < nums.Length)
        {
            if (dict.Count <= k)
            {
                count += (r - l + 1);
                r++;
                if (r < nums.Length)
                {
                    if (!dict.TryAdd(nums[r], 1))
                    {
                        dict[nums[r]]++;
                    }
                }
            }
            else
            {
                if (dict[nums[l]] == 1)
                {
                    dict.Remove(nums[l]);
                }
                else
                {
                    dict[nums[l]]--;
                }
                l++;
            }
        }

        return count;
    }
}