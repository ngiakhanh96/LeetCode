namespace ConsoleApp1.HashTable;

public class _454
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var sumDict = new Dictionary<int, int>();
        var count = 0;
        foreach (var num1 in nums1)
        {
            foreach (var num2 in nums2)
            {
                var currentSum = num1 + num2;
                if (sumDict.ContainsKey(currentSum))
                {
                    sumDict[currentSum]++;
                }
                else
                {
                    sumDict.Add(currentSum, 1);
                }
            }
        }

        foreach (var num3 in nums3)
        {
            foreach (var num4 in nums4)
            {
                var currentSum = num3 + num4;
                if (sumDict.ContainsKey(-currentSum))
                {
                    count += sumDict[-currentSum];
                }
            }
        }
        return count;
    }
}