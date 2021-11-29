namespace ConsoleApp1.BinaryTree.BinarySearchTree;

public class _230
{
    public int Count { get; set; }

    public int CurrentSmallest { get; set; }

    public int KthSmallest(TreeNode root, int k)
    {
        if (root is null)
        {
            return CurrentSmallest;
        }

        KthSmallest(root.left, k);
        if (Count == k)
        {
            return CurrentSmallest;
        }
        CurrentSmallest = root.val;
        Count++;
        KthSmallest(root.right, k);

        return CurrentSmallest;
    }
}