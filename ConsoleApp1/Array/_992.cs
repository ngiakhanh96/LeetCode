namespace ConsoleApp1.Array;

public class _992
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        return SubarraysWithAtMostKDistinct(nums, k) - SubarraysWithAtMostKDistinct(nums, k - 1);
    }

    private int SubarraysWithAtMostKDistinct(int[] nums, int k)
    {
        var count = 0;
        var currentJ = 0;
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0)
            {
                if (dict.Count > 0)
                {
                    dict[nums[i - 1]]--;
                    if (dict[nums[i - 1]] == 0)
                    {
                        dict.Remove(nums[i - 1]);
                    }
                }
                if (currentJ < i)
                {
                    currentJ = i;
                }

                count += currentJ - i;

            }
            for (var j = currentJ; j < nums.Length; j++)
            {
                if (dict.TryAdd(nums[j], 1))
                {
                    if (dict.Count > k)
                    {
                        dict.Remove(nums[j]);
                        currentJ = j;
                        break;
                    }
                }
                else
                {
                    dict[nums[j]]++;
                }
                count++;

                if (j + 1 == nums.Length)
                {
                    currentJ = j + 1;
                }
            }
        }
        return count;
    }
}