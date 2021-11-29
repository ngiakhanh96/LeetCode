namespace ConsoleApp1.UnionFind;

public class _1101
{
    public int EarliestAcq(int[][] logs, int n)
    {
        var unionFind = new UnionFind<int>(n);
        logs = logs.OrderBy(log => log[0]).ToArray();
        var earliestMoment = -1;
        foreach (var log in logs)
        {
            unionFind.TryUnion(log[1], log[2]);
            if (unionFind.Count == 1)
            {
                earliestMoment = log[0];
                break;
            }
        }

        return earliestMoment;
    }
}