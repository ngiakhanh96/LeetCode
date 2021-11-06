namespace ConsoleApp1.BinaryTree;

public class _450
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        var (node, parentNode) = SearchBST(root, key);
        if (node is null)
        {
            return root;
        }

        if (node.left is not null && node.right is not null)
        {
            var (inOrderSuccessor, parentInOrderSuccessor) = FindInOrderSuccessor(node.right, node);
            var temp = node.val;
            node.val = inOrderSuccessor.val;
            inOrderSuccessor.val = temp;
            node = inOrderSuccessor;
            parentNode = parentInOrderSuccessor;
        }

        if (node.left is null && node.right is null)
        {
            if (parentNode is null)
            {
                return null;
            }

            if (parentNode.left == node)
            {
                parentNode.left = null;
            }
            else
            {
                parentNode.right = null;
            }
        }
        else
        {
            var childNode = node.left ?? node.right;
            if (parentNode is null)
            {
                return childNode;
            }

            if (parentNode.left == node)
            {
                parentNode.left = childNode;
            }
            else
            {
                parentNode.right = childNode;
            }
        }
        return root;
    }

    private (TreeNode node, TreeNode parentNode) SearchBST(TreeNode root, int val, TreeNode parentNode = null)
    {
        if (root is null || val == root.val)
        {
            return (root, parentNode);
        }

        return val > root.val ? SearchBST(root.right, val, root) : SearchBST(root.left, val, root);
    }

    private (TreeNode node, TreeNode parentNode) FindInOrderSuccessor(TreeNode node, TreeNode parentNode)
    {
        return node.left is null ? (node, parentNode) : FindInOrderSuccessor(node.left, node);
    }
}