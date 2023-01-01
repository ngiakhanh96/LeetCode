namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2022, 12, 28)]
public class _98
{
    public bool IsValidBST(TreeNode root, long lowBound = long.MinValue, long upBound = long.MaxValue)
    {
        if (root is null)
        {
            return true;
        }
        return root.val > lowBound && root.val < upBound && IsValidBST(root.left, lowBound, root.val) && IsValidBST(root.right, root.val, upBound);
    }
}