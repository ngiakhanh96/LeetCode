namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2022, 12, 28)]
public class _669
{
    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        var newRoot = root;
        while (newRoot != null && (newRoot.val > high || newRoot.val < low))
        {
            newRoot = newRoot.val > high ? newRoot.left : newRoot.right;
        }

        if (newRoot == null)
        {
            return null;
        }

        TrimHigh(newRoot, high);
        TrimLow(newRoot, low);
        return newRoot;
    }

    private void TrimHigh(TreeNode currentNode, int high)
    {
        while (currentNode != null)
        {
            var nextNode = currentNode.right;
            while (nextNode != null && nextNode.val > high)
            {
                nextNode = nextNode.left;
            }
            currentNode.right = nextNode;
            currentNode = nextNode;
        }
    }

    private void TrimLow(TreeNode currentNode, int low)
    {
        while (currentNode != null)
        {
            var nextNode = currentNode.left;
            while (nextNode != null && nextNode.val < low)
            {
                nextNode = nextNode.right;
            }
            currentNode.left = nextNode;
            currentNode = nextNode;
        }
    }
}