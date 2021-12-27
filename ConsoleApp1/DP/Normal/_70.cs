namespace ConsoleApp1.DP.Normal;

public class _70
{
    // Bottom-up
    public int ClimbStairs(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        if (n == 1)
        {
            return 1;
        }

        var numWaysToReachTwoStepBelow = 1;
        var numWaysToReachOneStepBelow = 1;
        var numWaysToReachCurrentStep = 0;
        for (int i = 2; i <= n; i++)
        {
            numWaysToReachCurrentStep =
                numWaysToReachTwoStepBelow + numWaysToReachOneStepBelow;
            numWaysToReachTwoStepBelow = numWaysToReachOneStepBelow;
            numWaysToReachOneStepBelow = numWaysToReachCurrentStep;
        }

        return numWaysToReachCurrentStep;
    }

    // Top-down
    public int[] Cache { get; set; }
    public int ClimbStairs2(int n)
    {
        Cache = new int[n + 1];
        Cache[0] = 1;
        Cache[1] = 1;
        return ClimbStairImp(n);
    }

    private int ClimbStairImp(int n)
    {
        if (Cache[n] > 0)
        {
            return Cache[n];
        }

        Cache[n] = ClimbStairImp(n - 2) + ClimbStairImp(n - 1);
        return Cache[n];
    }
}