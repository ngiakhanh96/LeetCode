using ConsoleApp1.Tree;

namespace ConsoleApp1.BFS;

[LastVisited(2023, 08, 15)]
public class _226
{
    public TreeNode InvertTree(TreeNode root)
    {
        var bfsQueue = new Queue<TreeNode>();
        bfsQueue.Enqueue(root);
        while (bfsQueue.Count > 0)
        {
            var currentNode = bfsQueue.Dequeue();
            if (currentNode != null)
            {
                (currentNode.left, currentNode.right) = (currentNode.right, currentNode.left);
                bfsQueue.Enqueue(currentNode.left);
                bfsQueue.Enqueue(currentNode.right);
            }
        }

        return root;
    }

    //DFS
    public TreeNode InvertTree2(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        (root.left, root.right) = (root.right, root.left);

        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }
}