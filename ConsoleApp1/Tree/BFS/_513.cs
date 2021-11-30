namespace ConsoleApp1.Tree.BFS;

public class _513
{
    public Queue<TreeNode> BfsQueue { get; set; } = new Queue<TreeNode>();

    public int BottomLeftMostValue { get; set; }

    public int FindBottomLeftValue(TreeNode root)
    {
        Bfs(root);
        return BottomLeftMostValue;
    }

    private void Bfs(TreeNode root)
    {
        BfsQueue.Enqueue(root);
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numberOfNodesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (int i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();
                if (i == 0)
                {
                    BottomLeftMostValue = node.val;
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