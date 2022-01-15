namespace ConsoleApp1.Tree.DFS
{
    public class _113
    {
        public List<IList<int>> Paths { get; set; } = new List<IList<int>>();
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            Dfs(root, 0, targetSum, new List<int>());
            return Paths;
        }

        private void Dfs(TreeNode node, int sum, int targetSum, List<int> currentPath)
        {
            if (node == null)
            {
                return;
            }
            sum += node.val;
            currentPath.Add(node.val);
            if (node.left == null && node.right == null && sum == targetSum)
            {
                Paths.Add(new List<int>(currentPath));
            }

            Dfs(node.left, sum, targetSum, currentPath);
            Dfs(node.right, sum, targetSum, currentPath);

            currentPath.RemoveAt(currentPath.Count - 1);

        }
    }
}
