namespace ConsoleApp1.BinaryTree.BFS;

public class _102
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

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
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            NodesInLevel.Add(new List<int>());
            for (int i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();

                if (ShouldCreateNewLevelList)
                {
                    NodesInLevel.Add(new List<int>());
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
            }
        }
    }
}