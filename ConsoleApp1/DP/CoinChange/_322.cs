namespace ConsoleApp1.DP.CoinChange;

public class _322
{
    // Bottom-up
    public int CoinChange(int[] coins, int amount)
    {
        var fewestNumCoinToMakeUpAmount = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
        fewestNumCoinToMakeUpAmount[0] = 0;
        for (int i = 1; i < fewestNumCoinToMakeUpAmount.Length; i++)
        {
            if (coins.Contains(i))
            {
                fewestNumCoinToMakeUpAmount[i] = 1;
            }
            else
            {
                foreach (var coin in coins)
                {
                    var previousStep = i - coin;
                    if (previousStep >= 0 && fewestNumCoinToMakeUpAmount[previousStep] > -1)
                    {
                        fewestNumCoinToMakeUpAmount[i] = Math.Min(
                            fewestNumCoinToMakeUpAmount[previousStep] + 1,
                            fewestNumCoinToMakeUpAmount[i]);
                    }
                }

                if (fewestNumCoinToMakeUpAmount[i] == int.MaxValue)
                {
                    fewestNumCoinToMakeUpAmount[i] = -1;
                }
            }
        }

        return fewestNumCoinToMakeUpAmount[amount];
    }

    // Top-down
    public int[] FewestNumCoinToMakeUpAmount { get; set; }
    public int CoinChange2(int[] coins, int amount)
    {
        FewestNumCoinToMakeUpAmount = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
        FewestNumCoinToMakeUpAmount[0] = 0;
        CoinChange2Impl(coins, amount);

        return FewestNumCoinToMakeUpAmount[amount];
    }

    private int CoinChange2Impl(int[] coins, int index)
    {
        if (FewestNumCoinToMakeUpAmount[index] == int.MaxValue)
        {
            foreach (var coin in coins)
            {
                var previousStep = index - coin;

                if (previousStep >= 0)
                {
                    var coinChangeInPreviousStep = CoinChange2Impl(coins, previousStep);
                    if (coinChangeInPreviousStep > -1)
                    {
                        FewestNumCoinToMakeUpAmount[index] = Math.Min(
                            coinChangeInPreviousStep + 1,
                            FewestNumCoinToMakeUpAmount[index]);
                    }

                }
            }

            if (FewestNumCoinToMakeUpAmount[index] == int.MaxValue)
            {
                FewestNumCoinToMakeUpAmount[index] = -1;
            }
        }

        return FewestNumCoinToMakeUpAmount[index];
    }
}