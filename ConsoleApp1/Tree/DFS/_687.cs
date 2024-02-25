namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _687
{
    public int LongestPath { get; set; }
    public int LongestUnivaluePath(TreeNode root)
    {
        MaxUniValueDepth(root, 0);
        return LongestPath;
    }

    private int MaxUniValueDepth(TreeNode node, int parentValue)
    {
        if (node == null)
        {
            return 0;
        }

        var maxLeft = MaxUniValueDepth(node.left, node.val);
        var maxRight = MaxUniValueDepth(node.right, node.val);
        var currentMax = maxLeft + maxRight;
        LongestPath = Math.Max(currentMax, LongestPath);
        return node.val == parentValue ? Math.Max(maxLeft, maxRight) + 1 : 0;
    }

    private int _longestUnivaluePath;
    public int LongestUnivaluePath2(TreeNode root, bool isRoot = true)
    {
        if (root == null)
        {
            return 0;
        }
        var leftChildLongestUnivaluePath = LongestUnivaluePath2(root.left, false);
        var leftChildLongestUnivaluePathUntilCurrentNode = 0;
        if (root.left != null && root.left.val == root.val)
        {
            leftChildLongestUnivaluePathUntilCurrentNode = leftChildLongestUnivaluePath + 1;
        }

        var rightChildLongestUnivaluePath = LongestUnivaluePath2(root.right, false);
        var rightChildLongestUnivaluePathUntilCurrentNode = 0;
        if (root.right != null && root.right.val == root.val)
        {
            rightChildLongestUnivaluePathUntilCurrentNode = rightChildLongestUnivaluePath + 1;
        }

        _longestUnivaluePath = Math.Max(_longestUnivaluePath, leftChildLongestUnivaluePathUntilCurrentNode + rightChildLongestUnivaluePathUntilCurrentNode);

        return isRoot
            ? _longestUnivaluePath
            : Math.Max(leftChildLongestUnivaluePathUntilCurrentNode, rightChildLongestUnivaluePathUntilCurrentNode);
    }
}