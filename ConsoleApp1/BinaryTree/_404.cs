namespace ConsoleApp1.BinaryTree;

public class _404
{
    public int Sum { get; set; } = 0;

    public int SumOfLeftLeaves(TreeNode root, bool isLeft = false)
    {
        if (root == null)
        {
            return Sum;
        }
        if (root.left == null && root.right == null && isLeft)
        {
            Sum += root.val;
        }
        SumOfLeftLeaves(root.left, true);
        SumOfLeftLeaves(root.right, false);
        return Sum;
    }
}