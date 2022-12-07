namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 12, 05)]
public class _1302
{
    public int DeepestLeavesSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var numberOfNodesInCurrentLevel = 1;
        var sumOfNodeValuesInCurrentLevel = 0;

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
            numberOfNodesInCurrentLevel--;

            if (numberOfNodesInCurrentLevel == 0)
            {
                numberOfNodesInCurrentLevel = queue.Count;
                if (numberOfNodesInCurrentLevel == 0)
                {
                    return sumOfNodeValuesInCurrentLevel;
                }
                sumOfNodeValuesInCurrentLevel = 0;
            }

        }

        return sumOfNodeValuesInCurrentLevel;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new();

    public int SumOfNodeValuesInLowestLevel { get; set; }

    public int DeepestLeavesSum2(TreeNode root)
    {
        Bfs(root);
        return SumOfNodeValuesInLowestLevel;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            var sumOfNodesInCurrentLevel = 0;
            for (var i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();

                sumOfNodesInCurrentLevel += node.val;

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
                    SumOfNodeValuesInLowestLevel = sumOfNodesInCurrentLevel;
                }
            }
        }
    }
}