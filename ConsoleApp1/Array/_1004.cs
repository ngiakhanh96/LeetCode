﻿namespace ConsoleApp1.Array
{
    public class _1004
    {
        public int LongestOnes(int[] nums, int k)
        {
            var currentJ = 0;
            var currentNum0S = 0;
            var maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                {
                    currentNum0S -= nums[i - 1] == 0 ? 1 : 0;
                }

                for (int j = currentJ; j < nums.Length; j++)
                {
                    currentNum0S += nums[j] == 0 ? 1 : 0;
                    if (currentNum0S > k)
                    {
                        currentJ = j;
                        currentNum0S--;
                        break;
                    }
                    maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
                }
            }

            return maxLength;
        }
    }
}
