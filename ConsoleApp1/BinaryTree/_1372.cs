namespace ConsoleApp1.BinaryTree;

public class _1372
{
    public int LongestZZ { get; set; }

    public int LongestZigZag(TreeNode root)
    {
        Dfs(root, true, 0);
        Dfs(root, false, 0);

        return LongestZZ;
    }

    private void Dfs(TreeNode root, bool shouldGoRight, int currentPathLength = 0)
    {
        if (root == null)
        {
            LongestZZ = Math.Max(LongestZZ, currentPathLength - 1);
            return;
        }

        if (shouldGoRight)
        {
            Dfs(root.right, false, ++currentPathLength);
            Dfs(root.left, true, 1);
        }
        else
        {
            Dfs(root.left, true, ++currentPathLength);
            Dfs(root.right, false, 1);
        }
    }

    public int LongestZigZag2(TreeNode root)
    {
        return Dfs2(root)[2];
    }

    //result is the longest zigzag in left and right, from left or right child downward, not necessary to start in left or right child
    //See https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/discuss/531867/JavaPython-DFS-Solution
    private int[] Dfs2(TreeNode root)
    {
        if (root == null)
        {
            return new int[] { -1, -1, -1 };
        }

        var left = Dfs2(root.left);
        var right = Dfs2(root.right);

        var res = Math.Max(Math.Max(left[1], right[0]) + 1, Math.Max(left[2], right[2]));
        return new int[] { left[1] + 1, right[0] + 1, res };
    }
}