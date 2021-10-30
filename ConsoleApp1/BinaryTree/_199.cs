namespace ConsoleApp1.BinaryTree;

public class _199
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int CurrentLevel { get; set; }

    public int NumberOfNodesInCurrentLevel { get; set; }

    public IList<int> RightSideValues { get; set; } = new List<int>();

    public IList<int> RightSideView(TreeNode root)
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
        CurrentLevel = 0;
        NumberOfNodesInCurrentLevel = BfsQueue.Count;
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
            RightSideValues.Add(node.val);
            NumberOfNodesInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
        }

        Bfs();
    }
}