namespace ConsoleApp1.Array;

public class _1004
{
    public int LongestOnes(int[] nums, int k)
    {
        var currentJ = 0;
        var currentNum0S = 0;
        var maxLength = 0;
        var shouldContinue = false;
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
                shouldContinue = false;
                currentNum0S += nums[j] == 0 ? 1 : 0;
                if (currentNum0S > k)
                {
                    currentJ = j;
                    currentNum0S--;
                    shouldContinue = true;
                    break;
                }
                maxLength = j - i + 1 > maxLength ? j - i + 1 : maxLength;
            }

            if (!shouldContinue)
            {
                break;
            }
        }

        return maxLength;
    }
}