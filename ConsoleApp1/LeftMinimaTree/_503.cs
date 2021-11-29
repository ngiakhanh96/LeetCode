namespace ConsoleApp1.LeftMinimaTree;

public class _503
{
    public int[] NextGreaterElements(int[] nums)
    {
        var circularNums = new int[nums.Length * 2];
        for (int i = 0; i < nums.Length; i++)
        {
            circularNums[i] = nums[i];
            circularNums[i + nums.Length] = nums[i];
        }

        var rightBiggerElements = new int[nums.Length * 2];
        rightBiggerElements[rightBiggerElements.Length - 1] = -1;
        for (int i = circularNums.Length - 2; i >= 0; i--)
        {
            var j = i + 1;
            while (j != -1 && circularNums[i] >= circularNums[j])
            {
                j = rightBiggerElements[j];
            }
            rightBiggerElements[i] = j;
        }

        var res = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            var index = rightBiggerElements[i];
            if (index >= 0)
            {
                res[i] = nums[index % nums.Length];
            }
            else
            {
                res[i] = index;
            }
        }
        return res;
    }
}