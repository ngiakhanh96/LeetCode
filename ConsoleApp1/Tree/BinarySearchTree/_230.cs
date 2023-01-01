namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2022, 12, 28)]
public class _230
{
    private int _currentKSmallest = 1;
    public int KthSmallest(TreeNode root, int k)
    {
        if (root == null)
        {
            return -1;
        }
        var result = KthSmallest(root.left, k);
        if (result > -1)
        {
            return result;
        }

        if (_currentKSmallest == k)
        {
            return root.val;
        }
        _currentKSmallest++;

        return KthSmallest(root.right, k);
    }
}