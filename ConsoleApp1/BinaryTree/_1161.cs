namespace ConsoleApp1.BinaryTree;

public class _1161
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int CurrentLevel { get; set; }

    public int NumOfNodesInCurrentLevel { get; set; }

    public int SmallestLevelWithMaxSum { get; set; }

    public int CurrentLevelSum { get; set; }

    public int MaxSum { get; set; }

    public int MaxLevelSum(TreeNode root)
    {
        Bfs(root);
        return SmallestLevelWithMaxSum;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        NumOfNodesInCurrentLevel = BfsQueue.Count;
        CurrentLevel = 1;
        SmallestLevelWithMaxSum = 1;
        CurrentLevelSum = 0;
        MaxSum = root.val;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }

        var node = BfsQueue.Dequeue();
        NumOfNodesInCurrentLevel--;
        CurrentLevelSum += node.val;

        if (node.left != null)
        {
            BfsQueue.Enqueue(node.left);
        }

        if (node.right != null)
        {
            BfsQueue.Enqueue(node.right);
        }

        if (NumOfNodesInCurrentLevel == 0)
        {
            if (MaxSum < CurrentLevelSum)
            {
                MaxSum = CurrentLevelSum;
                SmallestLevelWithMaxSum = CurrentLevel;
            }

            NumOfNodesInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
            CurrentLevelSum = 0;
        }

        Bfs();
    }
}