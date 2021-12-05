namespace ConsoleApp1.QuickSelect;

public class _283
{
    public void MoveZeroes(int[] nums)
    {
        var boundary = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                var temp = nums[i];
                nums[i] = nums[boundary];
                nums[boundary] = temp;
                boundary++;
            }
        }
    }
}