namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 28)]
public class _337
{
    public int Rob(TreeNode root)
    {
        return Dfs(root).Max();
    }

    /// <summary>
    /// Return the array of [
    /// maximum money if deciding to rob this house,
    /// maximum money if not rob this house]
    /// </summary>
    /// <param name="node">House</param>
    /// <returns></returns>
    private int[] Dfs(TreeNode node)
    {
        if (node == null)
        {
            return new[] { 0, 0 };
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        return new[] {
            left[1] + right[1] + node.val,
            left.Max() + right.Max()
        };
    }
}