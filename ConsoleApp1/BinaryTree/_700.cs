namespace ConsoleApp1.BinaryTree;

public class _700
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null || val == root.val)
        {
            return root;
        }

        return SearchBST(val > root.val ? root.right : root.left, val);
    }
}