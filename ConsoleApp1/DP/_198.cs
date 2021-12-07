namespace ConsoleApp1.DP
{
    public class _198
    {
        // Bottom-up
        public int Rob(int[] nums)
        {
            var maximumMoneyIfRobCurrentHouse = nums[0];
            var maximumMoneyIfNotRobCurrentHouse = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                var maximumMoneyIfNotRobHouseBefore = maximumMoneyIfNotRobCurrentHouse;
                var maximumMoneyIfRobHouseBefore = maximumMoneyIfRobCurrentHouse;
                maximumMoneyIfNotRobCurrentHouse =
                    Math.Max(maximumMoneyIfNotRobHouseBefore, maximumMoneyIfRobHouseBefore);
                maximumMoneyIfRobCurrentHouse = maximumMoneyIfNotRobHouseBefore + nums[i];
            }

            return Math.Max(maximumMoneyIfRobCurrentHouse, maximumMoneyIfNotRobCurrentHouse);
        }

        // Top-down
        public int Rob2(int[] nums)
        {
            return Rob2Impl(nums.Length - 1, nums).Max();
        }

        private int[] Rob2Impl(int index, int[] nums)
        {
            if (index == 0)
            {
                return new int[] { 0, nums[0] };
            }

            var robHouseBefore = Rob2Impl(index - 1, nums);
            return new int[] { robHouseBefore.Max(), robHouseBefore[0] + nums[index] };
        }
    }
}
