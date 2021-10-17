using ConsoleApp1.BinaryTree;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var node11 = new TreeNode(11);
        var node_3 = new TreeNode(-3, right: node11);

        var node3__2 = new TreeNode(3);
        var node_2 = new TreeNode(-2);
        var node3__1 = new TreeNode(3, node3__2, node_2);

        var node1 = new TreeNode(1);
        var node2 = new TreeNode(2, right: node1);
        var node5 = new TreeNode(5, node3__1, node2);

        var node10 = new TreeNode(1, new TreeNode(-2), new TreeNode(-3));

        var t = new _437().PathSum(node10, -1);
        Console.WriteLine('s');
    }
}