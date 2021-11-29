namespace ConsoleApp1.UnionFind;

public class _684
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var unionFind = new UnionFind<int>(edges.Length + 1);
        foreach (var edge in edges)
        {
            if (!unionFind.TryUnion(edge[0], edge[1]))
            {
                return edge;
            }
        }

        return new int[2];
    }
}