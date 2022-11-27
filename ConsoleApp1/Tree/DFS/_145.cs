namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 28)]
public class _145
{
    public IList<int> PostorderNodeValues { get; set; } = new List<int>();
    public IList<int> PostorderTraversal(TreeNode root)
    {
        Dfs(root);
        return PostorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        Dfs(root.left);
        Dfs(root.right);
        PostorderNodeValues.Add(root.val);
    }
}