namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 28)]
public class _590
{
    public IList<int> PostorderNodeValues { get; set; } = new List<int>();
    public IList<int> Postorder(Node root)
    {
        Dfs(root);
        return PostorderNodeValues;
    }

    private void Dfs(Node root)
    {
        if (root == null)
        {
            return;
        }

        foreach (var childNode in root.children)
        {
            Dfs(childNode);
        }
        PostorderNodeValues.Add(root.val);
    }
}