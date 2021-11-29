namespace ConsoleApp1.BinaryTree.BFS;

public class _1302
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int SumOfNodeValuesInLowestLevel { get; set; }

    public int DeepestLeavesSum(TreeNode root)
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
            for (int i = 0; i < numberOfNodesInCurrentLevel; i++)
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