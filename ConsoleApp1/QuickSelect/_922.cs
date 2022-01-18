namespace ConsoleApp1.QuickSelect;

public class _922
{
    public int[] SortArrayByParityII(int[] nums)
    {
        var even = 0;
        var odd = 1;
        while (even < nums.Length && odd < nums.Length)
        {

            if (nums[even] % 2 == 0)
            {
                even += 2;
            }

            else if (nums[odd] % 2 == 1)
            {
                odd += 2;
            }

            else
            {
                var temp = nums[even];
                nums[even] = nums[odd];
                nums[odd] = temp;
                even += 2;
                odd += 2;
            }
        }
        return nums;
    }

    public int[] SortArrayByParityII2(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums;
        }
        var lastPointer = 1;
        for (var i = 0; i < nums.Length; i += 2)
        {
            if (nums[i] % 2 != 0)
            {
                for (var j = lastPointer; j < nums.Length; j += 2)
                {
                    if (nums[j] % 2 == 0)
                    {
                        lastPointer = j;
                        var temp = nums[i];
                        nums[i] = nums[lastPointer];
                        nums[lastPointer] = temp;
                        break;
                    }
                }
            }
        }

        return nums;
    }
}