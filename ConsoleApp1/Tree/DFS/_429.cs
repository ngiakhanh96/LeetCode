namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 30)]
public class _429
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        var queue = new Queue<Node>();
        if (root == null)
        {
            return result;
        }
        queue.Enqueue(root);
        var numberOfChildInCurrentLevel = 1;
        var childValuesInCurrentLevel = new List<int>();
        while (queue.Any())
        {
            var child = queue.Dequeue();
            foreach (var subChild in child.children)
            {
                queue.Enqueue(subChild);
            }

            childValuesInCurrentLevel.Add(child.val);
            numberOfChildInCurrentLevel--;
            if (numberOfChildInCurrentLevel == 0)
            {
                numberOfChildInCurrentLevel = queue.Count;
                result.Add(childValuesInCurrentLevel);
                childValuesInCurrentLevel = new List<int>();
            }
        }

        return result;
    }

    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

    public Queue<Node> BfsQueue { get; set; } = new();

    public IList<IList<int>> LevelOrder2(Node root)
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

    public IList<IList<int>> LevelOrder3(Node root)
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