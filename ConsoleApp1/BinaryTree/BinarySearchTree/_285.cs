namespace ConsoleApp1.BinaryTree.BinarySearchTree;

public class _285
{
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        var (node, maxRangeNode) = SearchBST(root, p.val, null);
        return node.right is null ? maxRangeNode : FindInOrderSuccessor(node.right);
    }

    private (TreeNode node, TreeNode maxRangeNode) SearchBST(TreeNode root, int val, TreeNode maxRangeNode)
    {
        if (root is null || val == root.val)
        {
            return (root, maxRangeNode);
        }

        return val > root.val ? SearchBST(root.right, val, maxRangeNode) : SearchBST(root.left, val, root);
    }
    private TreeNode FindInOrderSuccessor(TreeNode node)
    {
        return node.left is null ? node : FindInOrderSuccessor(node.left);
    }
}