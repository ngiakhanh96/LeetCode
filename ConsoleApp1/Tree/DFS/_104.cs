namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _104
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}