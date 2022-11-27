namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _404
{
    public int Sum { get; set; }

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
        SumOfLeftLeaves(root.right);
        return Sum;
    }
}