namespace ConsoleApp1.BinaryTree;

public class _515
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int CurrentLevel { get; set; }

    public int NumberOfNodesInCurrentLevel { get; set; }

    public int CurrentLargestValueInCurrentLevel { get; set; } = int.MinValue;

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
        CurrentLevel = 0;
        NumberOfNodesInCurrentLevel = BfsQueue.Count;
        CurrentLargestValueInCurrentLevel = int.MinValue;
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

        if (node.val > CurrentLargestValueInCurrentLevel)
        {
            CurrentLargestValueInCurrentLevel = node.val;
        }

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
            LargestValuesInEachLevel.Add(CurrentLargestValueInCurrentLevel);
            NumberOfNodesInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
            CurrentLargestValueInCurrentLevel = int.MinValue;
        }

        Bfs();
    }
}