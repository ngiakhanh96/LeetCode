namespace ConsoleApp1.TwoPointers.SlidingWindow;

public class _487
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var currentJ = 0;
        var currentNum0S = 0;
        var maxLength = 0;
        var shouldContinue = true;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0)
            {
                if (currentNum0S > 0)
                {
                    currentNum0S -= nums[i - 1] == 0 ? 1 : 0;
                }
                currentJ = i > currentJ ? i : currentJ;
            }

            for (int j = currentJ; j < nums.Length; j++)
            {
                currentNum0S += nums[j] == 0 ? 1 : 0;
                if (currentNum0S > 1)
                {
                    currentJ = j;
                    currentNum0S--;
                    break;
                }
                maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
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

        return maxLength;
    }
}