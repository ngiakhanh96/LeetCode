namespace ConsoleApp1.UnionFind;

public class _1627
{
    public IList<bool> AreConnected(int n, int threshold, int[][] queries)
    {
        var unionFind = new UnionFind<int>(n + 1);
        for (int i = 1; i < n + 1; i++)
        {
            var factors = FindDivisorsWithThreshold(i, threshold);
            foreach (var factor in factors)
            {
                unionFind.TryUnion(i, factor);
            }
        }

        var res = new List<bool>();
        foreach (var query in queries)
        {
            if (unionFind.Find(query[0]) == unionFind.Find(query[1]))
            {
                res.Add(true);
            }
            else
            {
                res.Add(false);
            }
        }
        return res;
    }

    private List<int> FindDivisorsWithThreshold(int n, int threshold)
    {
        var res = new List<int>();
        for (int i = threshold + 1; i <= n / 2; ++i)
        {
            if (n % i == 0)
            {
                res.Add(i);
            }
        }

        if (n > threshold)
        {
            res.Add(n);
        }
        return res;
    }
}