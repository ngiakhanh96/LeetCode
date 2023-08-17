namespace ConsoleApp1.Tree.DFS;

[LastVisited(2023, 08, 17)]
public class _145
{
    public IList<int> PostorderNodeValues { get; set; } = new List<int>();
    public IList<int> PostorderTraversal(TreeNode root)
    {
        Dfs(root);
        return PostorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        Dfs(root.left);
        Dfs(root.right);
        PostorderNodeValues.Add(root.val);
    }

    public IList<int> PostorderTraversal2(TreeNode root)
    {
        var postorderTraversal = new List<int>();
        var stack = new Stack<(TreeNode, bool)>();
        if (root == null)
        {
            return postorderTraversal;
        }
        var currentNode = root;
        var isLeft = true;
        while (stack.Count > 0 || currentNode != null)
        {
            while (currentNode != null)
            {
                stack.Push((currentNode, isLeft));
                currentNode = currentNode.left;
                isLeft = true;
            }

            if (isLeft)
            {
                (currentNode, _) = stack.Peek();
            }
            else
            {
                (currentNode, isLeft) = stack.Pop();
                postorderTraversal.Add(currentNode.val);
                while (!isLeft)
                {
                    (currentNode, isLeft) = stack.Pop();
                    postorderTraversal.Add(currentNode.val);
                }

                if (!stack.TryPeek(out var result))
                {
                    break;
                }

                currentNode = result.Item1;
            }

            isLeft = false;
            currentNode = currentNode.right;
        }
        return postorderTraversal;
    }
}