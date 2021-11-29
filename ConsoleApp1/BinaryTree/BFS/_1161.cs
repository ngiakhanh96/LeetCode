namespace ConsoleApp1.BinaryTree.BFS;

public class _1161
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int SmallestLevelWithMaxSum { get; set; }

    public int MaxLevelSum(TreeNode root)
    {
        Bfs(root);
        return SmallestLevelWithMaxSum;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        var currentLevel = 0;
        SmallestLevelWithMaxSum = 1;

        var maxSum = root.val;
        while (BfsQueue.Count > 0)
        {
            var numOfNodesInCurrentLevel = BfsQueue.Count;
            var currentLevelSum = 0;
            currentLevel++;
            for (int i = 0; i < numOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();
                currentLevelSum += node.val;

                if (node.left != null)
                {
                    BfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    BfsQueue.Enqueue(node.right);
                }

                if (i == numOfNodesInCurrentLevel - 1)
                {
                    if (maxSum < currentLevelSum)
                    {
                        maxSum = currentLevelSum;
                        SmallestLevelWithMaxSum = currentLevel;
                    }
                }
            }
        }
    }
}