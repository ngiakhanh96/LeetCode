namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2022, 12, 28)]
public class _285
{
    private bool _nextNodeWillBeInOrderSuccessor;
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (root == null)
        {
            return null;
        }

        var result = InorderSuccessor(root.left, p);
        if (result != null)
        {
            return result;
        }

        if (_nextNodeWillBeInOrderSuccessor)
        {
            return root;
        }

        if (root.val == p.val)
        {
            _nextNodeWillBeInOrderSuccessor = true;
        }

        return InorderSuccessor(root.right, p);
    }

    public TreeNode InorderSuccessor2(TreeNode root, TreeNode p)
    {
        if (root == null)
        {
            return null;
        }

        var inorderSuccessorAbove = FindInorderSuccessorAbove(root, null, p.val);
        var inorderSuccessorBelow = FindInorderSuccessorBelow(p);

        return inorderSuccessorBelow ?? inorderSuccessorAbove;
    }

    private TreeNode FindInorderSuccessorAbove(TreeNode root, TreeNode parent, int val)
    {
        if (root == null)
        {
            return parent;
        }

        if (val == root.val)
        {
            return parent;
        }

        return val > root.val
            ? FindInorderSuccessorAbove(root.right, parent, val)
            : FindInorderSuccessorAbove(root.left, root, val);
    }

    private TreeNode FindInorderSuccessorBelow(TreeNode node)
    {
        if (node.right == null)
        {
            return null;
        }

        var currentNode = node.right;
        while (currentNode.left != null)
        {
            currentNode = currentNode.left;
        }

        return currentNode;
    }

    public TreeNode InorderSuccessor3(TreeNode root, TreeNode p)
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