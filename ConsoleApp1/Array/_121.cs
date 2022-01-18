namespace ConsoleApp1.Array;

public class _121
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var minPriceUntilNow = prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            maxProfit = Math.Max(prices[i] - minPriceUntilNow, maxProfit);
            if (prices[i] < minPriceUntilNow)
            {
                minPriceUntilNow = prices[i];
            }
        }

        return maxProfit;
    }
}