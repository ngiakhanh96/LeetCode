namespace ConsoleApp1.BinaryTree.BinarySearchTree;

public class _98
{
    public bool IsValidBST(TreeNode root, long lowBound = long.MinValue, long upBound = long.MaxValue)
    {
        if (root is null)
        {
            return true;
        }

        if (root.val <= lowBound || root.val >= upBound)
        {
            return false;
        }
        return IsValidBST(root.left, lowBound, root.val) && IsValidBST(root.right, root.val, upBound);
    }
}