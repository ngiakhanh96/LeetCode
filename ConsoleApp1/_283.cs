﻿namespace ConsoleApp1
{
    public class _283
    {
        public void MoveZeroes(int[] nums)
        {
            var boundary = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    Swap(nums, i, boundary);
                    boundary++;
                }
            }
        }

        private void Swap(int[] nums, int left, int right)
        {
            if (right == left)
            {
                return;
            }
            nums[right] += nums[left];
            nums[left] = nums[right] - nums[left];
            nums[right] -= nums[left];
        }
    }
}
