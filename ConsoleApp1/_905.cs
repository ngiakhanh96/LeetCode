namespace ConsoleApp1
{
    public class _905
    {
        public int[] SortArrayByParity(int[] nums)
        {
            var boundary = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    Swap(nums, i, boundary);
                    boundary++;
                }
            }
            return nums;
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
