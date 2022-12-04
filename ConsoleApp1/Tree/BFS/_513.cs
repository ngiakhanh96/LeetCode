namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 12, 05)]
public class _513
{
    public int FindBottomLeftValue(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var numOfNodesInCurrentLevel = 1;
        var result = root.val;

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

            numOfNodesInCurrentLevel--;
            if (numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                if (numOfNodesInCurrentLevel > 0)
                {
                    result = queue.Peek().val;
                }
            }
        }

        return result;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int BottomLeftMostValue { get; set; }

    public int FindBottomLeftValue2(TreeNode root)
    {
        Bfs(root);
        return BottomLeftMostValue;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();
                if (i == 0)
                {
                    BottomLeftMostValue = node.val;
                }

                if (node.left != null)
                {
                    BfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    BfsQueue.Enqueue(node.right);
                }
            }
        }
    }
}