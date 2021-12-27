namespace ConsoleApp1.DP.Multidimensional;

public class _718
{
    // Bottom-up
    public int FindLength(int[] nums1, int[] nums2)
    {
        var lenOfLongestSubArrayEndAt = new int[nums1.Length, nums2.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums1[i] == nums2[j])
                {
                    lenOfLongestSubArrayEndAt[i, j] =
                        (i - 1 >= 0 && j - 1 >= 0
                            ? lenOfLongestSubArrayEndAt[i - 1, j - 1]
                            : 0)
                        + 1;
                }
            }
        }

        var res = 0;
        for (int i = 0; i < lenOfLongestSubArrayEndAt.GetLength(0); i++)
        {
            for (int j = 0; j < lenOfLongestSubArrayEndAt.GetLength(1); j++)
            {
                res = Math.Max(res, lenOfLongestSubArrayEndAt[i, j]);
            }
        }
        return res;
    }

    // Top-down
    public int[,] LenOfLongestSubArrayEndAt { get; set; }
    public int FindLength2(int[] nums1, int[] nums2)
    {
        LenOfLongestSubArrayEndAt = new int[nums1.Length, nums2.Length];
        for (var i = 0; i < LenOfLongestSubArrayEndAt.GetLength(0); i++)
        {
            for (int j = 0; j < LenOfLongestSubArrayEndAt.GetLength(1); j++)
            {
                LenOfLongestSubArrayEndAt[i, j] = -1;
            }
        }

        for (var i = 0; i < LenOfLongestSubArrayEndAt.GetLength(0); i++)
        {
            for (int j = 0; j < LenOfLongestSubArrayEndAt.GetLength(1); j++)
            {
                FindLength2Impl(nums1, nums2, i, j);
            }
        }

        var res = 0;
        for (int i = 0; i < LenOfLongestSubArrayEndAt.GetLength(0); i++)
        {
            for (int j = 0; j < LenOfLongestSubArrayEndAt.GetLength(1); j++)
            {
                res = Math.Max(res, LenOfLongestSubArrayEndAt[i, j]);
            }
        }
        return res;
    }

    private int FindLength2Impl(int[] nums1, int[] nums2, int i, int j)
    {
        if (i < 0 || j < 0)
        {
            return 0;
        }

        if (LenOfLongestSubArrayEndAt[i, j] == -1)
        {
            LenOfLongestSubArrayEndAt[i, j] =
                nums1[i] == nums2[j]
                    ? FindLength2Impl(nums1, nums2, i - 1, j - 1) + 1
                    : 0;
        }

        return LenOfLongestSubArrayEndAt[i, j];
    }
}