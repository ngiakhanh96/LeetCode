namespace ConsoleApp1.BinaryTree;

public class _701
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root is null)
        {
            return new TreeNode(val);
        }

        if (val > root.val)
        {
            if (root.right is null)
            {
                root.right = new TreeNode(val);
            }
            else
            {
                InsertIntoBST(root.right, val);
            }
        }
        else
        {
            if (root.left is null)
            {
                root.left = new TreeNode(val);
            }
            else
            {
                InsertIntoBST(root.left, val);
            }
        }
        return root;
    }
}