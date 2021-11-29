namespace ConsoleApp1.BinaryTree.DFS;

public class _687
{
    public int LongestPath { get; set; }
    public int LongestUnivaluePath(TreeNode root)
    {
        MaxUniValueDepth(root, 0);
        return LongestPath;
    }

    private int MaxUniValueDepth(TreeNode node, int parentValue)
    {
        if (node == null)
        {
            return 0;
        }

        var maxLeft = MaxUniValueDepth(node.left, node.val);
        var maxRight = MaxUniValueDepth(node.right, node.val);
        var currentMax = maxLeft + maxRight;
        LongestPath = Math.Max(currentMax, LongestPath);
        return node.val == parentValue ? Math.Max(maxLeft, maxRight) + 1 : 0;
    }
}