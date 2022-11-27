namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _111
{
    public int MinDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        if (root.left == null || root.right == null)
        {
            return Math.Max(MinDepth(root.left), MinDepth(root.right)) + 1;
        }

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }
}