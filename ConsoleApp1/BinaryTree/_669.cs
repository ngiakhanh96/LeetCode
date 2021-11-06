namespace ConsoleApp1.BinaryTree;

public class _669
{
    public TreeNode Root { get; set; }

    public TreeNode TrimBST(TreeNode root, int low, int high)
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

        if (node.val < low)
        {
            var replacement = FindReplacement(node.right, low, high);
            node = replacement;
            if (parentNode is not null)
            {
                parentNode.left = replacement;
            }
            else
            {
                Root = replacement;
            }
        }
        else if (node.val > high)
        {
            var replacement = FindReplacement(node.left, low, high);
            node = replacement;
            if (parentNode is not null)
            {
                parentNode.right = replacement;
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