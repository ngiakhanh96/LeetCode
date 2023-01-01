namespace ConsoleApp1.Tree.BinarySearchTree;

[LastVisited(2022, 12, 28)]
public class _450
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        var (node, parentNode, isLeft) = SearchNode(root, key);
        if (node == null)
        {
            return root;
        }

        if (node.left != null && node.right != null)
        {
            var parentOfLeftMostOnRightSubTree = node;
            var leftMostOnRightSubTree = node.right;
            var isRight = true;
            while (leftMostOnRightSubTree.left != null)
            {
                isRight = false;
                parentOfLeftMostOnRightSubTree = leftMostOnRightSubTree;
                leftMostOnRightSubTree = leftMostOnRightSubTree.left;
            }

            node.val = leftMostOnRightSubTree.val;
            if (isRight)
            {
                parentOfLeftMostOnRightSubTree.right = leftMostOnRightSubTree.right;
            }
            else
            {
                parentOfLeftMostOnRightSubTree.left = leftMostOnRightSubTree.right;
            }
        }
        else
        {
            if (parentNode == null)
            {
                root = node.left ?? node.right;
            }
            else
            {
                if (isLeft)
                {
                    parentNode.left = node.left ?? node.right;
                }
                else
                {
                    parentNode.right = node.left ?? node.right;
                }
            }

        }

        return root;

    }

    private (TreeNode searchedNode, TreeNode parentNode, bool isLeft) SearchNode(TreeNode root, int key, TreeNode parentNode = null, bool isLeft = true)
    {
        if (root == null || root.val == key)
        {
            return (root, parentNode, isLeft);
        }

        return key < root.val ? SearchNode(root.left, key, root, true) : SearchNode(root.right, key, root, false);
    }
}