namespace ConsoleApp1.QuickSelect;

// Last visit 21/5/2022
public class _905
{
    public int[] SortArrayByParity(int[] nums)
    {
        var boundary = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                var temp = nums[i];
                nums[i] = nums[boundary];
                nums[boundary] = temp;
                boundary++;
            }
        }
        return nums;
    }
}