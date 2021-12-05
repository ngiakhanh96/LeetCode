namespace ConsoleApp1.Tree.DFS;

public class _429
{
    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

    public Queue<Node> BfsQueue { get; set; } = new Queue<Node>();

    public IList<IList<int>> LevelOrder(Node root)
    {
        Dfs(root, 0);
        return LevelOrderNodeValues.Where(x => x != null).ToList();
    }

    private void Dfs(Node root, int level)
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

        foreach (var node in root.children)
        {
            Dfs(node, level + 1);
        }
    }

    public IList<IList<int>> LevelOrder2(Node root)
    {
        Bfs(root, 0);
        return LevelOrderNodeValues.Where(x => x != null).ToList();
    }

    private void Bfs(Node root, int level)
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

                foreach (var subNode in node.children)
                {
                    if (subNode != null)
                    {
                        BfsQueue.Enqueue(subNode);
                    }
                }
            }
        }
    }
}