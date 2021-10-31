﻿namespace ConsoleApp1.BinaryTree;

public class _429
{
    public IList<int>[] LevelOrderNodeValues { get; set; } = new IList<int>[1000];

    public Queue<Node> BfsQueue { get; set; } = new Queue<Node>();

    public int NumberOfNodeInCurrentLevel { get; set; }

    public int CurrentLevel { get; set; }

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

        foreach (var subNode in node.children)
        {
            if (subNode != null)
            {
                BfsQueue.Enqueue(subNode);
            }
        }

        if (NumberOfNodeInCurrentLevel == 0)
        {
            CurrentLevel++;
            NumberOfNodeInCurrentLevel = BfsQueue.Count;
        }

        Bfs();
    }
}