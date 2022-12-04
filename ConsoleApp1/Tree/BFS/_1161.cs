namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 12, 05)]
public class _1161
{
    public int MaxLevelSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var numOfNodesInCurrentLevel = 1;
        var sumOfNodeValuesInCurrentLevel = 0;
        var maxSumAllNodesInLevelX = int.MinValue;
        var currentLevel = 1;
        var smallestLevelX = 1;

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

            sumOfNodeValuesInCurrentLevel += currentNode.val;
            numOfNodesInCurrentLevel--;

            if (numOfNodesInCurrentLevel == 0)
            {
                if (sumOfNodeValuesInCurrentLevel > maxSumAllNodesInLevelX)
                {
                    maxSumAllNodesInLevelX = sumOfNodeValuesInCurrentLevel;
                    smallestLevelX = currentLevel;
                }
                numOfNodesInCurrentLevel = queue.Count;
                sumOfNodeValuesInCurrentLevel = 0;
                currentLevel++;
            }
        }

        return smallestLevelX;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int SmallestLevelWithMaxSum { get; set; }

    public int MaxLevelSum2(TreeNode root)
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
            for (var i = 0; i < numOfNodesInCurrentLevel; i++)
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