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

    public TreeNode TrimBST2(TreeNode root, int low, int high)
    {
        Root = root;
        Dfs(root, low, high, null);

        return Root;
    }

    private void Dfs(TreeNode node, int low, int high, TreeNode parentNode)
    {
        if (node is null)
        {
            return;
        }

        if (node.val < low || node.val > high)
        {
            var isFromLeft = node.val < low;
            var replacement = FindReplacement(node, low, high);
            node = replacement;
            if (parentNode is not null)
            {
                if (isFromLeft)
                {
                    parentNode.left = replacement;
                }
                else
                {
                    parentNode.right = replacement;
                }
            }
            else
            {
                Root = replacement;
            }
        }
        Dfs(node?.left, low, high, node);
        Dfs(node?.right, low, high, node);
    }

    private TreeNode FindReplacement(TreeNode node, int low, int high)
    {
        if (node is null || (node.val >= low && node.val <= high))
        {
            return node;
        }

        return FindReplacement(node.val < low ? node.right : node.left, low, high);
    }
}