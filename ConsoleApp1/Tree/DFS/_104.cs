namespace ConsoleApp1.Tree.DFS;

public class _104
{
    public int MaxDepth(TreeNode root, bool isRoot = true)
    {
        if (root == null)
        {
            return 0;
        }
        return Math.Max(MaxDepth(root.left, false), MaxDepth(root.right, false)) + 1;
    }
}