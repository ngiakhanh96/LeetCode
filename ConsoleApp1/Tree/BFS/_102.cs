namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 11, 30)]
public class _102
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        var result = new List<IList<int>>();

        if (root == null)
        {
            return result;
        }

        var nodeValuesInCurrentLevel = new List<int>();
        var numOfNodesInCurrentLevel = 1;
        queue.Enqueue(root);
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

            nodeValuesInCurrentLevel.Add(currentNode.val);
            numOfNodesInCurrentLevel--;
            if (numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                result.Add(nodeValuesInCurrentLevel);
                nodeValuesInCurrentLevel = new List<int>();
            }

        }

        return result;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public IList<IList<int>> NodesInLevel { get; set; } = new List<IList<int>>();

    public bool ShouldCreateNewLevelList { get; set; }

    public IList<IList<int>> LevelOrder2(TreeNode root)
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
            for (var i = 0; i < numberOfNodesInCurrentLevel; i++)
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