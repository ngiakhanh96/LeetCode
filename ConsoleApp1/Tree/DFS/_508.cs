namespace ConsoleApp1.Tree.DFS;

[LastVisited(2022, 11, 24)]
public class _508
{
    public Dictionary<int, int> SubTreeSumFrequencyDict { get; set; } = new();

    public HashSet<int> MostFrequentSubtreeSumHashSet { get; set; } = new();

    public int MostFrequency { get; set; }
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        SumOfSubTree(root);
        return MostFrequentSubtreeSumHashSet.ToArray();
    }

    private int SumOfSubTree(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }
        var currentSum = node.val;
        currentSum += SumOfSubTree(node.left) + SumOfSubTree(node.right);

        if (!SubTreeSumFrequencyDict.TryAdd(currentSum, 1))
        {
            SubTreeSumFrequencyDict[currentSum]++;
        }
        if (SubTreeSumFrequencyDict[currentSum] > MostFrequency)
        {
            MostFrequentSubtreeSumHashSet = new HashSet<int> { currentSum };
            MostFrequency = SubTreeSumFrequencyDict[currentSum];
        }
        else if (SubTreeSumFrequencyDict[currentSum] == MostFrequency)
        {
            MostFrequentSubtreeSumHashSet.Add(currentSum);
        }
        return currentSum;
    }
}