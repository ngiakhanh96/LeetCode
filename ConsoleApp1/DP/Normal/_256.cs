namespace ConsoleApp1.DP.Normal;

public class _256
{
    // Bottom-up
    public int MinCost(int[][] costs)
    {
        var minimumCostIfPaintUntilCurrentHouseRed = costs[0][0];
        var minimumCostIfPaintUntilCurrentHouseBlue = costs[0][1];
        var minimumCostIfPaintUntilCurrentHouseGreen = costs[0][2];
        for (int i = 1; i < costs.Length; i++)
        {
            var minimumCostIfPaintUntilPreviousHouseRed = minimumCostIfPaintUntilCurrentHouseRed;
            var minimumCostIfPaintUntilPreviousHouseBlue = minimumCostIfPaintUntilCurrentHouseBlue;
            var minimumCostIfPaintUntilPreviousHouseGreen = minimumCostIfPaintUntilCurrentHouseGreen;

            minimumCostIfPaintUntilCurrentHouseRed =
                Math.Min(minimumCostIfPaintUntilPreviousHouseBlue, minimumCostIfPaintUntilPreviousHouseGreen) + costs[i][0];
            minimumCostIfPaintUntilCurrentHouseBlue =
                Math.Min(minimumCostIfPaintUntilPreviousHouseRed, minimumCostIfPaintUntilPreviousHouseGreen) + costs[i][1];
            minimumCostIfPaintUntilCurrentHouseGreen =
                Math.Min(minimumCostIfPaintUntilPreviousHouseRed, minimumCostIfPaintUntilPreviousHouseBlue) + costs[i][2];
        }

        return new[] { minimumCostIfPaintUntilCurrentHouseRed, minimumCostIfPaintUntilCurrentHouseBlue, minimumCostIfPaintUntilCurrentHouseGreen }.Min();
    }

    // Top-down
    public int MinCost2(int[][] costs)
    {
        return MinCost2Impl(costs, costs.Length - 1).Min();
    }

    private int[] MinCost2Impl(int[][] costs, int index)
    {
        if (index == 0)
        {
            return costs[0];
        }

        var previousMinCost = MinCost2Impl(costs, index - 1);
        return new[]
        {
            Math.Min(previousMinCost[1], previousMinCost[2]) + costs[index][0],
            Math.Min(previousMinCost[0], previousMinCost[2]) + costs[index][1],
            Math.Min(previousMinCost[0], previousMinCost[1]) + costs[index][2]
        };
    }
}