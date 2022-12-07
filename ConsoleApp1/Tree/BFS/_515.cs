namespace ConsoleApp1.Tree.BFS;

[LastVisited(2022, 12, 05)]
public class _515
{
    public IList<int> LargestValues(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var numOfNodesInCurrentLevel = 1;
        var maxValueInCurrentLevel = int.MinValue;

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

            maxValueInCurrentLevel = Math.Max(maxValueInCurrentLevel, currentNode.val);
            numOfNodesInCurrentLevel--;
            if (numOfNodesInCurrentLevel == 0)
            {
                result.Add(maxValueInCurrentLevel);
                maxValueInCurrentLevel = int.MinValue;
                numOfNodesInCurrentLevel = queue.Count;
            }
        }

        return result;
    }

    public Queue<TreeNode> BfsQueue { get; set; } = new();

    public IList<int> LargestValuesInEachLevel { get; set; } = new List<int>();

    public IList<int> LargestValues2(TreeNode root)
    {
        Bfs(root);
        return LargestValuesInEachLevel;
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
            var currentLargestValueInCurrentLevel = int.MinValue;
            for (var i = 0; i < numberOfNodesInCurrentLevel; i++)
            {
                var node = BfsQueue.Dequeue();

                if (node.val > currentLargestValueInCurrentLevel)
                {
                    currentLargestValueInCurrentLevel = node.val;
                }

                if (node.left != null)
                {
                    BfsQueue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    BfsQueue.Enqueue(node.right);
                }

                if (i == numberOfNodesInCurrentLevel - 1)
                {
                    LargestValuesInEachLevel.Add(currentLargestValueInCurrentLevel);
                }
            }
        }
    }
}