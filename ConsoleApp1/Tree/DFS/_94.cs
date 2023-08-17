namespace ConsoleApp1.Tree.DFS;

[LastVisited(2023, 08, 17)]
public class _94
{
    public IList<int> InorderNodeValues { get; set; } = new List<int>();
    public IList<int> InorderTraversal(TreeNode root)
    {
        Dfs(root);
        return InorderNodeValues;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        Dfs(root.left);
        InorderNodeValues.Add(root.val);
        Dfs(root.right);
    }

    public IList<int> InorderTraversal2(TreeNode root)
    {
        var inorderTraversal = new List<int>();
        var stack = new Stack<(TreeNode, bool)>();
        if (root == null)
        {
            return inorderTraversal;
        }
        var currentNode = root;
        var isLeft = true;
        do
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

            inorderTraversal.Add(currentNode.val);
            isLeft = false;
            currentNode = currentNode.right;
        } while (stack.Count > 0);
        return inorderTraversal;
    }
}