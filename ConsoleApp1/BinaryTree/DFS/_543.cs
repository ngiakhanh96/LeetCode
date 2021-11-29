namespace ConsoleApp1.BinaryTree.DFS;

public class _543
{
    public int MaxDiameter { get; set; }
    public int DiameterOfBinaryTree(TreeNode root)
    {
        MaxDepth(root);
        return MaxDiameter;
    }

    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var maxLeft = MaxDepth(root.left);
        var maxRight = MaxDepth(root.right);
        var currentMax = maxLeft + maxRight;
        MaxDiameter = Math.Max(currentMax, MaxDiameter);
        return Math.Max(maxLeft, maxRight) + 1;
    }
}