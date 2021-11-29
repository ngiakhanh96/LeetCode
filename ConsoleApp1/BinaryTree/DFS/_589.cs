namespace ConsoleApp1.BinaryTree.DFS;

public class _589
{
    public IList<int> PreorderNodeValues { get; set; } = new List<int>();
    public IList<int> Preorder(Node root)
    {
        Dfs(root);
        return PreorderNodeValues;
    }

    private void Dfs(Node root)
    {
        if (root == null)
        {
            return;
        }

        PreorderNodeValues.Add(root.val);
        foreach (var childNode in root.children)
        {
            Dfs(childNode);
        }
    }
}