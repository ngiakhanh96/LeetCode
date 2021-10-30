namespace ConsoleApp1.BinaryTree;

public class _1302
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int CurrentLevel { get; set; }

    public int NumberOfNodesInCurrentLevel { get; set; }

    public int SumOfNodeValuesInCurrentLevel { get; set; }

    public int SumOfNodeValuesInLowestLevel { get; set; }

    public int DeepestLeavesSum(TreeNode root)
    {
        Bfs(root);
        return SumOfNodeValuesInLowestLevel;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        CurrentLevel = 0;
        NumberOfNodesInCurrentLevel = BfsQueue.Count;
        SumOfNodeValuesInCurrentLevel = 0;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }

        var node = BfsQueue.Dequeue();
        NumberOfNodesInCurrentLevel--;

        SumOfNodeValuesInCurrentLevel += node.val;

        if (node.left != null)
        {
            BfsQueue.Enqueue(node.left);
        }

        if (node.right != null)
        {
            BfsQueue.Enqueue(node.right);
        }

        if (NumberOfNodesInCurrentLevel == 0)
        {
            SumOfNodeValuesInLowestLevel = SumOfNodeValuesInCurrentLevel;
            NumberOfNodesInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
            SumOfNodeValuesInCurrentLevel = 0;
        }

        Bfs();
    }
}