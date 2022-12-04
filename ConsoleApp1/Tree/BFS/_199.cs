namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 12, 05)]
public class _199
{
    public IList<int> RightSideView(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var numberOfNodesInCurrentLevel = 1;

        while (queue.Any())
        {
            var currentNode = queue.Dequeue();
            if (currentNode.left != null)
            {
                queue.Enqueue(currentNode.left);
            }

            if (currentNode.right != null)
            {
                queue.Enqueue(currentNode.right);
            }

            numberOfNodesInCurrentLevel--;

            if (numberOfNodesInCurrentLevel == 0)
            {
                result.Add(currentNode.val);
                numberOfNodesInCurrentLevel = queue.Count;
            }
        }

        return result;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public IList<int> RightSideValues { get; set; } = new List<int>();

    public IList<int> RightSideView2(TreeNode root)
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
            for (var i = 0; i < numberOfNodesInCurrentLevel; i++)
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