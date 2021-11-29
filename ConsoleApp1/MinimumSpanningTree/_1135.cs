namespace ConsoleApp1.MinimumSpanningTree;

public class _1135
{
    public int MinimumCost(int n, int[][] connections)
    {
        if (connections.Length < n - 1)
        {
            return -1;
        }
        var sum = 0;
        System.Array.Sort(connections, (c1, c2) => c1[2].CompareTo(c2[2]));

        var union = new UnionFind<int>(connections.Length + 1);
        foreach (var connection in connections)
        {
            var firstCity = connection[0];
            var secondCity = connection[1];
            var weight = connection[2];

            if (union.TryUnion(firstCity - 1, secondCity - 1))
            {
                sum += weight;
            }
        }

        return sum;
    }
}