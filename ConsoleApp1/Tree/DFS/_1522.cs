namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _1522
{
    private int _diameter = 0;
    public int Diameter(Node root, bool isRoot = true)
    {
        if (root == null)
        {
            return 0;
        }

        var longestDistanceFromChildToLeaf = 0;
        var secondLongestDistanceFromChildToLeaf = 0;
        foreach (var child in root.children)
        {
            var longestDistanceFromCurrentChildToLeaf = Diameter(child, false);
            if (longestDistanceFromCurrentChildToLeaf >= longestDistanceFromChildToLeaf)
            {
                secondLongestDistanceFromChildToLeaf = longestDistanceFromChildToLeaf;
                longestDistanceFromChildToLeaf = longestDistanceFromCurrentChildToLeaf;
            }
            else if (longestDistanceFromCurrentChildToLeaf < longestDistanceFromChildToLeaf &&
                     longestDistanceFromCurrentChildToLeaf >= secondLongestDistanceFromChildToLeaf)
            {
                secondLongestDistanceFromChildToLeaf = longestDistanceFromCurrentChildToLeaf;
            }
        }

        _diameter = Math.Max(_diameter, longestDistanceFromChildToLeaf + secondLongestDistanceFromChildToLeaf);

        return isRoot ? _diameter : longestDistanceFromChildToLeaf + 1;
    }

    public int LongestPath { get; set; }
    public int Diameter2(Node root)
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