namespace ConsoleApp1.BinaryTree;

public class _107
{
    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int NumberOfNodeInCurrentLevel { get; set; }

    public int CurrentLevel { get; set; }

    public IList<IList<int>> LevelOrderBottom(TreeNode root)
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

    public IList<IList<int>> LevelOrderBottom2(TreeNode root)
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
        CurrentLevel = 0;
        NumberOfNodeInCurrentLevel = BfsQueue.Count;
        Bfs();
    }

    private void Bfs()
    {
        if (BfsQueue.Count == 0)
        {
            return;
        }

        var node = BfsQueue.Dequeue();
        NumberOfNodeInCurrentLevel--;
        if (LevelOrderNodeValues[CurrentLevel] == null)
        {
            LevelOrderNodeValues[CurrentLevel] = new List<int> { node.val };
        }
        else
        {
            LevelOrderNodeValues[CurrentLevel].Add(node.val);
        }

        if (node.left != null)
        {
            BfsQueue.Enqueue(node.left);
        }

        if (node.right != null)
        {
            BfsQueue.Enqueue(node.right);
        }

        if (NumberOfNodeInCurrentLevel == 0)
        {
            CurrentLevel++;
            NumberOfNodeInCurrentLevel = BfsQueue.Count;
        }

        Bfs();
    }
}