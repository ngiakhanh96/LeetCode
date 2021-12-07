namespace ConsoleApp1.DP
{
    public class _746
    {
        // Bottom-up
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length < 3)
            {
                return cost.Min();
            }
            var minCostToClimbTo2StepBefore = cost[0];
            var minCostToClimbTo1StepBefore = cost[1];
            var minCostToClimbToCurrentStep = 0;
            for (int i = 2; i < cost.Length; i++)
            {
                minCostToClimbToCurrentStep =
                    Math.Min(minCostToClimbTo2StepBefore, minCostToClimbTo1StepBefore) + cost[i];
                minCostToClimbTo2StepBefore = minCostToClimbTo1StepBefore;
                minCostToClimbTo1StepBefore = minCostToClimbToCurrentStep;
            }

            return Math.Min(minCostToClimbToCurrentStep, minCostToClimbTo2StepBefore);
        }

        // Top-down
        public int[] Cache { get; set; }
        public int MinCostClimbingStairs2(int[] cost)
        {
            if (cost.Length < 3)
            {
                return cost.Min();
            }
            Cache = Enumerable.Repeat(-1, cost.Length).ToArray();
            Cache[0] = cost[0];
            Cache[1] = cost[1];

            return Math.Min(MinCostClimbingStairsImpl(cost.Length - 1, cost), MinCostClimbingStairsImpl(cost.Length - 2, cost));
        }

        private int MinCostClimbingStairsImpl(int index, int[] cost)
        {
            if (Cache[index] > -1)
            {
                return Cache[index];
            }

            Cache[index] = Math.Min(MinCostClimbingStairsImpl(index - 2, cost), MinCostClimbingStairsImpl(index - 1, cost)) + cost[index];
            return Cache[index];
        }
    }
}
