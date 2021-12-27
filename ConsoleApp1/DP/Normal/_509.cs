namespace ConsoleApp1.DP.Normal;

public class _509
{
    // Bottom-up
    public int Fib(int n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }

        var firstElement = 0;
        var secondElement = 1;
        var currentElement = 0;
        for (int i = 2; i <= n; i++)
        {
            currentElement = firstElement + secondElement;
            firstElement = secondElement;
            secondElement = currentElement;
        }

        return currentElement;
    }

    // Top-down
    public int[] Cache { get; set; }
    public int Fib2(int n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }
        Cache = Enumerable.Repeat(-1, n + 1).ToArray();
        Cache[0] = 0;
        Cache[1] = 1;
        return Fib2Impl(n);
    }

    private int Fib2Impl(int n)
    {
        if (Cache[n] > -1)
        {
            return Cache[n];
        }

        Cache[n] = Fib2Impl(n - 2) + Fib2Impl(n - 1);
        return Cache[n];
    }
}