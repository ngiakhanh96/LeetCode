namespace ConsoleApp1.Tree.DFS;

[LastVisited(2023, 08, 17)]
public class _144
{
    public IList<int> PreorderNodeValues { get; set; } = new List<int>();
    public IList<int> PreorderTraversal(TreeNode root)
    {
        Dfs(root);
        return PreorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        PreorderNodeValues.Add(root.val);
        Dfs(root.left);
        Dfs(root.right);
    }

    public IList<int> PreorderTraversal2(TreeNode root)
    {
        var preorderTraversal = new List<int>();
        var stack = new Stack<(TreeNode, bool)>();
        if (root == null)
        {
            return preorderTraversal;
        }
        var currentNode = root;
        var isLeft = true;
        do
        {
            while (currentNode != null)
            {
                preorderTraversal.Add(currentNode.val);
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
                do
                {
                    (_, isLeft) = stack.Pop();
                } while (!isLeft && stack.Count > 0);

                if (stack.Count == 0)
                {
                    break;
                }

                (currentNode, _) = stack.Peek();
            }

            isLeft = false;
            currentNode = currentNode.right;
        } while (stack.Count > 0);
        return preorderTraversal;
    }
}