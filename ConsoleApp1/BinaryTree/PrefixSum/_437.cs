namespace ConsoleApp1.BinaryTree.PrefixSum;

public class _437
{
    public int PathSum(
        TreeNode root,
        int targetSum,
        int currentSum = 0,
        Dictionary<int, int> valueFrequencyDict = null)
    {
        var count = 0;
        if (root == null)
        {
            return count;
        }

        currentSum += root.val;
        valueFrequencyDict ??= new Dictionary<int, int> { { 0, 1 } };

        count += valueFrequencyDict.GetValueOrDefault(currentSum - targetSum, 0);
        if (!valueFrequencyDict.TryAdd(currentSum, 1))
        {
            valueFrequencyDict[currentSum]++;
        }

        count += root.left != null
            ? PathSum(root.left, targetSum, currentSum, valueFrequencyDict)
            : 0;
        count += root.right != null
            ? PathSum(root.right, targetSum, currentSum, valueFrequencyDict)
            : 0;

        valueFrequencyDict[currentSum]--;
        return count;
    }
}