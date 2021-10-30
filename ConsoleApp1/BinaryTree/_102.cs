namespace ConsoleApp1.BinaryTree;

public class _102
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int CurrentLevel { get; set; }

    public int NumberOfNodesInCurrentLevel { get; set; }

    public IList<IList<int>> NodesInLevel { get; set; } = new List<IList<int>>();

    public bool ShouldCreateNewLevelList { get; set; }

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        Bfs(root);
        return NodesInLevel;
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
        ShouldCreateNewLevelList = true;
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

        if (ShouldCreateNewLevelList)
        {
            NodesInLevel.Add(new List<int>());
            ShouldCreateNewLevelList = false;
        }

        NodesInLevel.Last().Add(node.val);

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
            NumberOfNodesInCurrentLevel = BfsQueue.Count;
            CurrentLevel++;
            ShouldCreateNewLevelList = true;
        }

        Bfs();
    }
}