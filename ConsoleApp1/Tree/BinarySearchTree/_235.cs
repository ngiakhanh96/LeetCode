namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2023, 08, 17)]
public class _235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val < Math.Min(p.val, q.val))
        {
            return LowestCommonAncestor(root.right, p, q);
        }

        return root.val > Math.Max(p.val, q.val) ? LowestCommonAncestor(root.left, p, q) : root;
    }
}