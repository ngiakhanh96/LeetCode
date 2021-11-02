namespace ConsoleApp1.BinaryTree;

public class _199
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public IList<int> RightSideValues { get; set; } = new List<int>();

    public IList<int> RightSideView(TreeNode root)
    {
        Bfs(root);
        return RightSideValues;
    }

    private void Bfs(TreeNode root)
    {
        if (root is null)
        {
            return;
        }
        BfsQueue.Enqueue(root);
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            for (int i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();

                if (node.left != null)
                {
                    BfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    BfsQueue.Enqueue(node.right);
                }

                if (i == numberOfNodesInCurrentLevel - 1)
                {
                    RightSideValues.Add(node.val);
                }
            }
        }
    }
}