namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 11, 30)]
public class _107
{
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        queue.Enqueue(root);
        var numOfNodesInCurrentLevel = 1;
        var nodeValuesInCurrentLevel = new List<int>();

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

            numOfNodesInCurrentLevel--;
            nodeValuesInCurrentLevel.Add(currentNode.val);
            if (numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                result.Add(nodeValuesInCurrentLevel);
                nodeValuesInCurrentLevel = new List<int>();
            }
        }

        result.Reverse();

        return result;
    }

    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public IList<IList<int>> LevelOrderBottom2(TreeNode root)
    {
        Dfs(root, 0);
        return LevelOrderNodeValues.Where(x => x != null).Reverse().ToList();
    }

    private void Dfs(TreeNode root, int level)
    {
        if (root == null)
        {
            return;
        }

        if (LevelOrderNodeValues[level] == null)
        {
            LevelOrderNodeValues[level] = new List<int> { root.val };
        }
        else
        {
            LevelOrderNodeValues[level].Add(root.val);
        }

        Dfs(root.left, level + 1);
        Dfs(root.right, level + 1);
    }

    public IList<IList<int>> LevelOrderBottom3(TreeNode root)
    {
        Bfs(root, 0);
        return LevelOrderNodeValues.Where(x => x != null).Reverse().ToList();
    }

    private void Bfs(TreeNode root, int level)
    {
        if (root == null)
        {
            return;
        }

        BfsQueue.Enqueue(root);
        var currentLevel = -1;

        while (BfsQueue.Count > 0)
        {
            var numberOfNodeInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numberOfNodeInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();
                if (LevelOrderNodeValues[currentLevel] == null)
                {
                    LevelOrderNodeValues[currentLevel] = new List<int> { node.val };
                }
                else
                {
                    LevelOrderNodeValues[currentLevel].Add(node.val);
                }

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