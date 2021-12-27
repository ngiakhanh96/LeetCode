namespace ConsoleApp1.DP.CoinChange;

public class _377
{
    // Bottom-up
    public int CombinationSum4(int[] nums, int target)
    {
        var possibleWaysToMakeUpAmount = new int[target + 1];
        possibleWaysToMakeUpAmount[0] = 0;
        for (int i = 0; i < possibleWaysToMakeUpAmount.Length; i++)
        {
            foreach (var coin in nums)
            {
                var previousStep = i - coin;
                if (previousStep > 0)
                {
                    possibleWaysToMakeUpAmount[i] += possibleWaysToMakeUpAmount[previousStep];
                }
                else if (previousStep == 0)
                {
                    possibleWaysToMakeUpAmount[i]++;
                }
            }
        }

        return possibleWaysToMakeUpAmount[target];
    }

    // Top-down
    public int[] PossibleWaysToMakeUpAmount { get; set; }
    public int CombinationSum42(int[] nums, int target)
    {
        PossibleWaysToMakeUpAmount = Enumerable.Repeat(-1, target + 1).ToArray();
        PossibleWaysToMakeUpAmount[0] = 0;
        CombinationSum42Impl(nums, target);

        return PossibleWaysToMakeUpAmount[target];
    }

    private int CombinationSum42Impl(int[] nums, int index)
    {
        if (PossibleWaysToMakeUpAmount[index] == -1)
        {
            PossibleWaysToMakeUpAmount[index] = 0;
            foreach (var coin in nums)
            {
                var previousStep = index - coin;
                if (previousStep > 0)
                {
                    PossibleWaysToMakeUpAmount[index] += CombinationSum42Impl(nums, previousStep);
                }
                else if (previousStep == 0)
                {
                    PossibleWaysToMakeUpAmount[index]++;
                }
            }
        }

        return PossibleWaysToMakeUpAmount[index];
    }
}