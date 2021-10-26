namespace ConsoleApp1.BinaryTree;

public class _429
{
    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

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
}