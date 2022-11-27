namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 28)]
public class _94
{
    public IList<int> InorderNodeValues { get; set; } = new List<int>();
    public IList<int> InorderTraversal(TreeNode root)
    {
        Dfs(root);
        return InorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        Dfs(root.left);
        InorderNodeValues.Add(root.val);
        Dfs(root.right);
    }
}