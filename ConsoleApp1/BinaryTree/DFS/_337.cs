namespace ConsoleApp1.BinaryTree.DFS;

public class _337
{
    public int Rob(TreeNode root)
    {
        var dfs = Dfs(root);
        return Math.Max(dfs[0], dfs[1]);
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
            return new int[] { 0, 0 };
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        return new int[] {
            left[1] + right[1] + node.val,
            new int[]
            {
                left[0] + right[0],
                left[1] + right[0],
                left[0] + right[1],
                left[1] + right[1]
            }.Max()
        };
    }
}