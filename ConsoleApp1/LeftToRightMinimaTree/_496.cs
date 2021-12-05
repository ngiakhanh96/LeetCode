namespace ConsoleApp1.LeftToRightMinimaTree;

public class _496
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var rightBigger = new int[nums2.Length];
        rightBigger[nums2.Length - 1] = -1;
        var valueToIndexDict = new Dictionary<int, int> { { nums2[nums2.Length - 1], nums2.Length - 1 } };
        for (var i = nums2.Length - 2; i >= 0; i--)
        {
            valueToIndexDict[nums2[i]] = i;
            var j = i + 1;
            while (j != -1 && nums2[i] >= nums2[j])
            {
                j = rightBigger[j];
            }
            rightBigger[i] = j;
        }

        var res = new int[nums1.Length];
        for (var i = 0; i < nums1.Length; i++)
        {
            var index = rightBigger[valueToIndexDict[nums1[i]]];
            res[i] = index > -1 ? nums2[index] : index;
        }
        return res;
    }
}