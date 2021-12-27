namespace ConsoleApp1.DP.LIS;

public class _673
{
    public int[] LenOfLisEndAt { get; set; }

    public int[] Count { get; set; }

    // Bottom-up
    public int FindNumberOfLIS(int[] nums)
    {
        LenOfLisEndAt = Enumerable.Repeat(1, nums.Length).ToArray();
        Count = Enumerable.Repeat(1, nums.Length).ToArray();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    if (LenOfLisEndAt[j] + 1 > LenOfLisEndAt[i])
                    {
                        LenOfLisEndAt[i] = LenOfLisEndAt[j] + 1;
                        Count[i] = Count[j];
                    }
                    else if (LenOfLisEndAt[j] + 1 == LenOfLisEndAt[i])
                    {
                        Count[i] += Count[j];
                    }
                }
            }
        }

        var longestLenOfLisEnd = 0;
        var numOfLis = 1;
        for (int i = 0; i < LenOfLisEndAt.Length; i++)
        {
            if (LenOfLisEndAt[i] > longestLenOfLisEnd)
            {
                longestLenOfLisEnd = LenOfLisEndAt[i];
                numOfLis = Count[i];
            }
            else if (LenOfLisEndAt[i] == longestLenOfLisEnd)
            {
                numOfLis += Count[i];
            }
        }

        return numOfLis;
    }

    // Top-down
    public int FindNumberOfLIS2(int[] nums)
    {
        LenOfLisEndAt = new int[nums.Length];
        LenOfLisEndAt[0] = 1;
        Count = Enumerable.Repeat(1, nums.Length).ToArray();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            FindNumberOfLIS2Impl(nums, i);
        }

        var longestLenOfLisEnd = 0;
        var numOfLis = 1;
        for (int i = 0; i < LenOfLisEndAt.Length; i++)
        {
            if (LenOfLisEndAt[i] > longestLenOfLisEnd)
            {
                longestLenOfLisEnd = LenOfLisEndAt[i];
                numOfLis = Count[i];
            }
            else if (LenOfLisEndAt[i] == longestLenOfLisEnd)
            {
                numOfLis += Count[i];
            }
        }

        return numOfLis;
    }

    private int FindNumberOfLIS2Impl(int[] nums, int index)
    {
        if (LenOfLisEndAt[index] == 0)
        {
            LenOfLisEndAt[index] = 1;
            for (int j = index - 1; j >= 0; j--)
            {
                if (nums[index] > nums[j])
                {
                    var lenOfLisEndAtJ = FindNumberOfLIS2Impl(nums, j);
                    if (lenOfLisEndAtJ + 1 > LenOfLisEndAt[index])
                    {
                        LenOfLisEndAt[index] = lenOfLisEndAtJ + 1;
                        Count[index] = Count[j];
                    }
                    else if (lenOfLisEndAtJ + 1 == LenOfLisEndAt[index])
                    {
                        Count[index] += Count[j];
                    }
                }
            }
        }

        return LenOfLisEndAt[index];
    }
}