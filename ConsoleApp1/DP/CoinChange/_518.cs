namespace ConsoleApp1.DP.CoinChange;

// Super hard problem. See https://leetcode.com/problems/coin-change-2/discuss/99212/Knapsack-problem-Java-solution-with-thinking-process-O(nm)-Time-and-O(m)-Space
public class _518
{
    // Bottom-up
    public int Change(int amount, int[] coins)
    {
        var possibleWaysToMakeUpAmountUsingFirstCoins = new int[coins.Length, amount + 1];
        for (int i = 0; i < possibleWaysToMakeUpAmountUsingFirstCoins.GetLength(0); i++)
        {
            possibleWaysToMakeUpAmountUsingFirstCoins[i, 0] = 1;
            for (int j = 1; j < possibleWaysToMakeUpAmountUsingFirstCoins.GetLength(1); j++)
            {
                possibleWaysToMakeUpAmountUsingFirstCoins[i, j] =
                    i - 1 >= 0
                        ? possibleWaysToMakeUpAmountUsingFirstCoins[i - 1, j]
                        : 0;
                if (j - coins[i] >= 0)
                {
                    possibleWaysToMakeUpAmountUsingFirstCoins[i, j] +=
                        possibleWaysToMakeUpAmountUsingFirstCoins[i, j - coins[i]];
                }
            }
        }

        return possibleWaysToMakeUpAmountUsingFirstCoins[coins.Length - 1, amount];
    }
}