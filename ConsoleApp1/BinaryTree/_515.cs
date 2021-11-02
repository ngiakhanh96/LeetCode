namespace ConsoleApp1.BinaryTree;

public class _515
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public IList<int> LargestValuesInEachLevel { get; set; } = new List<int>();

    public IList<int> LargestValues(TreeNode root)
    {
        Bfs(root);
        return LargestValuesInEachLevel;
    }

    private void Bfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        BfsQueue.Enqueue(root);
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            var currentLargestValueInCurrentLevel = int.MinValue;
            for (int i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();

                if (node.val > currentLargestValueInCurrentLevel)
                {
                    currentLargestValueInCurrentLevel = node.val;
                }

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
                    LargestValuesInEachLevel.Add(currentLargestValueInCurrentLevel);
                }
            }
        }
    }
}