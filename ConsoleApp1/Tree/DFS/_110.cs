namespace ConsoleApp1.Tree.DFS;

[LastVisited(2023, 08, 17)]
public class _110
{
    public bool IsBalanced(TreeNode root)
    {
        return IsBalancedImpl(root).Item1;
    }

    private (bool, int) IsBalancedImpl(TreeNode root)
    {
        if (root == null)
        {
            return (true, 0);
        }
        var (isLeftBalance, leftHeight) = IsBalancedImpl(root.left);
        if (!isLeftBalance)
        {
            return (false, 0);
        }
        var (isRightBalance, rightHeight) = IsBalancedImpl(root.right);
        if (!isRightBalance)
        {
            return (false, 0);
        }
        return (Math.Abs(leftHeight - rightHeight) <= 1, Math.Max(leftHeight, rightHeight) + 1);
    }
}