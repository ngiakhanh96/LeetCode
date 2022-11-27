namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 28)]
public class _144
{
    public IList<int> PreorderNodeValues { get; set; } = new List<int>();
    public IList<int> PreorderTraversal(TreeNode root)
    {
        Dfs(root);
        return PreorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        PreorderNodeValues.Add(root.val);
        Dfs(root.left);
        Dfs(root.right);
    }
}