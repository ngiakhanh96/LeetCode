namespace ConsoleApp1.BinaryTree.DFS;

public class _1522
{
    public int LongestPath { get; set; }
    public int Diameter(Node root)
    {
        Dfs(root);
        return LongestPath;
    }

    private int Dfs(Node root)
    {
        if (root == null)
        {
            return -1;
        }

        if (root.children.Count == 0)
        {
            return 0;
        }

        var list = new List<int>();
        foreach (var child in root.children)
        {
            list.Add(Dfs(child) + 1);
        }

        list.Sort();
        var currentDiameter = list[^1];

        if (list.Count > 1)
        {
            currentDiameter += list[^2];
        }
        LongestPath = Math.Max(currentDiameter, LongestPath);
        return list[^1];
    }
}