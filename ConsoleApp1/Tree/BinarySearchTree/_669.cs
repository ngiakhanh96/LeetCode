namespace ConsoleApp1.Tree.BinarySearchTree;

public class _669
{
    public TreeNode Root { get; set; }

    private int Low { get; set; }
    private int High { get; set; }

    public TreeNode TrimBST(TreeNode root, int low, int high)
    {
        Low = low;
        High = high;
        Root = root;

        // Find the right Root
        while (Root != null && (Root.val < Low || Root.val > High))
        {
            Root = Root.val < Low
                ? Root.right
                : Root.left;
        }

        if (Root == null)
        {
            return null;
        }


        // Trim both sides of Root
        TrimBSTImpl(Root, null, false);
        TrimBSTImpl(Root, null, true);

        return Root;

    }

    private void TrimBSTImpl(TreeNode root, TreeNode parent, bool lookLeft)
    {
        var currentNode = root;
        if (!lookLeft)
        {
            while (currentNode != null && currentNode.val <= High)
            {
                parent = currentNode;
                currentNode = currentNode.right;
            }

            while (currentNode != null && currentNode.val > High)
            {
                currentNode = currentNode.left;
            }
            parent.right = currentNode;
            if (currentNode != null)
            {
                TrimBSTImpl(currentNode, parent, false);
            }
        }

        else
        {
            while (currentNode != null && currentNode.val >= Low)
            {
                parent = currentNode;
                currentNode = currentNode.left;
            }

            while (currentNode != null && currentNode.val < Low)
            {
                currentNode = currentNode.right;
            }
            parent.left = currentNode;
            if (currentNode != null)
            {
                TrimBSTImpl(currentNode, parent, true);
            }
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