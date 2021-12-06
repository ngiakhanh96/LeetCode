namespace ConsoleApp1.DP
{
    public class _300
    {
        public int[] LengthOfLISEndAt { get; set; }

        // Bottom-up
        public int LengthOfLIS(int[] nums)
        {
            LengthOfLISEndAt = Enumerable.Repeat(1, nums.Length).ToArray();
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] > nums[j])
                    {
                        LengthOfLISEndAt[i] = Math.Max(LengthOfLISEndAt[i], LengthOfLISEndAt[j] + 1);
                    }
                }
            }

            return LengthOfLISEndAt.Max();
        }

        // Top-down
        public int LengthOfLIS2(int[] nums)
        {
            LengthOfLISEndAt = new int[nums.Length];
            LengthOfLISEndAt[0] = 1;
            for (int i = LengthOfLISEndAt.Length - 1; i >= 0; i--)
            {
                LengthOfLISEndAt[i] = LengthOfLIS2Impl(i, nums);
            }

            return LengthOfLISEndAt.Max();

        }

        private int LengthOfLIS2Impl(int index, int[] nums)
        {
            if (LengthOfLISEndAt[index] > 0)
            {
                return LengthOfLISEndAt[index];
            }

            LengthOfLISEndAt[index] = 1;
            for (int j = index - 1; j >= 0; j--)
            {
                if (nums[index] > nums[j])
                {
                    LengthOfLISEndAt[index] = Math.Max(LengthOfLISEndAt[index], LengthOfLIS2Impl(j, nums) + 1);
                }
            }

            return LengthOfLISEndAt[index];
        }
    }
}
