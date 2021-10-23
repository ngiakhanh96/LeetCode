namespace ConsoleApp1.Array
{
    public class _1838
    {
        public int MaxFrequency(int[] nums, int k)
        {
            System.Array.Sort(nums);
            long sum = 0;
            var currentJ = 0;
            var maxFrequency = 0;
            var shouldContinue = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                {
                    if (sum > 0)
                    {
                        sum -= nums[i - 1];
                    }
                    currentJ = i > currentJ ? i : currentJ;
                }

                for (int j = currentJ; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (k < (long)nums[j] * (j - i + 1) - sum)
                    {
                        sum -= nums[j];
                        currentJ = j;
                        break;
                    }

                    maxFrequency = Math.Max(maxFrequency, j - i + 1);
                    if (j + 1 >= nums.Length)
                    {
                        shouldContinue = false;
                    }
                }

                if (!shouldContinue)
                {
                    break;
                }
            }

            return maxFrequency;
        }
    }
}
