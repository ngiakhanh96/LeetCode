namespace ConsoleApp1.DP.Multidimensional
{
    public class _1035
    {
        // Bottom-up
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            var maxUncrossedUntil = new int[nums1.Length, nums2.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        maxUncrossedUntil[i, j] = new int[]
                        {
                            (i - 1 >= 0 && j - 1 >= 0
                                ? maxUncrossedUntil[i - 1, j - 1]
                                : 0)
                            + 1,
                            j - 1 >= 0
                                ? maxUncrossedUntil[i, j - 1]
                                : 0,
                            i - 1 >= 0
                                ? maxUncrossedUntil[i - 1, j]
                                : 0
                        }.Max();
                    }
                    else
                    {
                        maxUncrossedUntil[i, j] = new int[]
                        {
                            j - 1 >= 0
                                ? maxUncrossedUntil[i, j - 1]
                                : 0,
                            i - 1 >= 0
                                ? maxUncrossedUntil[i - 1, j]
                                : 0
                        }.Max();
                    }
                }
            }

            return maxUncrossedUntil[nums1.Length - 1, nums2.Length - 1];
        }

        // Top-down
        public int[,] MaxUncrossedUntil { get; set; }
        public int MaxUncrossedLines2(int[] nums1, int[] nums2)
        {
            MaxUncrossedUntil = new int[nums1.Length, nums2.Length];
            for (var i = 0; i < MaxUncrossedUntil.GetLength(0); i++)
            {
                for (int j = 0; j < MaxUncrossedUntil.GetLength(1); j++)
                {
                    MaxUncrossedUntil[i, j] = -1;
                }
            }

            return MaxUncrossedLines2Impl(nums1, nums2, nums1.Length - 1, nums2.Length - 1);
        }

        private int MaxUncrossedLines2Impl(int[] nums1, int[] nums2, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (MaxUncrossedUntil[i, j] == -1)
            {
                MaxUncrossedUntil[i, j] =
                    nums1[i] == nums2[j]
                        ? new int[]
                            {
                                MaxUncrossedLines2Impl(nums1, nums2, i - 1, j - 1) + 1,
                                MaxUncrossedLines2Impl(nums1, nums2, i, j - 1),
                                MaxUncrossedLines2Impl(nums1, nums2, i - 1, j)
                            }.Max()
                        : new int[]
                            {
                                MaxUncrossedLines2Impl(nums1, nums2, i, j - 1),
                                MaxUncrossedLines2Impl(nums1, nums2, i - 1, j)
                            }.Max();
            }

            return MaxUncrossedUntil[i, j];
        }
    }
}
